using System;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.AddIns.ValidationInspector
{
    class ClearCommand
        : CommandBase
    {
        public ClearCommand()
            : base("ValidationInspector.Clear")
        {
        }

        public override void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(ValidationInspectorControl.ID);
            ValidationInspectorControl control = (ValidationInspectorControl)window.WindowControl;
            control.Clear();
        }
    }
}
