using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;
using System.Resources;

namespace PackageExplorer.Core.Services
{
    [CodonName("ResourceType")]
    [RequiredAttribute("typeName")]
    class ResourceTypeCodon
        : ResourceCodon
    {
        string _typeName;

        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        public override object BuildItem(object owner, System.Collections.ArrayList subItems)
        {
            Type type = Type.GetType(_typeName);
            ResourceManager rm = new ResourceManager(type);
            return new Resource(ResourceGroup, rm);
        }
    }
}
