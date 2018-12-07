namespace PackageExplorer.Core.AddInModel
{
	#region [===== Using =====]
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using PackageExplorer.Core.AddInModel.Codons;
	using PackageExplorer.Core.AddInModel.Conditions;
	#endregion
	
	/// <summary>
	/// Represents a <see cref="IAddInTreeNode"/> in the <see cref="DefaultAddInTree"/>.
	/// </summary>
	public class DefaultAddInTreeNode : IAddInTreeNode
	{	
		#region [===== Instance fields =====]
		/// <summary>
		/// A container for the childnodes of this node.
		/// </summary>
		Dictionary<String, IAddInTreeNode> _childNodes = new Dictionary<String, IAddInTreeNode>();
		/// <summary>
		/// The codon which is defined in this node.
		/// </summary>
		ICodon _codon = null;
		/// <summary>
		/// The path where this node resides.
		/// </summary>
        string _path;
		Extension _extension = null;
        string _nodeName;
		#endregion

		#region [===== Properties =====]
        public int Count
        {
            get { return _childNodes.Count; }
        }

		/// <summary>
		/// Gets or sets the <see cref="ICodon"/> which is defined in this node.
		/// </summary>
		public ICodon Codon
		{
			get{ return _codon;}
			set{ _codon = value;}
		}

		public Extension Extension
		{
			get { return _extension; }
			set { _extension = value; }
		}

        public string NodeName
        {
            get { return _nodeName; }
        }

		/// <summary>
		/// Gets or sets the conditions which are defined for the codon
		/// in this node.
		/// </summary>
        public List<ICondition> Conditions
        {
            get { return _codon != null ? _codon.Conditions : null; }
        }

		/// <summary>
		/// Gets the treepath for this node.
		/// </summary>
        public string Path
		{
			get{ return _path;}
		}

        public IAddInTreeNode this[string nodeName]
        {
            get
            {
                IAddInTreeNode node = null;
                _childNodes.TryGetValue(nodeName, out node);
                return node;
            }
        }

        internal Dictionary<string, IAddInTreeNode> ChildNodesInternal
        {
            get { return _childNodes; }
        }

		#endregion

		#region [===== Constructors =====]
		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultAddInTreeNode"/>
		/// class.
		/// </summary>
		/// <param name="path">The treepath where this node is defined.</param>
        internal DefaultAddInTreeNode(string name, string path)
		{
			_path = path;
            _nodeName = name;
		}
		#endregion

		#region [===== Public instance methods =====]
        public bool HasChildNode(string nodeName)
        {
            return _childNodes.ContainsKey(nodeName);
        }

        public IEnumerable<IAddInTreeNode> ChildNodes
        {
            get { return _childNodes.Values; }
        }

        public void Add(string nodeName, IAddInTreeNode node)
        {
            if (_childNodes.ContainsKey(nodeName))
            {
                throw new ApplicationException("Duplicate");
            }
            _childNodes.Add(nodeName, node);
        }

		/// <summary>
		/// Build the item defined by the codon in this node.
		/// </summary>
		/// <param name="caller">The object which wants the codon object
		/// to be built.</param>
		/// <returns>An object created by the codon in this node.</returns>
		/// <exception cref="CodonNotFoundException">Thrown when this node
		/// doesn't contain a codon.</exception>
		public object BuildItem(object caller)
		{
			if(_codon == null)
			{
				throw new CodonNotFoundException("Path doesn't contain a codon.");
			}
			return _codon.BuildItem(caller, BuildChildItems(caller));
		}

		/// <summary>
		/// Build the object defined by a child node of this node.
		/// </summary>
		/// <param name="caller">The object which wants the codon object
		/// to be built.</param>
		/// <param name="childID">The ID of the childnode which has
		/// to build the object.</param>
		/// <returns>The object build by a childnode identified by <paramref name="childID"/>.
		/// </returns>
		/// <exception cref="TreePathException">Thrown when the childnode 
		/// identified by <paramref name="childID"/> isn't found.</exception>
		public object BuildChildItem(object caller, string childID)
		{
			IAddInTreeNode node = _childNodes[childID];
			if(node == null)
			{
				throw new TreePathException(_path, childID);
			}
			ArrayList subItems = node.BuildChildItems(caller);
			return node.Codon.BuildItem(caller, subItems);
		}

		/// <summary>
		/// Build all objects defined by childnodes of this node.
		/// </summary>
		/// <param name="caller">The object which wants the codon object
		/// to be built.</param>
		/// <returns>An <see cref="ArrayList"/> containing the objects build
		/// by all childnodes of this node.</returns>
		public ArrayList BuildChildItems(object caller)
		{
			ArrayList items = new ArrayList();
			IAddInTreeNode[] nodes = GetSubnodesAsSortedArray();

			foreach(IAddInTreeNode node in nodes)
			{
				ArrayList subItems = node.BuildChildItems(caller);
				
				if(node.Codon.HandlesConditions || 
                    Condition.GetConditionFailedAction(node.Conditions, caller) != 
					ConditionFailedAction.Exclude)
				{
					object newItem = node.Codon.BuildItem(caller, subItems);
					items.Add(newItem);
				}
			}
			return items;
		}
		#endregion

		#region [===== Private instance methods =====]
		IAddInTreeNode[] GetSubnodesAsSortedArray()
		{
			DefaultAddInTreeNode node = this;
			int index = node.Count;
			IAddInTreeNode[] sortedNodes = new IAddInTreeNode[index];
			Hashtable  visited   = new Hashtable(index);
			Hashtable  ancestor = new Hashtable(index);

            foreach (string key in node.ChildNodesInternal.Keys) 
			{
				visited[key] = false;
				ancestor[key] = new ArrayList();
			}

            foreach (IAddInTreeNode child in node.ChildNodesInternal.Values)
			{
                // if insertAfter
				if(child.Codon.InsertAfter != null)
				{
                    // run each item
					for (int i = 0; i < child.Codon.InsertAfter.Length; ++i)
					{
                        // if the insertAfter actually exists
						if (ancestor.Contains(child.Codon.InsertAfter[i]))
						{
                            // register node as ancestor of insertAfter node
                            ((ArrayList)ancestor[child.Codon.InsertAfter[i]]).Add(child.Codon.ID);
						}
					}
				}
                // same for insertBefore
				if (child.Codon.InsertBefore != null)
				{
					for (int i = 0; i < child.Codon.InsertBefore.Length; ++i)
					{
						if(ancestor.Contains(child.Codon.ID))
						{
                            ((ArrayList)ancestor[child.Codon.ID]).Add(child.Codon.InsertBefore[i]);
						}
					}
				}
			}
			
			string[] keyarray = new string[visited.Keys.Count];
			visited.Keys.CopyTo(keyarray, 0);
			
			for (int i = 0; i < keyarray.Length; ++i) 
			{
				if((bool)visited[keyarray[i]] == false)
				{
                    index = Visit(keyarray[i], node.ChildNodesInternal, sortedNodes, visited, ancestor, index);
				}
			}
			return sortedNodes;
		}
		
		int Visit(string key, Dictionary<String, IAddInTreeNode> nodes, 
            IAddInTreeNode[] sortedNodes, Hashtable visited, Hashtable ancestors, int index)
		{
			visited[key] = true;
			foreach (string ancestor in (ArrayList)ancestors[key]) 
			{
				if ((bool)visited[ancestor] == false) 
				{
					index = Visit(ancestor, nodes, sortedNodes, visited, ancestors, index);
				}
			}
			
			sortedNodes[--index] = nodes[key];
			return index;
		}
		#endregion
	}
}
