namespace PackageExplorer.ObjectModel
{
    using System;
    using System.IO.Packaging;
    using System.IO;

    public class RelationshipPart
    {
        Document _owner;
        PackagePart _packagePart;
        bool _disposed = false;

        public string ContentType
        {
            get { return _packagePart.ContentType; }
        }

        public Uri Uri
        {
            get { return _packagePart.Uri; }
        }

        public Document Owner
        {
            get { return _owner; }
        }

        internal RelationshipPart(Document owner, PackagePart part)
        {
            _owner = owner;
            _packagePart = part;
        }

        public Stream GetContent()
        {
            AssertDisposed();
            return _packagePart.GetStream(FileMode.Open, FileAccess.Read);
        }

        internal void Close()
        {
            _packagePart = null;
            _disposed = true;
        }

        void AssertDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("RelationshipPart");
            }
        }
    }
}
