namespace PackageExplorer.ObjectModel
{
    #region [===== Using =====]
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.IO.Packaging;
    using System.Security;
    using System.Windows.Forms;
    using System.Xml;
    using System.Linq;
    using PackageExplorer.ObjectModel.Vocabulary;

    #endregion

    public class Document
        : SelectableItemBase, IDisposable, IRelatable
    {
        #region [===== Instance fields =====]
        MemoryStream _packageStream = null;
        Package _package = null;
        string _name = null;
        string _path = null;
        
        bool _disposed = false;

        DocumentPartCache _partCache = null;
        DocumentPartCollection _mainParts = null;
        ExternalRelationshipCollection _externalRelationships = null;
        RelationshipPart _relationshipPart = null;
        DublinCoreProperties _properties = null;
        DocumentSignatureManager _signatureManager = null;
        PackagingErrorCollection _packagingErrors = null;
        PackageVocabulary _vocabulary;

        bool _isDirty = false;
        DateTime? _lastWriteTime = null;
        
        #endregion

        #region [===== Public properties =====]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DublinCoreProperties Properties
        {
            get
            {
                AssertDisposed();
                if (_properties == null)
                {
                    _properties = new DublinCoreProperties(_package.PackageProperties);
                }
                return _properties;
            }
        }

        [Description("The time of the last save.")]
        public DateTime? LastWriteTime
        {
            get { return _lastWriteTime; }
        }

        [Browsable(false)]
        public PackageVocabulary Vocabulary
        {
            get { return _vocabulary; }
        }

        [Browsable(false)]
        public bool IsSaved
        {
            get { return _path != null; }
        }

        [Browsable(false)]
        public DocumentPartCollection MainParts
        {
            get
            {
                AssertDisposed();
                return _mainParts;
            }
        }

        [Browsable(false)]
        public DocumentPart ActivePart
        {
            get { return _partCache.PrimarySelection; }
        }

        [Description("The location of the document on disk.")]
        public string Path
        {
            get { return _path; }
        }

        [Description("The document filename")]
        public string Filename
        {
            get
            {
                string fileName = null;
                if (String.IsNullOrEmpty(_path) == false)
                {
                    fileName = System.IO.Path.GetFileName(_path);
                }
                else
                {
                    fileName = _name;
                }
                return fileName;
            }
        }

        [Browsable(false)]
        public bool IsDirty
        {
            get { return _isDirty; }
        }

        [Browsable(false)]
        public DocumentSignatureManager SignatureManager
        {
            get { return _signatureManager; }
        }

        [Browsable(false)]
        public IEnumerable<DocumentPart> AllParts
        {
            get { return _partCache; }
        }

        [Browsable(false)]
        public RelationshipPart RelationshipPart
        {
            get
            {
                if (_relationshipPart == null)
                {
                    Uri relationshipPartUri = new Uri("/_rels/.rels", UriKind.Relative);
                    if (_package.PartExists(relationshipPartUri))
                    {
                        PackagePart packagePart = _package.GetPart(relationshipPartUri);
                        _relationshipPart = new RelationshipPart(this, packagePart);
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
                return _externalRelationships;
            }
        }

        [Browsable(false)]
        public PackagingErrorCollection PackagingErrors
        {
            get { return _packagingErrors; }
        }
        #endregion

        #region [===== Internal properties =====]
        internal Package Package
        {
            get { return _package; }
        }
        #endregion

        #region [===== Constructors =====]
        internal Document(object owner, PackageVocabulary vocabulary)
            : base(owner)
        {
            _packagingErrors = new PackagingErrorCollection();
            _packageStream = new MemoryStream();
            Package package = Package.Open(
                _packageStream, FileMode.Create, FileAccess.ReadWrite);
            _vocabulary = vocabulary;
            InitializeFromPackage(package);
            _isDirty = true;
        }

        internal Document(object owner, Stream stream)
            : base(owner)
        {
            _packageStream = new MemoryStream();
            _packagingErrors = new PackagingErrorCollection();
            using (BinaryReader reader = new BinaryReader(stream))
            {
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = reader.Read(buffer, 0, 1024)) > 0)
                {
                    _packageStream.Write(buffer, 0, bytesRead);
                }
            }
            Package package = Package.Open(_packageStream, FileMode.Open, FileAccess.ReadWrite);
            InitializeFromPackage(package);
            _lastWriteTime = DateTime.Now;
        }

        internal Document(object owner, Package package)
            : base(owner)
        {
            InitializeFromPackage(package);
        }

        internal Document(object owner, string path)
            : base(owner)
        {
            _packagingErrors = new PackagingErrorCollection();
            _path = path;
            _packageStream = new MemoryStream();
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Length > Int32.MaxValue)
            {
                throw new ApplicationException("File too large to load.");
            }
            _packageStream.Write(File.ReadAllBytes(_path), 0, (int)fileInfo.Length);
            Package package = Package.Open(_packageStream, FileMode.Open, FileAccess.ReadWrite);
            InitializeFromPackage(package);
            _lastWriteTime = fileInfo.LastWriteTime;
        }

