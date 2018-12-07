using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Commands
{
    class PasteCommand
        : CommandBase
    {
        public PasteCommand()
            : base("Edit.Paste")
        {
        }

        public override void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            WindowManager mgr = service.GetWindowManager(service.DefaultWorkbench.ActiveDocumentWindow);
            ISupportEditing editor = (ISupportEditing)mgr.Editor;
            editor.Paste();
        }
    }
}
