using System;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Commands
{
    class SaveActiveDocumentTabsCommand
        : CommandBase
    {
        public SaveActiveDocumentTabsCommand()
            : base("Window.SaveActiveDocumentTabs")
        {
        }

        public override void Execute()
        {
            Document document = Application.ActiveDocument;
            if (document != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
                foreach (IWindow window in service.GetWindowsForDocument(document))
                {
                    WindowManager manager = service.GetWindowManager(window);
                    if (manager.IsReadOnly == false && manager.IsDirty == true)
                    {
                        manager.Save();
                    }
                }
            }
        }
    }
}
