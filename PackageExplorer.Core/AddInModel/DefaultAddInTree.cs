namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	using System.Security.Policy;
	using PackageExplorer.Core.AddInModel.Codons;
	using PackageExplorer.Core.AddInModel.Conditions;
    using PackageExplorer.Core.Services;
    using System.Diagnostics;
	#endregion

	/// <summary>
	/// Provides a default implementation of the <see cref="IAddInTree"/> interface.
	/// </summary>
	public class DefaultAddInTree : IAddInTree
	{
		#region [===== Instance fields =====]
		/// <summary>
		/// A container for the addins stored in the addintree.
		/// </summary>
		List<AddIn> _addIns = new List<AddIn>();
		/// <summary>
		/// A factory for creating <see cref="ICodon"/> objects.
		/// </summary>
		CodonFactory _codonFactory = new CodonFactory();
		/// <summary>
		/// A factory for creating <see cref="ICondition"/> objects.
		/// </summary>
		ConditionFactory _conditionFactory = new ConditionFactory();
		/// <summary>
		/// The rootnode of the addintree.
		/// </summary>
		DefaultAddInTreeNode _rootNode = new DefaultAddInTreeNode("AddInTree", "");
		#endregion

		#region [===== Properties =====]
		/// <summary>
		/// Gets an <see cref="System.Array"/> of <see cref="Assembly"/> objects 
		/// which are loaded into the tree.
		/// </summary>
		public Assembly[] RuntimeLibraries
		{
			get
			{
				// Create assembly container
				List<Assembly> assemblies = new List<Assembly>();
				// Add two default assemblies
				assemblies.Add(Assembly.GetExecutingAssembly());
				assemblies.Add(Assembly.GetEntryAssembly());
				// Add each assembly defined by an addin.
				foreach(AddIn addIn in _addIns)
				{
					foreach(Assembly assembly in addIn.RuntimeLibraries)
					{
						assemblies.Add(assembly);
					}
				}
				return assemblies.ToArray();
			}
		}

        public IAddInTreeNode this[string path]
		{
			get { return GetTreeNode(path); }
		}

		public IEnumerable<AddIn> AddIns
		{
			get { return _addIns; }
		}
	
		/// <summary>
		/// Gets a factory for creating <see cref="ICodon"/> objects.
		/// </summary>
		public CodonFactory CodonFactory
		{
			get{ return _codonFactory;}
		}

		/// <summary>
		/// Gets a factory for creating <see cref="ICondition"/> objects.
		/// </summary>
		public ConditionFactory ConditionFactory
		{ 
			get{ return _conditionFactory;}
		}

		/// <summary>
		/// Gets the root node of the tree.
		/// </summary>
		public IAddInTreeNode Root
		{
			get{ return _rootNode;}
		}
		#endregion

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultAddInTree"/> class, 
		/// loading the codons and conditions from the executing and entry assembly.
		/// </summary>
		internal DefaultAddInTree()
		{
			LoadCodonsAndConditions(Assembly.GetExecutingAssembly());
            LoadCodonsAndConditions(Assembly.GetEntryAssembly());
        }

		#endregion

		#region [===== Public instance methods =====]
		/// <summary>
		/// Load an assembly into the AddInTree.
		/// </summary>
		/// <param name="assemblyName">The path to the <see cref="Assembly"/> to load.</param>
		/// <returns>The loaded assembly.</returns>		
		public Assembly LoadRuntimeLibrary(string assemblyName)
		{
            AssemblyName name = new AssemblyName(assemblyName);
            Assembly assembly = GetLoadedAssembly(name);
            if (assembly != null)
            {
                Version currentAssemblyVersion = assembly.GetName().Version;
                if (currentAssemblyVersion.Equals(name.Version) == false)
                {
                    string msg = "Addin references loaded assembly with different version." + Environment.NewLine +
                        "Assembly: " + name.Name + Environment.NewLine +
                        "Existing version: " + currentAssemblyVersion.ToString(4) + Environment.NewLine;
                    throw new BadImageFormatException(msg);
                }
            }
            else
            {
                assembly = Assembly.Load(assemblyName);
                LoadCodonsAndConditions(assembly);
            }
            return assembly;
		}
		
		/// <summary>
		/// Insert an <see cref="AddIn"/> into the AddInTree.
		/// </summary>
		/// <param name="addIn"></param>
		public void InsertAddIn(AddIn addIn)
		{
			_addIns.Add(addIn);
			foreach(Extension extension in addIn.Extensions)
			{
				AddExtension(extension);
			}
		}
		
		/// <summary>
		/// Retrieves a node from the tree.
		/// </summary>
		/// <param name="path">The path to the node to retrieve.</param>
		/// <returns>The requested node.</returns>
		/// <exception cref="TreePathException">Thrown when the <paramref name="path"/>
		/// doesn't exist in the AddInTree.</exception>
        public IAddInTreeNode GetTreeNode(string path)
		{
			return GetTreeNode(path, false);
		}

		/// <summary>
		/// Retrieves a node from the tree.
		/// </summary>
		/// <param name="path">The path to the node to retrieve.</param>
		/// <param name="createMissing">Indicates a value whether to create the 
		/// missing path nodes.</param>
		/// <returns>The requested node.</returns>
		/// <exception cref="TreePathException">Thrown when the <paramref name="path"/>
		/// doesn't exist in the AddInTree and <paramref name="createMissing"/> is set
		/// to <b>false</b>.</exception>
        public IAddInTreeNode GetTreeNode(string path, bool createMissing)
		{
            if (String.IsNullOrEmpty(path))
            {
                return null;
            }
			return TraversePath(_rootNode, path, createMissing);
		}
		#endregion

		#region [===== Private instance methods =====]
		Assembly GetLoadedAssembly(AssemblyName assemblyName)
		{
			foreach(Assembly assembly in RuntimeLibraries)
			{
				if(assembly.GetName().Name.Equals(assemblyName.Name))
				{
                    return assembly;
				}
			}
			return null;
		}

		/// <summary>
		/// Load the codons and conditions defined in an assembly.
		/// </summary>
		/// <param name="assembly">The assembly which contains codons or conditions.</param>
		void LoadCodonsAndConditions(Assembly assembly)
		{
			// Run through each type and add if necessary.
			foreach(Type type in assembly.GetTypes())
			{
				// No abstract classes
				if(!type.IsAbstract)
				{
					// Add codons which also have the CodonNameAttribute defined.
					if(typeof(ICodon).IsAssignableFrom(type) && 
						Attribute.GetCustomAttribute(type, typeof(CodonNameAttribute)) != null)
					{
						_codonFactory.AddCodonBuilder( new CodonBuilder(type.FullName, assembly));
					}
					// Add conditions which also have the ConditionNameAttribute defined.
					if(typeof(ICondition).IsAssignableFrom(type) && 
						Attribute.GetCustomAttribute(type, typeof(ConditionNameAttribute)) != null)
					{
						_conditionFactory.AddConditionBuilder( new ConditionBuilder(type.FullName, assembly));
					}
				}
			}
        }

		/// <summary>
		/// Add an extension into the AddInTree.
		/// </summary>
		/// <param name="extension"></param>
		void AddExtension(Extension extension)
		{
			// Create the path required for the extension.
			DefaultAddInTreeNode localRoot = CreatePath(_rootNode, extension.Path);
            if (localRoot.Extension == null)
            {
                localRoot.Extension = extension;
            }
            foreach(ICodon codon in	extension.Codons)
			{
				// Create a path using the localRoot as rootnode, and the codon ID as
				// child, this creates aa new node which can hold the codon.
				DefaultAddInTreeNode localPath = CreatePath(localRoot, codon.ID);
				// If a codon is already present, a duplicate codon ID exists.
				if(localPath.Codon != null)
				{
					string msg = String.Format("Path {0} already has a codon defined.",
                        localPath.Path);
					throw new DuplicateCodonException(msg);
				}
				// Store the codon in the path, along with its conditions.
				localPath.Codon = codon;
			}
		}

		/// <summary>
		/// Create a treepath.
		/// </summary>
		/// <param name="pathRoot">The rootnode for the path to create.</param>
		/// <param name="path">The subpath to create starting at the <paramref name="pathRoot"/>.</param>
		/// <returns>The correct treenode for the given path.</returns>
        DefaultAddInTreeNode CreatePath(DefaultAddInTreeNode pathRoot, string path)
		{
			return TraversePath(pathRoot, path, true);
		}

		/// <summary>
		/// Traverse the subtree, optionally creating missing nodes along the way.
		/// </summary>
		/// <param name="pathRoot"></param>
		/// <param name="path"></param>
		/// <param name="createMissingPathNodes"></param>
		/// <returns></returns>
		DefaultAddInTreeNode TraversePath(DefaultAddInTreeNode pathRoot,
            string path, bool createMissingPathNodes)
		{
			DefaultAddInTreeNode currentPathNode = pathRoot;
			string currentPath = pathRoot.Path;
            path = path.TrimStart('/');
            string[] pathParts = path.Split('/');
            if (pathParts.Length > 0)
			{
				int i = 0;
                while (i < pathParts.Length)
				{
                    string pathPart = pathParts[i];
					currentPath = currentPath + "/" + pathPart;
                    if(currentPathNode.HasChildNode(pathPart))
					{
						currentPathNode = (DefaultAddInTreeNode)currentPathNode[pathPart];
					}
					else if (createMissingPathNodes)
					{
						DefaultAddInTreeNode nextPathNode =
                            new DefaultAddInTreeNode(pathPart, currentPath);
						currentPathNode.Add(pathPart, nextPathNode);
						currentPathNode = nextPathNode;
					}
					else
						return null;
					i++;
				}				
			}
			return currentPathNode;
		}
		#endregion
	}	
}
