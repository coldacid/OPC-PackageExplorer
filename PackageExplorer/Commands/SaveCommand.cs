using System;
using PackageExplorer.Core;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.Commands
{
    class SaveCommand
        : CommandBase
    {
        public SaveCommand()
            : base("File.Save")
        {
        }

        public override void Execute()
        {
            if (Application.ActiveDocument != null)
            {
                Application.Commands["Window.SaveActiveDocumentTabs"].Execute();
                Application.Save(Application.ActiveDocument);
            }
        }
    }
}
