using System;
using System.Collections.Generic;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Utils
{
    static class ContentTypeMappings
    {
        static List<ContentTypeMapping> _mappings = null;

        static List<ContentTypeMapping> Mappings
        {
            get
            {
                if (_mappings == null)
                {
                    _mappings = new List<ContentTypeMapping>();
                    IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode(
                        "/workspace/contentTypeMappings");
                    
                    if (node != null)
                    {
                        foreach (ContentTypeMapping mapping in node.BuildChildItems(null))
                        {
                            _mappings.Add(mapping);
                        }
                    }
                }
                return _mappings;
            }
        }

        public static ContentTypes GetContentTypeForExtension(string extension)
        {
            ContentTypes types = ContentTypes.Unknown;
            foreach (ContentTypeMapping mapping in Mappings)
            {
                if (String.Equals(
                    extension, mapping.Extension, StringComparison.InvariantCultureIgnoreCase))
                {
                    types = mapping.ContentTypes;
                    break;
                }
            }
            return types;
        }
    }
}
