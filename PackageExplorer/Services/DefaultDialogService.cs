using System;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Services
{
    class DefaultDialogService
        : ServiceBase, IDialogService
    {
        public DialogResult ShowDialog(DialogContent content, DialogButtons buttons)
        {
            DialogWindow dialog = new DialogWindow(content, buttons);
            dialog.StartPosition = FormStartPosition.CenterScreen;
            return dialog.ShowDialog();
        }
    }
}
