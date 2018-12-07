using System;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;
using PackageExplorer.Core.Services;

namespace PackageExplorer.StartPage
{
    class ShowStartPageCommand
        : CommandBase
    {
        public ShowStartPageCommand()
            : base("Environment.ShowStartPage")
        {
        }

        public override void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.CreateInspectorWindow(
                new ContentExplorer(), "Start Page", null);
            if (window != null)
            {
                window.Show();
            }
        }
    }
}
