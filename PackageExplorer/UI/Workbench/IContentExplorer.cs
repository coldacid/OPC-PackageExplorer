using System;
using System.Windows.Forms;

namespace PackageExplorer.UI.Workbench
{
    public interface IContentExplorer
    {
        WindowKind WindowKind { get;}
        Guid ExplorerID { get;}
        Control EditingControl { get;}
    }
}
