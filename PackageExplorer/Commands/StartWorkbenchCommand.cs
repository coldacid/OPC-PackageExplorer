using System;
using System.Windows.Forms;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Commands
{
    class StartWorkbenchCommand
        : CommandBase
    {
        public StartWorkbenchCommand()
            : base("Application.Start")
        {
        }
         
        public override void Execute()
        {
            WorkbenchSingleton.DefaultWorkbench.Show();
            Application.Run();
        }
    }
}
