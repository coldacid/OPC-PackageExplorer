using System;

namespace PackageExplorer.UI.Menu
{
    public interface ICheckableMenuCommand
        : IMenuCommand
    {
        bool IsChecked { get;}
    }
}
