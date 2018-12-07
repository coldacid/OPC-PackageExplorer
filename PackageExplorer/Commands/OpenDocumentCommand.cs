using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Core;
using System.Windows.Forms;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Utils;
using Application = PackageExplorer.ObjectModel.Application;
using System.IO;
using PackageExplorer.Services;
using PackageExplorer.ObjectModel;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Dialogs;

namespace PackageExplorer.Commands
{
    class OpenDocumentCommand
        : CommandBase
    {
        public OpenDocumentCommand()
            : base("File.OpenDocument")
        {
        }

        public override void Execute()
        {
            string[] filenames = null;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Filter = FileFilters.BuildFileFilter();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filenames = dialog.FileNames;
                }
            }
            if (filenames != null)
            {
                IDialogService dialogService = ServiceManager.GetService<IDialogService>();
                ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
                EnvironmentSettings settings = settingsService.GetSettings<EnvironmentSettings>();
                bool showDialog = settings.ShowPackagingErrorsOnDocumentOpen;

                foreach (string path in filenames)
                {
                    try
                    {
                        Document document = Application.Documents.Open(
                            path);
                        if (document != null && document.PackagingErrors.Count > 0)
                        {
                            if (showDialog)
                            {
                                dialogService.ShowDialog(
                                    new PackagingErrorsDialog() 
                                    { 
                                        Document = document 
                                    }, DialogButtons.Ok);
                            }
                        }
                    }
                    catch(IOException e)
                    {
                        MessageBox.Show(e.Message,
                            System.Windows.Forms.Application.ProductName);
                    }
                }
            }
        }
    }
}
