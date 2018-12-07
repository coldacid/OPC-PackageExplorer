using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Core.AddInModel;

namespace PackageExplorer.Utils
{
    static class FileFilters
    {        
        #region [===== Static Fields =====]
        static List<FileFilter> _fileFilters = null;
        #endregion

        static FileFilters()
        {
            _fileFilters = new List<FileFilter>();
            IAddInTreeNode filterNode = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/fileFilters");
            if (filterNode != null)
            {
                foreach (FileFilter filter in filterNode.BuildChildItems(null))
                {
                    _fileFilters.Add(filter);
                }
            }
        }

        public static int GetFilterIndexForExtension(string extension)
        {
            int index = -1;
            if (String.IsNullOrEmpty(extension) == false)
            {
                extension = extension.ToLower();
                for (int i = 0; i < _fileFilters.Count - 1; i++)
                {
                    if (_fileFilters[i].Filter.Contains(extension))
                    {
                        index = i + 1;
                        break;
                    }
                }
                if (index == -1)
                {
                    index = _fileFilters.Count;
                }
            }
            return index;
        }

        public static string BuildFileFilter()
        {
            StringBuilder filterBuilder = new StringBuilder();
            if (_fileFilters.Count > 0)
            {
                AddFileFilter(filterBuilder, _fileFilters[0]);
                for (int i = 1; i < _fileFilters.Count; i++)
                {
                    filterBuilder.Append("|");
                    AddFileFilter(filterBuilder, _fileFilters[i]);
                }
            }
            return filterBuilder.ToString();
        }

        static void AddFileFilter(StringBuilder filterBuilder, FileFilter filter)
        {
            filterBuilder.AppendFormat("{0}({1})|{1}", filter.Title, filter.Filter);
        }
    }
}
