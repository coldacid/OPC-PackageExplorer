using System;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;

namespace PackageExplorer.AddIns.AddInScout
{
    class ContentExplorer
        : IContentExplorer
    {
        AddInScout _scout = null;

        public Control EditingControl
        {
            get { return _scout; }
        }

        public WindowKind WindowKind
        {
            get { return WindowKind.DocumentWindow; }
        }

        public Guid ExplorerID
        {
            get { return new Guid("{E3597405-C57F-4ddd-AAB8-22078A91EE68}"); }
        }

        public ContentExplorer()
        {
            _scout = new AddInScout();
        }
    }
}
