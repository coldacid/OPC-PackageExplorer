using System;
using PackageExplorer.Core;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.ValidationInspector
{
    class ViewValidationInspectorCommand
        : ICommand
    {
        public string Name
        {
            get { return "View.ValidationInspector"; }
        }

        public ViewValidationInspectorCommand()
        {
        }

        public void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(ValidationInspectorControl.ID);
            window.Show();
        }
    }
}
