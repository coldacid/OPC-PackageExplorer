using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.Core.Services;
using PackageExplorer.Services;

namespace PackageExplorer.Commands
{
    class ShowAboutDialogCommand
        : CommandBase
    {
        public ShowAboutDialogCommand()
            : base("Help.AboutDialog")
        {
        }

        public override void Execute()
        {
            IDialogService dialogService = ServiceManager.GetService<IDialogService>();
            dialogService.ShowDialog(new AboutDialog(), DialogButtons.Ok);
        }
    }
}
