using System;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using System.Text;
using PackageExplorer.Core.Services;
using System.IO;
using System.Linq;
using System.Drawing;

namespace PackageExplorer.AddIns.DocumentInspector
{
    public class DocumentPartNode : DocumentInspectorTreeNode
    {
        DocumentPart _documentPart;
        DocumentPartCollection _containerCollection;
        ReferencesNode _referencesNode = null;

        public DocumentPart DocumentPart
        {
            get { return _documentPart; }
        }

        public string RelationshipID
        {
            get { return _containerCollection.GetRelationshipID(_documentPart); }
        }

        public override string ContextMenuTreePath
        {
            get { return "/workspace/documentInspector/toolStrips/documentPartContextStrip"; }
        }

        public DocumentPartNode(DocumentPart documentPart, DocumentPartCollection containerCollection)
        {
            _documentPart = documentPart;
            Tag = _documentPart;
            _containerCollection = containerCollection;
            _referencesNode = new ReferencesNode(documentPart.ExternalRelationships, this);
            _referencesNode.RefreshText(false);
            _documentPart.ChildParts.ItemAdded += ChildParts_ItemAdded;
            _documentPart.ChildParts.ItemRemoved += ChildParts_ItemRemoved;
        }

        public override void PerformAfterSelect()
        {
            _documentPart.Activate();
        }

        public override void PerformNodeAction()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.Open(_documentPart);
            if (window != null)
            {
                window.Show();
            }
        }

        public override object GetSelectionObject()
        {
            return _documentPart;
        }

        protected override void OnNodeRemoved()
        {
            _documentPart.ChildParts.ItemAdded -= ChildParts_ItemAdded;
            _documentPart.ChildParts.ItemRemoved -= ChildParts_ItemRemoved;
        }

        protected override string CreateNodeText()
        {
            StringBuilder text = new StringBuilder();
            if (TreeView != null)
            {
                if (TreeView.FlatMode == false && 
                    (TreeView.DisplayMode & DisplayModes.Relationships) == DisplayModes.Relationships)
                {
                    text.Append(_containerCollection.GetRelationshipID(_documentPart) + " - ");
                }
                if ((TreeView.DisplayMode & DisplayModes.Directories) == DisplayModes.Directories)
                {
                    string path = Path.GetDirectoryName(_documentPart.Uri.ToString());
                    string[] pathParts = path.Split(Path.DirectorySeparatorChar);
                    text.AppendFormat("{0}{1}", pathParts[pathParts.Length - 1], Path.DirectorySeparatorChar);
                }
            }
            text.Append(_documentPart.Title);
            if (TreeView != null &&
                (TreeView.DisplayMode & DisplayModes.Vocabulary) == DisplayModes.Vocabulary)
            {
                text.AppendFormat(" ({0})",
                    _documentPart.VocabularyPart != null ? _documentPart.VocabularyPart.Name : "Unknown");
            }
            return text.ToString();
        }

        protected override void CreateChildNodes()
        {
            _referencesNode.EnsureChildNodes();
            if (TreeView != null && TreeView.FlatMode == false)
            {
                foreach (DocumentPart part in _documentPart.ChildParts)
                {
                    AddDocumentPartNode(part);
                }
            }
            ChildNodesCreated = true;
        }

        void AddDocumentPartNode(DocumentPart part)
        {
            DocumentPartNode node = FindDocumentPartNode(part);
            if (node == null)
            {
                node = new DocumentPartNode(part, _documentPart.ChildParts);
                if (_documentPart.VocabularyPart != null)
                {
                    string relationshipType = _documentPart.ChildParts.GetRelationshipType(part);
                    if (_documentPart.VocabularyPart.AllowsChildRelationship(relationshipType) == false)
                    {
                        node.ForeColor = Color.Red;
                    }
                }
                Nodes.Add(node);
                node.EnsureChildNodes();
                node.RefreshText(false);
            }
        }

        void RemoveDocumentPartNode(DocumentPart part)
        {
            DocumentPartNode node = FindDocumentPartNode(part);
            if (node != null)
            {
                EnsuredNodes.Remove(node);
                node.RaiseNodeRemoved();
            }
        }

        DocumentPartNode FindDocumentPartNode(DocumentPart documentPart)
        {
            return Nodes.OfType<DocumentPartNode>().Where(
                part => part.DocumentPart == documentPart).FirstOrDefault();
        }

        void ChildParts_ItemAdded(object sender, DocumentPartEventArgs e)
        {
            if (TreeView.FlatMode == false)
            {
                AddDocumentPartNode(e.Part);
            }
        }

        void ChildParts_ItemRemoved(object sender, DocumentPartEventArgs e)
        {
            RemoveDocumentPartNode(e.Part);
        }
    }
}
