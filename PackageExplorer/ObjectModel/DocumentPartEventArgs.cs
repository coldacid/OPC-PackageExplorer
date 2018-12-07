using System;

namespace PackageExplorer.ObjectModel
{
    public class DocumentPartEventArgs
        : EventArgs
    {
        DocumentPart _part;

        public DocumentPart Part
        {
            get { return _part; }
        }

        public DocumentPartEventArgs(DocumentPart part)
        {
            _part = part;
        }
    }
}
