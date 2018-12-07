namespace PackageExplorer.ObjectModel
{
    using System;
    using System.IO.Packaging;
    using System.IO;
    using System.ComponentModel;
    using PackageExplorer.Core.Services;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Linq;
    using PackageExplorer.ObjectModel.Vocabulary;

    public class DocumentPart
        : SelectableItemBase, IRelatable
    {
        Document _document = null;
        List<PackageRelationship> _parentRelationships = null;
        PackagePart _packagePart = null;
        DocumentPartCollection _childParts = null;
        ExternalRelationshipCollection _externalRelationships = null;
        RelationshipPart _relationshipPart = null;
        bool _disposed;
        bool _childPartsCreated = false;
        
        [Browsable(false)]
        public VocabularyPart VocabularyPart { get; internal set; }

        [Browsable(false)]
        public Document Document
        {
            get { return _document; }
        }

        [Description("The part location inside the package.")]
        public Uri Uri
        {
            get { return _packagePart.Uri; }
        }

        [Description("The part title.")]
        public string Title
        {
            get { return Path.GetFileName(_packagePart.Uri.ToString()); }
        }

        [Browsable(false)]
        public int ParentRelationshipsCount
        {
            get { return _parentRelationships.Count; }
        }

        [Browsable(false)]
        public RelationshipPart RelationshipPart
        {
            get
            {
                if (_relationshipPart == null)
                {
                    Uri relationshipPartUri = CreateRelationshipPartUri();
                    if (_packagePart.Package.PartExists(relationshipPartUri))
                    {
                        PackagePart packagePart = _packagePart.Package.GetPart(relationshipPartUri);
                        _relationshipPart = new RelationshipPart(Document, packagePart);
                    }
                }
                return _relationshipPart;
            }
        }

        [Browsable(false)]
        public ExternalRelationshipCollection ExternalRelationships
        {
            get 
            {
                EnsureChildParts();
                return _externalRelationships; 
            }
        }

        [Browsable(false)]
        public DocumentPartCollection ChildParts
        {
            get
            {
                EnsureChildParts();
                return _childParts;
            }
        }

        [Description("A string defining the type of content for the part.")]
        public string ContentType
        {
            get
            {
                AssertDisposed();
                return _packagePart.ContentType;
            }
        }

        [Browsable(false)]
        public bool IsXmlPart
        {
            get
            {
                bool isXmlPart = false;
                if (String.Equals(ContentType, "application/xml",
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    isXmlPart = true;
                }
                else
                {
                    string[] parts = ContentType.Split('/', '+');
                    if (String.Equals(parts[parts.Length - 1], "xml",
                        StringComparison.InvariantCultureIgnoreCase))
                    {
                        isXmlPart = true;
                    }
                }
                return isXmlPart;
            }
        }

        internal DocumentPart(object owner, Document document, PackagePart packagePart, VocabularyPart vocabularyPart)
            : base(owner)
        {
            _document = document;
            _parentRelationships = new List<PackageRelationship>();            
            _packagePart = packagePart;
            VocabularyPart = vocabularyPart;
        }

        internal void Close()
        {
            _packagePart = null;
            if (_relationshipPart != null)
            {
                _relationshipPart.Close();
            }
            _disposed = true;
        }

        void AssertDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("DocumentPart");
            }
        }

        public override string ToString()
        {
            return _disposed ? base.ToString() : _packagePart.Uri.ToString();
        }

        PackageRelationship IRelatable.RelateTo(DocumentPart part, string relationshipType, string relationshipID)
        {
            AssertDisposed();
            PackageRelationship relationship = null;
            if (String.IsNullOrEmpty(relationshipID))
            {
                relationship = _packagePart.CreateRelationship(part.Uri,
                    TargetMode.Internal, relationshipType);
            }
            else
            {
                relationship = _packagePart.CreateRelationship(part.Uri,
                    TargetMode.Internal, relationshipType, relationshipID);
            }
            _packagePart.Package.Flush();
            return relationship;
        }

        PackageRelationship IRelatable.RelateTo(Uri externalUri, string relationshipType, string relationshipID)
        {
            AssertDisposed();
            PackageRelationship relationship = null;
            if (String.IsNullOrEmpty(relationshipID) == false)
            {
                if (_packagePart.RelationshipExists(relationshipID))
                {
                    throw new DuplicateRelationshipIDException();
                }
            }
            try
            {
                if (String.IsNullOrEmpty(relationshipID))
                {
                    relationship = _packagePart.CreateRelationship(externalUri, TargetMode.External, relationshipType);
                }
                else
                {
                    relationship = _packagePart.CreateRelationship(externalUri, TargetMode.External, relationshipType, relationshipID);
                }
                _packagePart.Package.Flush();
                return relationship;
            }
            catch (XmlException e)
            {
                throw new ObjectModelException("An error occured during the creation of a relationship", e);
            }
        }

        VocabularyPart IRelatable.GetVocabularyPart(string relationshipType)
        {
            VocabularyPart vocabularyPart = null;
            if (VocabularyPart != null)
            {
                vocabularyPart  = _document.Vocabulary.AllParts.Where(
                    part => part.SourceRelationship == relationshipType)
                .Where(
                    part => VocabularyPart.References.Where(
                        reference => reference.Name == part.Name).Count() > 0
                        ).FirstOrDefault();
            }
            return vocabularyPart;
        }

        void IRelatable.RemoveRelationship(string relationshipID)
        {
            AssertDisposed();
            if (_packagePart.RelationshipExists(relationshipID))
            {
                _packagePart.DeleteRelationship(relationshipID);
            }
            _packagePart.Package.Flush();
        }

        internal void AddParentRelationship(PackageRelationship relationship)
        {
            if (_parentRelationships.Contains(relationship) == false)
            {
                _parentRelationships.Add(relationship);
            }
        }

        internal void RemoveParentRelationship(PackageRelationship relationship)
        {
            if (_parentRelationships.Contains(relationship))
            {
                _parentRelationships.Remove(relationship);
            }
        }

        internal void RemoveFromParentCollections()
        {
            List<PackageRelationship> parentRelationships = new List<PackageRelationship>();
            parentRelationships.AddRange(_parentRelationships);
            Uri root = new Uri("/", UriKind.Relative);
            foreach (PackageRelationship relationship in parentRelationships)
            {
                if (relationship.SourceUri == root)
                {
                    _document.MainParts.Remove(this);
                }
                else
                {
                    DocumentPart part = _document.GetPart(relationship.SourceUri);
                    part.ChildParts.Remove(this);
                }
            }
        }

        internal void CreateChildPartCollection()
        {
            _childParts = new DocumentPartCollection(_document, this);
            _externalRelationships = new ExternalRelationshipCollection(this);
            PackageRelationshipCollection relationships = _packagePart.GetRelationships();
            DocumentBuilder.InitializeCollections(Document, relationships, 
                _childParts, _externalRelationships, this);
            _externalRelationships.ItemAdded +=
                delegate(object sender, ExternalRelationshipEventArgs e)
                {
                    _document.MarkDirty();
                };
            _externalRelationships.ItemRemoved +=
                delegate(object sender, ExternalRelationshipEventArgs e)
                {
                    _document.MarkDirty();
                };
            _childPartsCreated = true;
        }

        void EnsureChildParts()
        {
            if (_childPartsCreated == false)
            {
                CreateChildPartCollection();
                _childPartsCreated = true;
            }
        }

        Uri CreateRelationshipPartUri()
        {
            string path = Uri.ToString();
            string folderName = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);
            string relationshipPartFolder = Path.Combine(
                folderName, "_rels");
            string relationshipPartFilename = fileName + ".rels";
            string relationshipPartPath = Path.Combine(
                relationshipPartFolder, relationshipPartFilename);
            relationshipPartPath = relationshipPartPath.Replace('\\', '/');
            return new Uri(relationshipPartPath, UriKind.Relative);
        }

        public MemoryStream GetContent()
        {
            MemoryStream data = new MemoryStream();
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            using (Stream stream = _packagePart.GetStream(
                FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                while ((bytesRead = stream.Read(buffer, 0, 1024)) > 0)
                {
                    data.Write(buffer, 0, bytesRead);
                }
            }
            data.Position = 0;
            return data;
        }

        public void SetContent(byte[] content)
        {
            using (Stream stream = _packagePart.GetStream(
                FileMode.Create, FileAccess.ReadWrite))
            {
                stream.Write(content, 0, content.Length);
            }
            _document.MarkDirty();
        }

        public void SetContent(string content)
        {
            SetContent(content, Encoding.Default);
        }

        public void SetContent(string content, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(
                _packagePart.GetStream(FileMode.Create, FileAccess.ReadWrite),
                encoding))
            {
                writer.Write(content);
            }
            _document.MarkDirty();
        }

        public void SetContent(Stream content)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            using (Stream stream = _packagePart.GetStream(
                FileMode.Create, FileAccess.ReadWrite))
            {
                while ((bytesRead = content.Read(buffer, 0, 1024)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }
            _document.MarkDirty();
        }
    }
}
