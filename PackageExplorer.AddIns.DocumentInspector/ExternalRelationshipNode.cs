using System;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.Services;
using System.Text;

namespace PackageExplorer.AddIns.DocumentInspector
{
    public class ExternalRelationshipNode
        : DocumentInspectorTreeNode
    {
        ExternalRelationship _externalRelationship = null;
        ExternalRelationshipCollection _container = null;

        public ExternalRelationship ExternalRelationship
        {
            get { return _externalRelationship; }
        }

        public override string ContextMenuTreePath
        {
            get { return "/workspace/documentInspector/toolStrips/externalRelationshipContextStrip"; }
        }

        public ExternalRelationshipNode(ExternalRelationship externalRelationship,
            ExternalRelationshipCollection container)
        {
            _externalRelationship = externalRelationship;
            _container = container;
            Tag = externalRelationship;
        }

        protected override string CreateNodeText()
        {
            StringBuilder text = new StringBuilder();
            if (TreeView != null)
            {
                if ((TreeView.DisplayMode & DisplayModes.Relationships) == DisplayModes.Relationships)
                {
                    text.Append(_container.GetRelationshipID(_externalRelationship) + " - ");
                }
            }
            text.Append(_externalRelationship.TargetUri.ToString());
            return text.ToString();
        }

        public override object GetSelectionObject()
        {
            return _externalRelationship;
        }

        public override void PerformAfterSelect()
        {
        }

        public override void PerformNodeAction()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.Open(_externalRelationship.TargetUri);
            if (window != null)
            {
                window.Show();
            }
        }
    }
}
