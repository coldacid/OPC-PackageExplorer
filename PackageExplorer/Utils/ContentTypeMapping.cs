using System;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Utils
{
    class ContentTypeMapping
    {
        ContentTypes _contentTypes;
        string _extension;
        
        public ContentTypes ContentTypes
        {
            get { return _contentTypes; }
        }
        
        public string Extension
        {
            get { return _extension; }
        }

        public ContentTypeMapping(string extension, ContentTypes contenTypes)
        {
            _extension = extension;
            _contentTypes = contenTypes;
        }
    }
}
