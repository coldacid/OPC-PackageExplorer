using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Commands
{
    class SaveTabCommand
        : CommandBase
    {
        public SaveTabCommand()
            : base("Window.SaveActiveTab")
        {
        }

        public override void Execute()
        {
            IWindow window = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow;
            if (window != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                WindowManager manager = service.GetWindowManager(window);
                if (manager.IsReadOnly == false && manager.IsDirty == true)
                {
                    manager.Save();
                }
            }
        }
    }
}
