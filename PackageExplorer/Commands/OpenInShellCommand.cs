using System;
using PackageExplorer.Core;
using System.Diagnostics;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using System.Collections.Generic;

namespace PackageExplorer.Commands
{
    class OpenInShellCommand
        : CommandBase
    {
        public OpenInShellCommand()
            : base("Document.OpenInShell")
        {

        }

        public override void Execute()
        {
            Document document = Application.ActiveDocument;
            if (document != null)
            {
                bool hasDirtyEditors = false;
                bool documentRequiresSave = false;
                List<WindowManager> dirtyEditors = new List<WindowManager>();

                WorkbenchService workbenchService = ServiceManager.GetService<WorkbenchService>();
                foreach (IWindow editorWindow in workbenchService.GetWindowsForDocument(document))
                {
                    WindowManager manager = workbenchService.GetWindowManager(editorWindow);
                    if (manager.IsDirty)
                    {
                        hasDirtyEditors = true;
                        dirtyEditors.Add(manager);
                    }
                }
                foreach (WindowManager manager in dirtyEditors)
                {
                    manager.Save();
                }
                if (Application.TrySave(document) && document.IsSaved)
                {
                    ProcessStartInfo info = new ProcessStartInfo(
                    document.Path);
                    info.UseShellExecute = true;
                    Process.Start(info);
                }
            }
        }

        private void OpenInShell(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
