using System;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Core.AddInModel.Codons;
using System.Collections;

namespace PackageExplorer.Utils
{
    [RequiredAttribute("filter")]
    [RequiredAttribute("title")]
    [CodonName("FileFilter")]
    class FileFilterCodon
        : CodonBase
    {
        private string _filter;
        private string _title;
        
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public override object BuildItem(object owner, ArrayList subItems)
        {
            return new FileFilter(this, owner);
        }
    }
}
