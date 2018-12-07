using System;
using System.Windows.Forms;

namespace PackageExplorer.AddIns.DocumentInspector
{
    public class DocumentInspectorTreeNode
        : TreeNode
    {
        bool _childNodesCreated = false;
        bool _ensuringChildNodes = false;

        public virtual string ContextMenuTreePath
        {
            get { return null; }
        }

        public TreeNodeCollection EnsuredNodes
        {
            get
            {
                EnsureChildNodes();
                return Nodes;
            }
        }

        protected new DocumentInspectorControl TreeView
        {
            get { return (DocumentInspectorControl)base.TreeView; }
        }

        protected bool ChildNodesCreated
        {
            get { return _childNodesCreated; }
            set { _childNodesCreated = value; }
        }

        public void EnsureChildNodes()
        {
            if (_childNodesCreated == false && _ensuringChildNodes == false)
            {
                try
                {
                    _ensuringChildNodes = true;
                    CreateChildNodes();
                }
                finally
                {
                    _ensuringChildNodes = false;
                }
            }
        }

        public void RefreshText(bool refreshChildren)
        {
            Text = CreateNodeText();
            if (refreshChildren)
            {
                foreach (DocumentInspectorTreeNode node in Nodes)
                {
                    node.RefreshText(refreshChildren);
                }
            }
        }

        public virtual object GetSelectionObject()
        {
            return null;
        }

        protected virtual string CreateNodeText()
        {
            return null;
        }

        internal void RaiseNodeRemoved()
        {
            OnNodeRemoved();
            foreach (DocumentInspectorTreeNode node in Nodes)
            {
                node.RaiseNodeRemoved();
            }
        }

        protected virtual void OnNodeRemoved()
        {
        }

        protected virtual void CreateChildNodes()
        {
            _childNodesCreated = true;
        }

        protected DocumentInspectorTreeNode FindDocumentPartNode(
            Predicate<DocumentInspectorTreeNode> predicate)
        {
            DocumentInspectorTreeNode requestedNode = null;
            foreach (DocumentInspectorTreeNode node in EnsuredNodes)
            {
                if (predicate(node))
                {
                    requestedNode = node;
                    break;
                }
            }
            return requestedNode;
        }

        public virtual void PerformAfterSelect()
        {
        }

        public virtual void PerformNodeAction()
        {
        }
    }
}
