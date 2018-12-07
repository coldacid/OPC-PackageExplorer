using System;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class ViewRelationshipsCommand
        : CommandBase
    {
        public ViewRelationshipsCommand()
            : base("DocumentInspector.ViewRelationships")
        {
        }

        public override void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            RelationshipPart part = GetSelectedRelationshipPart();
            if (part != null)
            {
                IWindow window = service.Open(part);
                if (window != null)
                {
                    window.Show();
                }
            }
        }

        RelationshipPart GetSelectedRelationshipPart()
        {
            RelationshipPart part = null;
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            if (control.SelectedNode is DocumentNode)
            {
                part = ((DocumentNode)control.SelectedNode).Document.RelationshipPart;
            }
            else if (control.SelectedNode is DocumentPartNode)
            {
                part = ((DocumentPartNode)control.SelectedNode).DocumentPart.RelationshipPart;
            }
            return part;            
        }
    }
}
