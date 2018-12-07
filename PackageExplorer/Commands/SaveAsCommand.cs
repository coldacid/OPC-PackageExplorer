using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Core;
using System.IO;
using System.Windows.Forms;
using Application = PackageExplorer.ObjectModel.Application;
using PackageExplorer.Utils;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.Commands
{
    class SaveAsCommand
        : CommandBase
    {
        public SaveAsCommand()
            : base("File.SaveAs")
        {
        }


        public override void Execute()
        {
            Document document = Application.ActiveDocument;
            if (document != null)
            {
                Application.SaveAs(document);
            }
        }
    }
}