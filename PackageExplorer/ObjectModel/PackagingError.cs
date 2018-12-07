using System;

namespace PackageExplorer.ObjectModel
{
    public class PackagingError
    {
        string _message;
        bool _isResolved;

        public bool IsResolved
        {
            get { return _isResolved; }
        }

        public string Message
        {
            get { return _message; }
        }

        public PackagingError(string message, bool isResolved)
        {
            _message = message;
            _isResolved = isResolved;
        }
    }
}
