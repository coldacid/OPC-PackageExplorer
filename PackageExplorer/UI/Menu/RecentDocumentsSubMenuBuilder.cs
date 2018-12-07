using System;
using System.Collections.Generic;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using System.IO;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.UI.Menu
{
    class RecentDocumentsSubMenuBuilder
        : ISubMenuBuilder
    {
        public IEnumerable<ToolStripMenuItem> BuildSubMenu()
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            IRecentDocumentService service = ServiceManager.GetService<IRecentDocumentService>();
            int count = 1;
            foreach (string path in service)
            {
                string title = String.Format("{0} {1}",
                    count++, Path.GetFileName(path));
                items.Add(new ToolStripMenuItem(
                    title, new OpenRecentDocumentCommand(path)));
            }
            return items;
        }

        class OpenRecentDocumentCommand : IMenuCommand
        {
            string _path =null;

            public string Name
            {
                get { return "OpenRecentDocument"; }
            }

            public OpenRecentDocumentCommand(string path)
            {
                _path = path;
            }

            public void Execute()
            {
                IRecentDocumentService service = ServiceManager.GetService<IRecentDocumentService>();
                service.OpenRecentDocument(_path);
            }
        }
    }
}