        ~Document()
        {
            Dispose(false);
        }
        #endregion

        #region [===== Internal instance methods =====]
        internal void Flush()
        {
            _package.Flush();
        }

        internal void SetNewDocumentName(string name)
        {
            _name = name;
        }
        #endregion

        #region [===== Public instance methods =====]
        #region [===== Save / Close =====]
        public bool Save()
        {
            // Path can be null when document is new
            // or opened from Package. 
            if (String.IsNullOrEmpty(_path))
            {
                throw new Exception("Document has no associated path.");
            }
            AssertDisposed();
            bool saved = false;
            if (_isDirty)
            {
                saved = SaveAs(_path);
            }
            return saved;
        }

        public bool SaveAs(string path)
        {
            // PackageStream is null when 
            // document is created from Package
            if (_packageStream == null)
            {
                throw new ApplicationException(
                    "A document created with a package cannot be saved to disc, open the document using a stream or path instead.");
            }
            if (String.IsNullOrEmpty(path))
            {
                throw new ApplicationException("A filename needs to be specified");
            }            
            AssertDisposed();
            bool saved = false;
            CancelEventArgs e = new CancelEventArgs(false);
            OnSaving(e);
            if (e.Cancel == false)
            {
                _package.Flush();
                File.WriteAllBytes(path, _packageStream.ToArray());
                FileInfo fileInfo = new FileInfo(path);
                _lastWriteTime = fileInfo.LastWriteTime;
                _isDirty = false;
                saved = true;
                _path = path;
                FileInfo info = new FileInfo(_path);
                _lastWriteTime = info.LastWriteTime;
                OnDirtyChanged(EventArgs.Empty);
                OnSaved(EventArgs.Empty);
            }
            return saved;
        }
        
        public void MarkDirty()
        {
            _isDirty = true;
            OnDirtyChanged(EventArgs.Empty);
        }

        public bool Close()
        {
            bool closed = false;
            CancelEventArgs e = new CancelEventArgs(false);
            OnClosing(e);
            if (e.Cancel == false)
            {
                OnClosed(EventArgs.Empty);
                closed = true;
                ((IDisposable)this).Dispose();
            }
            return closed;
        }
        #endregion

        #region [===== Get / Create / Delete parts =====]
        public DocumentPart GetPart(Uri partUri)
        {
            AssertDisposed();
            return _partCache.Find(
                delegate(DocumentPart part)
                {
                    return part.Uri == partUri;
                });
        }

        public DocumentPart CreatePart(string path, string contentType)
        {
            AssertDisposed();
            path = CreateUniquePartLocation(path);
            PackagePart packagePart = _package.CreatePart(new Uri(path, UriKind.Relative), contentType);
            DocumentPart part = CreatePartInternal(packagePart);
            OnDocumentPartAdded(new DocumentPartEventArgs(part));
            MarkDirty();
            return part;
        }

        public void DeletePart(DocumentPart documentPart, bool deleteUnreachableChildren)
        {
            
            // remove part from parents
            // remove children -> children might require deletion as well
            // delete part
            if (documentPart.ParentRelationshipsCount > 0)
            {
                documentPart.RemoveFromParentCollections();
            }
            DeletePartInternal(documentPart);
            if (deleteUnreachableChildren)
            {
                List<DocumentPart> allParts = new List<DocumentPart>();
                foreach (DocumentPart part in _partCache)
                {
                    allParts.Add(part);
                }
                List<DocumentPart> reachableParts = new List<DocumentPart>();
                FindReachableParts(reachableParts, MainParts);
                List<DocumentPart> partsToDelete = new List<DocumentPart>();
                foreach (DocumentPart possibleDeletedPart in allParts)
                {
                    if (reachableParts.Contains(possibleDeletedPart) == false)
                    {
                        partsToDelete.Add(possibleDeletedPart);
                    }
                }
                foreach (DocumentPart partToDelete in partsToDelete)
                {
                    DeletePartInternal(partToDelete);
                }
            }
            MarkDirty();
        }

