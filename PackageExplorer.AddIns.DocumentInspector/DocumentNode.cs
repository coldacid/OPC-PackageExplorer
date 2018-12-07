using System;
using PackageExplorer.ObjectModel;
using System.Text;

namespace PackageExplorer.AddIns.DocumentInspector
{
    public class DocumentNode : DocumentInspectorTreeNode
    {
        Document _document;
        ReferencesNode _referencesNode = null;

        public Document Document
        {
            get { return _document; }
        }

        public override string ContextMenuTreePath
        {
            get { return "/workspace/documentInspector/toolStrips/documentContextStrip"; }
        }

        public DocumentNode(Document document)
        {
            _document = document;
            Tag = document;
            _referencesNode = new ReferencesNode(document.ExternalRelationships, this);
            _referencesNode.RefreshText(false);
            _document.MainParts.ItemAdded += MainParts_ItemAdded;
            _document.MainParts.ItemRemoved += MainParts_ItemRemoved;
            _document.DirtyChanged += Document_DirtyChanged;
            _document.DocumentPartRemoved += new EventHandler<DocumentPartEventArgs>(Document_DocumentPartRemoved);
        }

        public override void PerformAfterSelect()
        {
            _document.Activate();
        }

        public override object GetSelectionObject()
        {
            return _document;
        }

        protected override void OnNodeRemoved()
        {
            _document.MainParts.ItemAdded -= MainParts_ItemAdded;
            _document.MainParts.ItemRemoved -= MainParts_ItemRemoved;
            _document.DirtyChanged -= Document_DirtyChanged;
            _document.DocumentPartRemoved -= new EventHandler<DocumentPartEventArgs>(Document_DocumentPartRemoved);
        }

        void Document_DocumentPartRemoved(object sender, DocumentPartEventArgs e)
        {
            if (TreeView.FlatMode)
            {
                RemoveDocumentPartNode(e.Part);
            }
        }

        protected override string CreateNodeText()
        {
            StringBuilder text = new StringBuilder();
            text.Append(_document.Filename);
            if (_document.IsDirty)
            {
                text.Append("*");
            }
            if (TreeView != null && 
                (TreeView.DisplayMode & DisplayModes.Vocabulary) == DisplayModes.Vocabulary)
            {
                text.AppendFormat(" ({0})",
                    _document.Vocabulary != null ? _document.Vocabulary.Name : "Unknown");
            }
            return text.ToString();
        }

        protected override void CreateChildNodes()
        {
            _referencesNode.EnsureChildNodes();
            if (TreeView != null)
            {
                if (TreeView.FlatMode == false)
                {
                    foreach (DocumentPart part in _document.MainParts)
                    {
                        AddDocumentPartNode(part);
                    }
                }
                else
                {
                    foreach (DocumentPart part in _document.AllParts)
                    {
                        AddDocumentPartNode(part);
                    }
                }
            }
            ChildNodesCreated = true;
        }

        void AddDocumentPartNode(DocumentPart part)
        {
            DocumentPartNode node = new DocumentPartNode(part, _document.MainParts);
            EnsuredNodes.Add(node);
            node.EnsureChildNodes();
            node.RefreshText(false);
        }

        void RemoveDocumentPartNode(DocumentPart part)
        {
            DocumentPartNode node = (DocumentPartNode)FindDocumentPartNode(
                delegate(DocumentInspectorTreeNode searchNode)
                {
                    DocumentPartNode partNode = searchNode as DocumentPartNode;
                    return partNode != null && partNode.DocumentPart == part;
                });
            if (node != null)
            {
                EnsuredNodes.Remove(node);
                node.RaiseNodeRemoved();
            }
        }

        void MainParts_ItemAdded(object sender, DocumentPartEventArgs e)
        {
            if (TreeView.FlatMode == false || FindDocumentPartNode(e.Part) == null)
            {
                AddDocumentPartNode(e.Part);
            }
        }

        void MainParts_ItemRemoved(object sender, DocumentPartEventArgs e)
        {
            if (TreeView.FlatMode == false)
            {
                RemoveDocumentPartNode(e.Part);
            }
        }

        void Document_DirtyChanged(object sender, EventArgs e)
        {
            RefreshText(false);
        }

        DocumentPartNode FindDocumentPartNode(DocumentPart documentPart)
        {
            DocumentPartNode requestedNode = null;
            foreach (DocumentInspectorTreeNode node in Nodes)
            {
                DocumentPartNode partNode = node as DocumentPartNode;
                if (partNode != null && partNode.DocumentPart == documentPart)
                {
                    requestedNode = partNode;
                    break;
                }
            }
            return requestedNode;
        }
    }
}
