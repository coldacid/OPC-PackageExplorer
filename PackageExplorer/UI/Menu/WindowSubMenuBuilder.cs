using System;
using System.Collections.Generic;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.UI.Menu
{
    class WindowSubMenuBuilder
        : ISubMenuBuilder
    {
        public IEnumerable<ToolStripMenuItem> BuildSubMenu()
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            int count = 1;
            foreach (IWindow window in service.DocumentWindows)
            {
                items.Add(new CheckableToolStripMenuItem(
                   String.Format("{0} {1}", count++, window.Text), new ShowTabCommand(window)));
            }
            return items;
        }

        class ShowTabCommand : ICheckableMenuCommand
        {
            IWindow _window;

            public bool IsChecked
            {
                get { return WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow == _window; }
            }

            public string Name
            {
                get { return "Show Tab"; }
            }

            public ShowTabCommand(IWindow window)
            {
                _window = window;
            }

            public void Execute()
            {
                _window.Show();
            }
        }
    }
}
