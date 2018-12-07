using System;
using PackageExplorer.Core.Services;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;

namespace PackageExplorer.Services
{
    public interface IDialogService
        : IService
    {
        DialogResult ShowDialog(DialogContent content, DialogButtons buttons);
    }
}
