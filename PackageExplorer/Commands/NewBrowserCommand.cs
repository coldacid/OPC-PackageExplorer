using System;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Commands
{
    class NewBrowserCommand
        : CommandBase
    {
        public NewBrowserCommand()
            : base("PackageExplorer.NewBrowser")
        {
        }

        public override void Execute()
        {
            WorkbenchService workbenchService =
                ServiceManager.GetService<WorkbenchService>();
            IWindow window = workbenchService.Open(
                new Uri("about:blank"));
            if (window != null)
            {
                window.Show();
            }
        }
    }
}
