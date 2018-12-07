using System;
using PackageExplorer.Core;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class ViewDocumentInspectorCommand
        : ICommand
    {
        public string Name
        {
            get { return "View.DocumentInspector"; }
        }

        public ViewDocumentInspectorCommand()
        {
        }

        public void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(DocumentInspectorControl.ID);
            window.Show();
        }
    }
}
