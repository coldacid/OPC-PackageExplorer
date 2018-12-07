namespace PackageExplorer.Core.AddInModel
{
    #region [===== Using =====]
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;

    using PackageExplorer.Core.AddInModel.Codons;
    using PackageExplorer.Core.AddInModel.Conditions;
    using System.ComponentModel;
    #endregion

    /// <summary>
    /// An AddIn is the object representation of an addin XML file. The AddIn object contains
    /// <see cref="Extension"/> objects for each extension defined in the XML.
    /// </summary>
    public class AddInSchema
    {
        #region [===== Static fields =====]
        /// <summary>
        /// The location of the XML schema resource used for validating the AddIn XML.
        /// </summary>
        static readonly string _addInXsdResource = "PackageExplorer.Core.AddInModel.AddInSchema.xsd";
        #endregion

        #region [===== Instance fields =====]
        /// <summary>
        /// The name of the addIn.
        /// </summary>
        string _name = null;
        /// <summary>
        /// The author of the addIn.
        /// </summary>
        string _author = null;
        /// <summary>
        /// The copyright for the addIn.
        /// </summary>
        string _copyright = null;
        /// <summary>
        /// The URL of the manufacturer of the addIn.
        /// </summary>
        string _url = null;
        /// <summary>
        /// The description of the addIn.
        /// </summary>
        string _description = null;
        /// <summary>
        /// The addIn version.
        /// </summary>
        string _version = null;
        /// <summary>
        /// The name of the AddIn XML file.
        /// </summary>
        string _fileName = null;
        /// <summary>
        /// A container for storing the assemblies loaded by the addIn.
        /// </summary>
        Dictionary<String, Assembly> _runtimeLibraries = new Dictionary<String, Assembly>();
        /// <summary>
        /// A container for storing the extensions defined by the addIn.
        /// </summary>
        List<Extension> _extensions = new List<Extension>();
        #endregion

        #region [===== Properties =====]
        /// <summary>
        /// Gets the author of the AddIn.
        /// </summary>
        [Description("The author of the AddIn.")]
        public string Author
        {
            get { return _author; }
        }

        /// <summary>
        /// Gets the copyright for the AddIn.
        /// </summary>
        [Description("The copyright for the AddIn.")]
        public string Copyright
        {
            get { return _copyright; }
        }

        /// <summary>
        /// Gets the description of the AddIn.
        /// </summary>
        [Description("The description of the AddIn.")]
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// Gets the name of the AddIn XML file.
        /// </summary>
        [Description("The name of the AddIn XML file.")]
        public string Filename
        {
            get { return _fileName; }
        }

        /// <summary>
        /// Gets the name of the AddIn.
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the URL of the manufacturer of the AddIn.
        /// </summary>
        [Description("The URL of the manufacturer of the AddIn.")]
        public string Url
        {
            get { return _url; }
        }

        /// <summary>
        /// Gets the AddIn version.
        /// </summary>
        [Description("The AddIn version.")]
        public string Version
        {
            get { return _version; }
        }

        /// <summary>
        /// Gets an <see cref="System.Array"/> of assemblies loaded by
        /// the addIn.
        /// </summary>
        public ICollection<Assembly> RuntimeLibraries
        {
            get
            {
                return _runtimeLibraries.Values;
                //Assembly[] assemblies = new Assembly[_runtimeLibraries.Count];
                //_runtimeLibraries.Values.CopyTo(assemblies,0);
                //return assemblies;
            }
        }

        /// <summary>
        /// Gets an <see cref="System.Array"/> of extensions defined
        /// by the addIn.
        /// </summary>
        public Extension[] Extensions
        {
            get { return _extensions.ToArray(); }
        }
        #endregion

        #region [===== Public static methods =====]
        /// <summary>
        /// Create and initialize an AddIn using it's XML definition file.
        /// </summary>
        /// <param name="addInFile">The XML definition file for the addin.</param>
        /// <returns>An <see cref="AddIn"/> initialized from <paramref name="addInFile"/>.</returns>
        public static AddInSchema CreateAddIn(string addInFile)
        {
            Debug.WriteLine("Creating AddIn from file: " + Path.GetFileName(addInFile), "AddIn_Create");
            AddInSchema addIn = new AddInSchema();
            addIn.Initialize(addInFile);
            Debug.WriteLine("AddIn created", "AddIn_Create");
            return addIn;
        }
        #endregion

        #region [===== Public instance methods =====]
        public Assembly GetAssembly(string assemblyName)
        {
            Assembly assembly = null;
            if (_runtimeLibraries.ContainsKey(assemblyName))
            {
                assembly = _runtimeLibraries[assemblyName];
            }
            else
            {
                foreach (Assembly globalAssembly in AddInTreeSingleton.AddInTree.RuntimeLibraries)
                {
                    if (globalAssembly.GetName().Name == assemblyName)
                    {
                        assembly = globalAssembly;
                        break;
                    }
                }
            }
            return assembly;
        }

        /// <summary>
        /// Create an object defined or referenced by the Addin.
        /// </summary>
        /// <param name="className">The classname of the object to 
        /// create.</param>
        /// <returns>The instantiated object.</returns>
        /// <exception cref="System.TypeLoadException">Thrown when the <paramref name="className"/>
        /// isn't found in the addIn or AddInTree.</exception>
        public object CreateObject(string className)
        {
            object val = null;
            foreach (Assembly assembly in _runtimeLibraries.Values)
            {
                val = assembly.CreateInstance(className, true);
                if (val != null)
                {
                    return val;
                }
            }
            foreach (Assembly assembly in AddInTreeSingleton.AddInTree.RuntimeLibraries)
            {
                val = assembly.CreateInstance(className, true);
                if (val != null)
                {
                    return val;
                }
            }
            throw new TypeLoadException("Class " + className + " not found.");
        }
        #endregion

        #region [===== Private instance methods =====]
        /// <summary>
        /// Initialize the AddIn using a specified AddIn XML file.
        /// </summary>
        /// <param name="addInFile">The path to the XML definition file
        /// to use for initializing the AddIn.</param>
        void Initialize(string addInFile)
        {
            try
            {
                // Create and initialize the container.
                XmlDocument document = new XmlDocument();
                document.Load(addInFile);

                XmlSchema schema = XmlSchema.Read(Assembly.GetExecutingAssembly().GetManifestResourceStream(_addInXsdResource), null);
                document.Schemas.Add(schema);
                Debug.WriteLine("Validating XML definition", "AddIn_Load");
                document.Validate(delegate(object sender, ValidationEventArgs e)
                {
                    throw new Exception(e.Message);
                });
                // Load the attributes of the addin
                Debug.WriteLine("Loading AddIn attributes", "AddIn_Load");
                _fileName = addInFile;
                _name = document.DocumentElement.Attributes["name"].InnerText;
                _author = document.DocumentElement.Attributes["author"].InnerText;
                _copyright = document.DocumentElement.Attributes["copyright"].InnerText;
                _url = document.DocumentElement.Attributes["url"].InnerText;
                _description = document.DocumentElement.Attributes["description"].InnerText;
                _version = document.DocumentElement.Attributes["version"].InnerText;
                Debug.WriteLine(String.Format("AddIn identified as {0}, version {1}", _name, _version), "AddIn_Load");
                // Load each runtime library defined in the addin.
                XmlNamespaceManager mgr = new XmlNamespaceManager(document.NameTable);
                mgr.AddNamespace("a", "http://PackageExplorer/AddIn");
                Debug.WriteLine("Loading runtime libraries", "AddIn_Load");
                XmlNode runtimeNode = document.DocumentElement.SelectSingleNode("a:Runtime", mgr);
                if (runtimeNode != null)
                {
                    AddRuntimeLibraries(Path.GetDirectoryName(addInFile), runtimeNode, mgr);
                }
                // Load all definitions of conditions and store them temporarily,
                // the definitions are referenced by the extensions.
                Debug.WriteLine("Loading condition cache", "AddIn_Load");
                Dictionary<String, XmlNode> conditionDefinitions = new Dictionary<string, XmlNode>();
                foreach (XmlNode conditionalNode in document.DocumentElement.SelectNodes("a:Condition", mgr))
                {
                    if (conditionalNode.Attributes["name"] != null)
                    {
                        conditionDefinitions.Add(conditionalNode.Attributes["name"].InnerText,
                            conditionalNode.FirstChild);
                    }
                }
                Debug.WriteLine("Loading extensions", "AddIn_Load");
                // Load all extensions, passing along the pre-fetched condition definitions.
                foreach (XmlNode extensionNode in document.DocumentElement.SelectNodes("a:Extension", mgr))
                {
                    AddExtensions(conditionDefinitions, extensionNode);
                }
            }
            catch (Exception ex)
            {
                string msg = "An error occured while loading an addin." + Environment.NewLine +
                    "File: " + addInFile + Environment.NewLine;
                throw new AddInLoadException(msg, ex);
            }
        }

        /// <summary>
        /// Loads the runtime libaries defined by a node in the addin definition.
        /// </summary>
        /// <param name="basePath">The base path to use for assemblies referenced
        /// using a relative path.</param>
        /// <param name="runtimeNode">The node which contains the assembly nodes.</param>
        void AddRuntimeLibraries(string basePath, XmlNode runtimeNode, XmlNamespaceManager mgr)
        {
            foreach (XmlNode assemblyNode in runtimeNode.SelectNodes("a:Assembly", mgr))
            {

                string assemblyPath = assemblyNode.Attributes["path"].InnerText;
                assemblyPath = Path.IsPathRooted(assemblyPath) ? assemblyPath :
                    Path.Combine(basePath, assemblyPath);
                Debug.WriteLine("Loading AddIn library: " + Path.GetFileName(assemblyPath), "AddIn_Load");
                Assembly assembly = AddInTreeSingleton.AddInTree.LoadRuntimeLibrary(assemblyPath);
                _runtimeLibraries[assembly.GetName().Name] = assembly;
            }
        }

        /// <summary>
        /// Build a condition from it's XML representation.
        /// </summary>
        /// <param name="conditionNode">The XML representation of the condtion.</param>
        /// <returns>An <see cref="ICondition"/> object which corresponds with
        /// the information contained in the <paramref name="conditionNode"/>.</returns>
        ICondition BuildCondition(XmlNode conditionNode)
        {
            ICondition condition =
                AddInTreeSingleton.AddInTree.ConditionFactory.BuildCondition(conditionNode.Name);
            InitializeProperties(condition, conditionNode.Attributes);
            foreach (XmlNode childCondition in conditionNode.ChildNodes)
            {
                condition.AppendChild(BuildCondition(childCondition));
            }
            return condition;
        }

        /// <summary>
        /// Add <see cref="Extension"/> objects to the AddIn, which are defined in 
        /// the XML.
        /// </summary>
        /// <param name="conditions">The pre-loaded conditions which the extensions
        /// are allowed to use.</param>
        /// <param name="extensionNode">The XML node which defines
        /// the extension.</param>
        void AddExtensions(Dictionary<String, XmlNode> conditions, XmlNode extensionNode)
        {
            string extensionPath = extensionNode.Attributes["path"].InnerText;
            Debug.WriteLine("Loading Extension: " + extensionPath);
            Extension extension = new Extension(extensionPath);
            _extensions.Add(extension);
            AddCodonsToExtension(conditions, extension, extensionNode, new List<ICondition>());
        }

        /// <summary>
        /// Add the codon with its conditions defined by <paramref name="rootNode"/> to the extension, by accessing the 
        /// codon and condition builders in the addin tree. Recursively placed extensions, are 
        /// recursively build by calling this method on each child node of <paramref name="rootNode"/>.
        /// </summary>
        /// <param name="conditionDefinitions">The collection of XML condition definitions.</param>
        /// <param name="extension">The extension to which to add the codon.</param>
        /// <param name="rootNode">The node containing the extensions.</param>
        /// <param name="conditions">A container for storing recursively added conditions.</param>
        void AddCodonsToExtension(Dictionary<String, XmlNode> conditionDefinitions, Extension extension,
            XmlNode rootNode, List<ICondition> conditions)
        {
            foreach (XmlNode extensionNode in rootNode.ChildNodes)
            {
                // node may be comment or other
                if (extensionNode.NodeType == XmlNodeType.Element)
                {
                    Debug.WriteLine("Parsing node: " + extensionNode.LocalName);
                    try
                    {
                        // Verify which node we're encountering in the xml
                        switch (extensionNode.Name)
                        {
                            // A condition
                            case "Condition":
                                Debug.WriteLine("Parsing as a condition");
                                // Build the condition
                                ICondition condition = null;
                                if (extensionNode.Attributes["ref"] == null || extensionNode.Attributes["action"] == null)
                                {
                                    throw new MissingAttributeException("A condition is missing its required attributes.");
                                }
                                string conditionName = extensionNode.Attributes["ref"].InnerText;
                                string actionName = extensionNode.Attributes["action"].InnerText;
                                // Verify if the reference is present in the preloaded conditions
                                if (conditionDefinitions[conditionName] == null)
                                {
                                    throw new AddInFormatException("Referenced condition " + conditionName + " not found.");
                                }
                                // Build the condition and set the action to take when the 
                                // condition fails.
                                condition = BuildCondition(conditionDefinitions[conditionName]);
                                if (Enum.IsDefined(typeof(ConditionFailedAction), actionName) == false)
                                {
                                    string msg = String.Format("Action {0} for referenced condition {1} is not recognized.",
                                        actionName, conditionName);
                                    throw new AddInFormatException(msg);
                                }
                                condition.Action = (ConditionFailedAction)Enum.Parse(
                                    typeof(ConditionFailedAction), actionName, true);

                                conditions.Add(condition);
                                // Traverse the subtree, encountering new conditions and codons in the subtree.
                                AddCodonsToExtension(conditionDefinitions, extension, extensionNode, conditions);
                                // Now remove the last condition again, because now that we're back on this level,
                                // the condition isn't required anymore.
                                conditions.RemoveAt(conditions.Count - 1);
                                break;
                            // A codon
                            default:
                                Debug.WriteLine("Parsing as a codon");
                                // Build the codon, or raise an exception when the codon is unknown.
                                ICodon codon = AddInTreeSingleton.AddInTree.CodonFactory.CreateCodon(this, extensionNode.Name);
                                // Validate codon required attributes
                                ValidateAttributes(extensionNode.Attributes,
                                    GetRequiredAttributes(codon));
                                // initialize the codon using the attributes defined in XML
                                InitializeProperties(codon, extensionNode.Attributes);
                                // Store the current condition set and the initialized cood
                                codon.Conditions = new List<ICondition>(conditions);
                                extension.AddCodon(codon);
                                // Traverse the subtree
                                if (codon.HandlesDeserialization && codon is ICodonDeserialization)
                                {
                                    ((ICodonDeserialization)codon).Deserialize(extensionNode);
                                }
                                else
                                {
                                    if (extensionNode.ChildNodes.Count > 0)
                                    {
                                        // Create a new extension for childitems
                                        Extension subExtension = new Extension(extension.Path + "/" + codon.ID);
                                        _extensions.Add(subExtension);
                                        // Add the codons to the new extension.
                                        AddCodonsToExtension(conditionDefinitions, subExtension, extensionNode, conditions);
                                    }
                                }
                                break;
                        }
                    }
                    catch (AddInTreeException ex)
                    {
                        string msg = String.Format("Extension with path {0} contains an error.",
                            extension.Path);
                        throw new AddInTreeException(msg, ex);
                    }
                }
            }
        }

        void InitializeProperties(object item,
            XmlAttributeCollection xmlAttributeCollection)
        {
            Type codonType = item.GetType();
            foreach (XmlAttribute attribute in xmlAttributeCollection)
            {
                string propertyName = attribute.Name;
                PropertyInfo property =
                    codonType.GetProperty(propertyName,
                    BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                if (property != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(item, attribute.InnerText, null);
                    }
                    else
                    {
                        TypeConverterAttribute converterAttribute = (TypeConverterAttribute)
                            Attribute.GetCustomAttribute(property,
                                typeof(TypeConverterAttribute));
                        TypeConverter converter = null;
                        if (converterAttribute != null)
                        {
                            Type converterType = Type.GetType(converterAttribute.ConverterTypeName);
                            converter = (TypeConverter)Activator.CreateInstance(converterType);
                        }
                        else
                        {
                            converter = TypeDescriptor.GetConverter(
                                property.PropertyType);
                        }
                        if (converter.CanConvertFrom(typeof(string)))
                        {
                            object convertedValue = converter.ConvertFrom(attribute.InnerText);
                            property.SetValue(item, convertedValue, null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns an array of attribute names which should be present
        /// in the codon xml, the required attributes are defined by 
        /// the RequiredAttributeAttribute 
        /// </summary>
        /// <param name="obj">The object for which to obtain required attributes.</param>
        /// <returns>A string <see cref="System.Array"/> containing the attribute
        /// names which are required.</returns>
        string[] GetRequiredAttributes(object obj)
        {
            List<String> names = new List<String>();

            Type currentType = obj.GetType();
            while (currentType != typeof(Object))
            {
                RequiredAttributeAttribute[] requiredAttributes = (RequiredAttributeAttribute[])
                    Attribute.GetCustomAttributes(currentType, typeof(RequiredAttributeAttribute));
                foreach (RequiredAttributeAttribute attribute in
                    requiredAttributes)
                {
                    names.Add(attribute.AttributeName);
                }
                currentType = currentType.BaseType;
            }
            return names.ToArray();
        }

        /// <summary>
        /// Verifies whether all attributes which should be present in a Codon Xml node
        /// attribute collection, are actually present.
        /// </summary>
        /// <param name="attributes">The set of attributes defined on the codon.</param>
        /// <param name="names">The set of attribute names which should be present.</param>
        void ValidateAttributes(XmlAttributeCollection attributes, string[] names)
        {
            foreach (string name in names)
            {
                if (attributes[name] == null)
                {
                    throw new MissingAttributeException(name);
                }
            }
        }
        #endregion
    }
}
