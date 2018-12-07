using System;
using PackageExplorer.Core;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.PropertyInspector
{
    class ViewPropertyInspectorCommand
        : ICommand
    {
        public string Name
        {
            get { return "View.PropertyInspector"; }
        }

        public void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(PropertyInspectorControl.EditorID);
            window.Show();
        }
    }
}