        void DeletePartInternal(DocumentPart part)
        {
            part.Activated -= new EventHandler<EventArgs>(DocumentPart_Activated);
            _partCache.Remove(part);
            _package.DeletePart(part.Uri);
            OnDocumentPartRemoved(new DocumentPartEventArgs(part));
        }

        void FindReachableParts(List<DocumentPart> reachableParts,
            DocumentPartCollection storedParts)
        {
            foreach (DocumentPart part in storedParts)
            {
                if (reachableParts.Contains(part) == false)
                {
                    reachableParts.Add(part);
                    FindReachableParts(reachableParts, part.ChildParts);
                }
            }
        }
        #endregion

        #region [===== IRelatable (Explicit) =====]
        PackageRelationship IRelatable.RelateTo(DocumentPart part, string relationshipType, string relationshipID)
        {
            AssertDisposed();
            PackageRelationship relationship = null;
            if (String.IsNullOrEmpty(relationshipID))
            {
                relationship = _package.CreateRelationship(part.Uri, TargetMode.Internal,
                   relationshipType);
            }
            else
            {
                relationship = _package.CreateRelationship(part.Uri, TargetMode.Internal, relationshipType, relationshipID);
            }
            _package.Flush();
            return relationship;
        }

        PackageRelationship IRelatable.RelateTo(Uri externalUri, string relationshipType, string relationshipID)
        {
            AssertDisposed();
            PackageRelationship relationship = null;
            if (String.IsNullOrEmpty(relationshipID) == false)
            {
                if (_package.RelationshipExists(relationshipID))
                {
                    throw new DuplicateRelationshipIDException();
                }
            }
            try
            {
                if (String.IsNullOrEmpty(relationshipID))
                {
                    relationship = _package.CreateRelationship(externalUri, TargetMode.External, relationshipType);
                }
                else
                {
                    relationship = _package.CreateRelationship(externalUri, TargetMode.External, relationshipType, relationshipID);
                }
                _package.Flush();
                return relationship;
            }
            catch (XmlException e)
            {
                throw new ObjectModelException("An error occured during the creation of a relationship", e);
            }
        }

        void IRelatable.RemoveRelationship(string relationshipID)
        {
            AssertDisposed();
            if (_package.RelationshipExists(relationshipID))
            {
                _package.DeleteRelationship(relationshipID);
            }
            _package.Flush();
        }

        VocabularyPart IRelatable.GetVocabularyPart(string relationshipType)
        {
            if (_vocabulary != null)
            {
                return _vocabulary.AllParts.Where(
                    part => part.SourceRelationship == relationshipType)
                .Where(
                    part => _vocabulary.AllGlobalReferences.Where(
                            reference => reference.Name == part.Name)
                            .Count() > 0)
                .FirstOrDefault();
            } 
            return null;
        }
        #endregion

        #region [===== IDisposable (Explicit) =====]
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion

