using System;
using System.Windows.Forms;
using Application = PackageExplorer.ObjectModel.Application;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using System.Text;
using System.IO;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.AddInModel;
using System.ComponentModel;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.AddIns.DocumentInspector
{
    public class DocumentInspectorControl
        : TreeView
    {
        public static readonly Guid ID = new Guid("{75D4E3DB-29FE-4bc2-B7D7-78280A30B2A6}");
        DisplayModes _displayMode = DisplayModes.Normal;
        DocumentInspectorSettings _settings = null;
        bool _flatMode = false;

        internal DisplayModes DisplayMode
        {
            get { return _displayMode; }
            set
            {
                _displayMode = value;
                RefreshAllNodeText();
            }
        }

        internal bool FlatMode
        {
            get { return _flatMode; }
            set
            {
                if (_flatMode != value)
                {
                    _flatMode = value;
                }
            }
        }

        public DocumentInspectorControl()
        {
            AllowDrop = true;
            this.DragEnter +=
                delegate(object sender, DragEventArgs e)
                {
                    if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                };

            this.DragDrop +=
                delegate(object sender, DragEventArgs e)
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string file in files)
                    {
                        Application.Documents.Open(file);
                    }
                };
            HideSelection = false;
        }

        protected override void OnCreateControl()
        {
            ISettingsService service = ServiceManager.GetService<ISettingsService>();
            _settings = service.GetSettings<DocumentInspectorSettings>();
            _displayMode = _settings.DisplayMode;
            _flatMode = _settings.FlatMode;
            _settings.PropertyChanged +=
                delegate(object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "DisplayMode")
                    {
                        _displayMode = _settings.DisplayMode;
                        WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
                        IWindow window = workbenchService.GetWindow(ID);
                        window.Refresh();
                        RefreshAllNodeText();
                    }
                    else if (e.PropertyName == "FlatMode")
                    {
                        _flatMode = _settings.FlatMode;
                        WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
                        IWindow window = workbenchService.GetWindow(ID);
                        window.Refresh();
                        RecreateTree();
                    }
                };
            // add all open documents
            foreach (Document document in Application.Documents)
            {
                AddDocument(document);
            }
            // monitor addition of new documents
            Application.Documents.ItemAdded +=
                delegate(object sender, ItemEventArgs<Document> e)
                {
                    AddDocument(e.Item);
                };
            Application.Documents.ItemRemoved +=
                delegate(object sender, ItemEventArgs<Document> e)
                {
                    RemoveDocument(e.Item);
                };
        }

        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            // Check child nodes of all child nodes,
            // this enables the + to appear on items which 
            // have children (e.g, parse one level deeper than is visible)
            DocumentInspectorTreeNode node = (DocumentInspectorTreeNode)e.Node;
            foreach (DocumentInspectorTreeNode childNode in node.EnsuredNodes)
            {
                childNode.EnsureChildNodes();
            }
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            DocumentInspectorTreeNode node = e.Node as DocumentInspectorTreeNode;
            node.PerformAfterSelect();
            ISelectionService selectionService = (ISelectionService)ServiceManager.Services[typeof(ISelectionService)];
            selectionService.SetSelectedComponents(new object[] { node.GetSelectionObject() });
            base.OnAfterSelect(e);
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.IsSelected == false)
                {
                    SelectedNode = e.Node;
                    System.Windows.Forms.Application.DoEvents();
                }
                DocumentInspectorTreeNode node = e.Node
                    as DocumentInspectorTreeNode;
                if (String.IsNullOrEmpty(node.ContextMenuTreePath) == false)
                {
                    IAddInTreeNode menuNode =
                        AddInTreeSingleton.AddInTree.GetTreeNode(node.ContextMenuTreePath);
                    if (menuNode != null)
                    {
                        ContextMenuStrip menu = (ContextMenuStrip)menuNode.BuildItem(this);
                        foreach (ToolStripItem item in menu.Items)
                        {
                            if (item is IStatusEventReceiver)
                            {
                                ((IStatusEventReceiver)item).Update();
                            }
                        }
                        menu.Show(PointToScreen(e.Location));
                    }
                }
            }
            base.OnNodeMouseClick(e);
        }

        protected override void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node.Level > 0)
            {
                DocumentInspectorTreeNode node =
                    e.Node as DocumentInspectorTreeNode;
                node.PerformNodeAction();
            }
            base.OnNodeMouseDoubleClick(e);
        }

        void AddDocument(Document document)
        {
            BeginUpdate();
            try
            {
                DocumentNode node = new DocumentNode(document);
                Nodes.Add(node);
                node.EnsureChildNodes();
                node.RefreshText(true);
                node.Expand();
            }
            finally
            {
                EndUpdate();
            }
        }

        void RemoveDocument(Document document)
        {
            // Get the right root node
            DocumentNode documentNode = FindDocumentNode(document);
            if (documentNode != null)
            {
                BeginUpdate();
                try
                {
                    // And just remove it from the tree
                    Nodes.Remove(documentNode);
                }
                finally
                {
                    EndUpdate();
                }
                // remove selection just in case it was the document
                // done here since this is the only class which selects a document
                // TODO: Move this code to a better place
                ISelectionService service = ServiceManager.GetService<ISelectionService>();
                service.SetSelectedComponents(null);
            }
        }

        DocumentNode FindDocumentNode(Document document)
        {
            DocumentNode requestedNode = null;
            foreach (TreeNode searchNode in Nodes)
            {
                DocumentNode searchDocumentNode = searchNode as DocumentNode;
                if (searchDocumentNode != null && searchDocumentNode.Document == document)
                {
                    requestedNode = searchDocumentNode;
                    break;
                }
            }
            return requestedNode;
        }

        private void RecreateTree()
        {
            BeginUpdate();
            try
            {
                foreach (DocumentInspectorTreeNode node in Nodes)
                {
                    node.RaiseNodeRemoved();
                }
                Nodes.Clear();
                // add all open documents
                foreach (Document document in Application.Documents)
                {
                    AddDocument(document);
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        void RefreshAllNodeText()
        {
            foreach (DocumentInspectorTreeNode node in Nodes)
            {
                node.RefreshText(true);
            }
        }
    }
}
