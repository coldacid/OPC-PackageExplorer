using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Commands
{
    class CloseActiveTabCommand
        : CommandBase
    {
        public CloseActiveTabCommand()
            : base("Window.CloseActive")
        {
        }

        public override void Execute()
        {
            IWindow tab = WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow;
            if (tab != null)
            {
                tab.Close();
            }
        }
    }
}
