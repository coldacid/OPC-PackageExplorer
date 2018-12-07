using System;
using System.IO;
using System.IO.Packaging;
using PackageExplorer.ObjectModel.Vocabulary;

namespace PackageExplorer.ObjectModel
{
    public class DocumentCollection
        : SelectableCollectionBase<Document>
    {
        internal DocumentCollection(object parent)
            : base(parent, false)
        {

        }

        #region [===== Public methods =====]
        public Document Open(string path)
        {
            Document document = FindDocumentByPath(path);
            if (document == null)
            {
                document = new Document(this, path);
                Add(document);
            }
            document.Activate();
            return document;
        }

        public Document Open(Package package)
        {
            Document document = FindDocumentByPackage(package);
            if (document == null)
            {
                document = new Document(this, package);
                Add(document);
            }
            document.Activate();
            return document;
        }

        public Document Open(Stream stream)
        {
            Document document = new Document(this, stream);
            Add(document);
            document.Activate();
            return document;
        }

        public Document New(string name)
        {
            return New(name, null);
        }

        public Document New(string name, PackageVocabulary vocabulary)
        {
            Document document = new Document(this, vocabulary);
            document.SetNewDocumentName(name);
            Add(document);
            document.Activate();
            return document;
        }
        #endregion

        protected override void OnItemAdded(ItemEventArgs<Document> e)
        {
            e.Item.Closed += new EventHandler<EventArgs>(Item_Closed);
            base.OnItemAdded(e);
        }

        protected override void OnItemRemoved(ItemEventArgs<Document> e)
        {
            e.Item.Closed -= new EventHandler<EventArgs>(Item_Closed);
            base.OnItemRemoved(e);
        }

        void Item_Closed(object sender, EventArgs e)
        {
            Remove((Document)sender);
        }

        Document FindDocumentByPath(string path)
        {
            Document document = null;
            foreach (Document searchDocument in this)
            {
                if (String.IsNullOrEmpty(searchDocument.Path) == false)
                {
                    string firstPath = Path.GetFullPath(path);
                    string secondPath = Path.GetFullPath(searchDocument.Path);
                    if (String.Equals(
                        firstPath, secondPath, StringComparison.InvariantCultureIgnoreCase))
                    {
                        document = searchDocument;
                        break;
                    }
                }
            }
            return document;
        }

        Document FindDocumentByPackage(Package package)
        {
            Document document = null;
            foreach (Document searchDocument in this)
            {
                if (searchDocument.Package == package)
                {
                    document = searchDocument;
                    break;
                }
            }
            return document;
        }
    }
}
