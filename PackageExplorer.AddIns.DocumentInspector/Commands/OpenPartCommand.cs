using System;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Commands;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class OpenPartCommand
        : CommandBase
    {
        public OpenPartCommand()
            : base("DocumentInspector.OpenPart")
        {
        }

        public override void Execute()
        {
            WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
            IWindow inspectorWindow = workbenchService.GetWindow(DocumentInspectorControl.ID);
            DocumentInspectorControl control = (DocumentInspectorControl)inspectorWindow.WindowControl;
            DocumentPartNode partNode = control.SelectedNode as DocumentPartNode;
            if (partNode != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                IWindow partWindow = service.Open(partNode.DocumentPart);
                if (partWindow != null)
                {
                    partWindow.Show();
                }
            }
        }
    }
}
