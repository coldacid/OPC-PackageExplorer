using System;
using PackageExplorer.Core;
using PackageExplorer.UI.Workbench;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.Commands
{
    class CloseDocumentCommand
        : CommandBase
    {
        public CloseDocumentCommand()
            : base("File.Close")
        {

        }

        public override void Execute()
        {
            if (Application.ActiveDocument != null)
            {
                Application.ActiveDocument.Close();
            }
        }
    }
}
