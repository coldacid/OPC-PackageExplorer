using System;
using PackageExplorer.ObjectModel;
using System.IO;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Workbench
{
    class DocumentPartContentSource
        : IContentSource
    {
        DocumentPart _documentPart = null;

        public ContentTypes ContentType
        {
            get
            {
                return ContentTypeMappings.GetContentTypeForExtension(
                    Path.GetExtension(_documentPart.Uri.ToString()));               
            }
        }

        public DocumentPart DocumentPart
        {
            get { return _documentPart; }
        }

        public string Title
        {
            get { return _documentPart.Title; }
        }

        public DocumentPartContentSource(DocumentPart documentPart)
        {
            _documentPart = documentPart;
        }

        public bool HasSameSourceAs(IContentSource other)
        {
            bool hasSameSource = false;
            DocumentPartContentSource source = other as DocumentPartContentSource;
            if (source != null)
            {
                hasSameSource = source.DocumentPart == _documentPart;
            }
            return hasSameSource;
        }

        public Stream GetContent()
        {
            return _documentPart.GetContent();
        }

        public void SetContent(byte[] content)
        {
            _documentPart.SetContent(content);
        }
    }
}
