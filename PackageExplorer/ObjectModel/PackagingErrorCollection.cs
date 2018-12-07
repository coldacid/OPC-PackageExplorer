using System;
using System.Collections.Generic;

namespace PackageExplorer.ObjectModel
{
    public class PackagingErrorCollection
        : IEnumerable<PackagingError>
    {
        List<PackagingError> _errors = null;

        public int Count
        {
            get { return _errors.Count; }
        }

        public PackagingErrorCollection()
        {
            _errors = new List<PackagingError>();
        }

        public void Add(PackagingError error)
        {
            _errors.Add(error);
        }

        public IEnumerator<PackagingError> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<PackagingError>)this).GetEnumerator();
        }
    }
}
