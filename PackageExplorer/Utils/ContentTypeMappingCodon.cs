using System;
using PackageExplorer.Core.AddInModel.Codons;
using System.Collections;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Utils
{
    [CodonName("ContentTypeMapping")]
    [RequiredAttribute("extension")]
    [RequiredAttribute("contentTypes")]
    class ContentTypeMappingCodon
        : CodonBase
    {
        private string _extension;
        ContentTypes _contentTypes;

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public ContentTypes ContentTypes
        {
            get { return _contentTypes; }
            set { _contentTypes = value; }
        }

        public override object BuildItem(object owner, ArrayList subItems)
        {
            return new ContentTypeMapping(_extension, _contentTypes);   
        }
    }
}
