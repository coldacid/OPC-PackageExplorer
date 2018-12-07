using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Utils
{
    class FileFilter: IStatusEventReceiver
    {
        #region [===== Instance fields =====]
        FileFilterCodon _codon;
        object _caller;
        string _title;
        string _filter;
        #endregion

        #region [===== Properties =====]
        public string Title
        {
            get { return _title; }
        }

        public string Filter
        {
            get { return _filter; }
        }
        #endregion

        #region [===== Constructors =====]
        public FileFilter(FileFilterCodon codon, object caller)
        {
            _codon = codon;
            _caller = caller;
            _filter = codon.Filter;
            Update();
        }
        #endregion

        public void Update()
        {
            StringParserService parser = ServiceManager.GetService<StringParserService>();
            _title = parser.Parse(_codon.Title);            
        }
    }
}
