using System;

namespace PackageExplorer.UI.Workbench
{
    public interface ISupportEditing
    {
        void Cut();
        void Copy();
        void Paste();
        void SelectAll();
    }
}