        #region [===== Protected instance methods =====]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                if (disposing)
                {
                    foreach (DocumentPart part in _partCache)
                    {
                        part.Close();
                    }
                    _package.Close();
                    _package = null;
                    if (_packageStream != null)
                    {
                        _packageStream.Close();
                        _packageStream = null;
                    }
                }
                _disposed = true;
            }
        }

        protected virtual void OnDirtyChanged(EventArgs e)
        {
            EventHandler<EventArgs> handler = DirtyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSaving(CancelEventArgs e)
        {
            EventHandler<CancelEventArgs> handler = Saving;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSaved(EventArgs e)
        {
            EventHandler<EventArgs> handler = Saved;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnClosing(CancelEventArgs e)
        {
            EventHandler<CancelEventArgs> handler = Closing;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnClosed(EventArgs e)
        {
            EventHandler<EventArgs> handler = Closed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDocumentPartAdded(DocumentPartEventArgs e)
        {
            EventHandler<DocumentPartEventArgs> handler = DocumentPartAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDocumentPartRemoved(DocumentPartEventArgs e)
        {
            EventHandler<DocumentPartEventArgs> handler = DocumentPartRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region [===== Private instance methods =====]
        void InitializeFromPackage(Package package)
        {
            _package = package;
            if (_vocabulary == null)
            {
                _vocabulary = DocumentBuilder.DetermineVocabulary(_package);
            }
            _partCache = new DocumentPartCache(this);
            foreach (PackagePart part in package.GetParts())
            {
                if (String.Equals(
                    part.ContentType, PackageVocabulary.CT_RelationshipPart,
                    StringComparison.InvariantCulture) == false)
                {
                    CreatePartInternal(part);
                }
            }
            _signatureManager =
                new DocumentSignatureManager(this);
            CreateMainPartCollection();
            foreach (DocumentPart part in
                _partCache)
            {
                part.CreateChildPartCollection();
            }
        }

        void CreateMainPartCollection()
        {
            _mainParts = new DocumentPartCollection(this, this);
            _externalRelationships = new ExternalRelationshipCollection(this);
            PackageRelationshipCollection relationships = _package.GetRelationships();
            DocumentBuilder.InitializeCollections(this, relationships, _mainParts, _externalRelationships, this);
            _externalRelationships.ItemAdded +=
               delegate(object sender, ExternalRelationshipEventArgs e)
               {
                   MarkDirty();
               };
            _externalRelationships.ItemRemoved +=
                delegate(object sender, ExternalRelationshipEventArgs e)
                {
                    MarkDirty();
                };
        }

        DocumentPart CreatePartInternal(PackagePart packagePart)
        {
            VocabularyPart vocabularyPart =
                _vocabulary != null ?
                packagePart.ContentType != "application/xml" ? _vocabulary.AllParts.Where(
                vp => vp.ContentTypes.Contains(packagePart.ContentType)).FirstOrDefault() : null : null;
            DocumentPart part = new DocumentPart(this, this, packagePart, vocabularyPart);
            part.Activated += DocumentPart_Activated;
            _partCache.Add(part);
            return part;
        }

        string CreateUniquePartLocation(string path)
        {
            string workingPath = path;
            workingPath = workingPath.Replace('\\', '/');
            if (workingPath.StartsWith("/") == false)
            {
                workingPath = "/" + workingPath;
            }        

            string targetFolder = System.IO.Path.GetDirectoryName(workingPath);
            string fileName = System.IO.Path.GetFileName(workingPath);
            string fileNameWithoutExtension =
                System.IO.Path.GetFileNameWithoutExtension(workingPath);
            string extension = System.IO.Path.GetExtension(workingPath);

            int count = 1;
            int maxCount = Int32.MaxValue;

            Uri targetUri = new Uri(workingPath, UriKind.Relative);
            while (_package.PartExists(targetUri) == true)
            {
                string newFileName = null;
                if (count < maxCount)
                {
                    newFileName = fileNameWithoutExtension + count;
                    count++;
                }
                else
                {
                    newFileName = System.IO.Path.GetRandomFileName();
                }
                workingPath = System.IO.Path.Combine(
                    targetFolder,
                    newFileName + extension);
                workingPath = workingPath.Replace('\\', '/');
                targetUri = new Uri(workingPath, UriKind.Relative);
            }
            return workingPath;
        }

        void AssertDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Document");
            }
        }

        void DocumentPart_Activated(object sender, EventArgs e)
        {
            Activate();
        }
        #endregion



        #region [===== Events =====]
        public event EventHandler<CancelEventArgs> Saving;
        public event EventHandler<EventArgs> Saved;
        public event EventHandler<CancelEventArgs> Closing;
        public event EventHandler<EventArgs> Closed;
        public event EventHandler<EventArgs> DirtyChanged;
        public event EventHandler<DocumentPartEventArgs> DocumentPartAdded;
        public event EventHandler<DocumentPartEventArgs> DocumentPartRemoved;
        #endregion

        class DocumentPartCache 
            : SelectableCollectionBase<DocumentPart>
        {
            public DocumentPartCache(object parent)
                : base(parent, false)
            {

            }
        }
    }
}
