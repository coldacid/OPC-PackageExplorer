using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.Services;
using PackageExplorer.Services;
using PackageExplorer.UI.Dialogs;
using System.Windows.Forms;

namespace PackageExplorer.Commands
{
    class ShowOptionsDialogCommand
        : CommandBase
    {
        public ShowOptionsDialogCommand()
            : base("Application.Options")
        {

        }

        public override void Execute()
        {
            IDialogService dialogService = ServiceManager.GetService<IDialogService>();
            OptionsDialog dialog = new OptionsDialog();
            if (dialogService.ShowDialog(dialog, DialogButtons.Ok | DialogButtons.Cancel) == DialogResult.OK)
            {
                dialog.SaveChanges();
            }
        }
    }
}
