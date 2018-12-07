using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;
using System.Collections.Generic;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Commands
{
    class CloseAllButActiveCommand
        : CommandBase
    {
        public CloseAllButActiveCommand()
            : base("Window.CloseAllButActive")
        {
        }

        public override void Execute()
        {
            IWindow activeTab = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow;
            if (activeTab != null)
            {
                List<IWindow> tabs = new List<IWindow>();
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                
                foreach (IWindow window in service.DocumentWindows)
                {
                    tabs.Add(window);
                }
                foreach (IWindow window in tabs)
                {
                    if (window != activeTab)
                    {
                        window.Close();
                    }
                }
            }
        }
    }
}
