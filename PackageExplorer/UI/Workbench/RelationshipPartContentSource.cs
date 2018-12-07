using System;
using PackageExplorer.ObjectModel;
using System.IO;
using System.Xml;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Workbench
{
    class RelationshipPartContentSource
        : IContentSource
    {
        RelationshipPart _relationshipPart;

        public string Title
        {
            get
            {
                return Path.GetFileName(
                    _relationshipPart.Uri.ToString());
            }
        }

        public ContentTypes ContentType
        {
            get { return ContentTypes.Xml; }
        }

        public RelationshipPart RelationshipPart
        {
            get { return _relationshipPart; }
        }

        public RelationshipPartContentSource(RelationshipPart relationshipPart)
        {
            _relationshipPart = relationshipPart;
        }

        public bool HasSameSourceAs(IContentSource other)
        {
            bool hasSameSource = false;
            RelationshipPartContentSource source = other as RelationshipPartContentSource;
            if (source != null)
            {
                hasSameSource = source.RelationshipPart == _relationshipPart;
            }
            return hasSameSource;
        }

        public Stream GetContent()
        {
            MemoryStream data = new MemoryStream();
            XmlDocument document = new XmlDocument();
            using (Stream stream = _relationshipPart.GetContent())
            {
                document.Load(stream);
            }
            document.Save(data);
            data.Position = 0;
            return data;
        }

        public void SetContent(byte[] content)
        {
            throw new NotImplementedException();
        }
    }
}
