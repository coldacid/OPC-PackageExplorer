using System;
using PackageExplorer.Core;
using System.Security.Cryptography.X509Certificates;
using PackageExplorer.Core.Services;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Commands;
using PackageExplorer.UI.Dialogs;
using System.Windows.Forms;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class ViewSignaturesCommand
        : CommandBase
    {
        public ViewSignaturesCommand()
            : base("DocumentInspector.ViewSignatures")
        {

        }

        public override void Execute()
        {           
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IWindow inspectorWindow = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl inspectorControl = (DocumentInspectorControl)inspectorWindow.WindowControl;
            DocumentNode documentNode = inspectorControl.SelectedNode as DocumentNode;
            if (documentNode != null)
            {
                IDialogService service = ServiceManager.GetService<IDialogService>();
                service.ShowDialog(new SignaturesDialog() { Document = documentNode.Document }, DialogButtons.Ok);
            }
        }
    }
}
