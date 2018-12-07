using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class CopyRelationshipIDCommand
       : ICommand
    {
        public string Name
        {
            get { return "DocumentInspector.CopyRelationshipID"; }
        }

        public void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)window.WindowControl;
            DocumentPartNode partNode = control.SelectedNode as DocumentPartNode;
            if (partNode != null)
            {
                string relationshipID = partNode.RelationshipID;
                Clipboard.SetText(relationshipID);
            }
        }
    }
}
