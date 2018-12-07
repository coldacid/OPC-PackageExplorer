using System;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Workbench
{
    class BrowserContentSource
        : IContentSource
    {
        Uri _targetUri = null;

        public Uri TargetUri
        {
            get { return _targetUri; }
        }

        public string Title
        {
            get { return _targetUri.ToString(); }
        }

        public ContentTypes ContentType
        {
            get { return ContentTypes.Binary; }
        }

        public BrowserContentSource(Uri targetUri)
        {
            _targetUri = targetUri;
        }

        public bool HasSameSourceAs(IContentSource other)
        {
            bool hasSameSource = false;
            BrowserContentSource source = other as BrowserContentSource;
            if (source != null)
            {
                hasSameSource = source.TargetUri == TargetUri;
            }
            return hasSameSource;
        }

        public System.IO.Stream GetContent()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetContent(byte[] content)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
