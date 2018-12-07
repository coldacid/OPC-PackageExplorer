using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;
using System.Collections.Generic;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Commands
{
    class CloseAllTabsCommand
        : CommandBase
    {
        public CloseAllTabsCommand()
            : base("Window.CloseAll")
        {
        }

        public override void Execute()
        {
            List<IWindow> tabs = new List<IWindow>();
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            foreach (IWindow window in service.DocumentWindows)
            {
                tabs.Add(window);
            }
            foreach(IWindow window in tabs)
            {
                window.Close();
            }
        }
    }
}
