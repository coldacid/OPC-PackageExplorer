using System;
using System.Windows.Forms;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.Commands
{
    class OpenFileCommand
        : CommandBase
    {
        public OpenFileCommand()
            : base("File.OpenFile")
        {
        }

        public override void Execute()
        {
            string[] filenames = null;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filenames = dialog.FileNames;
                }
            }
            if (filenames != null)
            {
                WorkbenchService service = ServiceManager.GetService<WorkbenchService>();                
                foreach (string path in filenames)
                {
                    IWindow window = service.Open(path);
                    if (window != null)
                    {
                        window.Show();
                    }
                }
            }

        }
    }
}
