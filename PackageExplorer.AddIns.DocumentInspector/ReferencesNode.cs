using System;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.AddIns.DocumentInspector
{
    public class ReferencesNode
        : DocumentInspectorTreeNode
    {
        ExternalRelationshipCollection _externalRelationships = null;
        DocumentInspectorTreeNode _parent = null;

        public override string ContextMenuTreePath
        {
            get { return "/workspace/documentInspector/toolStrips/referencesContextStrip"; }
        }

        public ReferencesNode(ExternalRelationshipCollection externalRelationships,
             DocumentInspectorTreeNode parent)
        {
            _externalRelationships = externalRelationships;
            Tag = _externalRelationships;
            _externalRelationships.ItemAdded += ExternalRelationships_ItemAdded;
            _externalRelationships.ItemRemoved += ExternalRelationships_ItemRemoved;
            _parent = parent;
        }

        protected override void OnNodeRemoved()
        {
            _externalRelationships.ItemAdded -= ExternalRelationships_ItemAdded;
            _externalRelationships.ItemRemoved -= ExternalRelationships_ItemRemoved;
        }

        protected override void CreateChildNodes()
        {
            foreach (ExternalRelationship externalRelationship in _externalRelationships)
            {
                AddExternalRelationshipNode(externalRelationship, _externalRelationships);
            }
            ChildNodesCreated = true;
        }

        protected override string CreateNodeText()
        {
            return "References";
        }

        void AddExternalRelationshipNode(ExternalRelationship externalRelationship,
            ExternalRelationshipCollection container)
        {
            ExternalRelationshipNode node = new ExternalRelationshipNode(externalRelationship, container);
            node.RefreshText(false);
            EnsuredNodes.Add(node);
            if (Parent == null)
            {
                _parent.EnsuredNodes.Insert(0, this);
                RefreshText(true);
            }
        }

        void RemoveExternalRelationshipNode(ExternalRelationship externalRelationship)
        {
            ExternalRelationshipNode node = (ExternalRelationshipNode)FindDocumentPartNode(
                delegate(DocumentInspectorTreeNode searchNode)
                {
                    ExternalRelationshipNode externalNode = searchNode as ExternalRelationshipNode;
                    return externalNode != null && externalNode.ExternalRelationship == externalRelationship;
                });
            if (node != null)
            {
                EnsuredNodes.Remove(node);
                if (Nodes.Count == 0)
                {
                    Parent.Nodes.Remove(this);
                }
            }
        }

        void ExternalRelationships_ItemAdded(object sender, ExternalRelationshipEventArgs e)
        {
            AddExternalRelationshipNode(e.ExternalRelationship, (ExternalRelationshipCollection)sender);
        }

        void ExternalRelationships_ItemRemoved(object sender, ExternalRelationshipEventArgs e)
        {
            RemoveExternalRelationshipNode(e.ExternalRelationship);
        }
    }
}
