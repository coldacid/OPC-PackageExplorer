using System;
using System.Windows.Forms;

namespace PackageExplorer.UI.Workbench
{
    class ContentExplorerWrapper 
        : IContentExplorer
    {
        Guid _explorerID;
        Control _control = null;

        public WindowKind WindowKind
        {
            get { return WindowKind.ToolWindow; }
        }

        public Guid ExplorerID
        {
            get { return _explorerID; }
        }

        public Control EditingControl
        {
            get { return _control; }
        }

        public ContentExplorerWrapper(Guid explorerID, Control control)
        {
            _explorerID = explorerID;
            _control = control;
        }
    }
}
