using System;
using System.Collections;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;
using System.Reflection;
using System.Resources;

namespace PackageExplorer.Core.Services
{
    [CodonName("ResourceLibrary")]
    [RequiredAttribute("assemblyName")]
    [RequiredAttribute("resourceBaseName")]
    class ResourceLibraryCodon
        : ResourceCodon
    {
        string _assemblyName;
        string _resourceBaseName;
        string _resourceGroupName;

        public string AssemblyName
        {
            get { return _assemblyName; }
            set { _assemblyName = value; }
        }

        public string ResourceBaseName
        {
            get { return _resourceBaseName; }
            set { _resourceBaseName = value; }
        }

        public override object BuildItem(object owner, ArrayList subItems)
        {
            AssemblyName name = new AssemblyName(_assemblyName);
            foreach (Assembly assembly in AddInTreeSingleton.AddInTree.RuntimeLibraries)
            {
                if (assembly.GetName().Name == name.Name)
                {
                    return new Resource(
                        ResourceGroup, new ResourceManager(
                        name.Name + "." + _resourceBaseName, assembly, null));
                }
            }
            return null;
        }
    }
}
