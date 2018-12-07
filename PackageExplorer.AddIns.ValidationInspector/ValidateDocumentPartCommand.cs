
using System;
using PackageExplorer.Core;
using PackageExplorer.Core.Services;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.ObjectModel;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.AddIns.ValidationInspector
{
    class ValidateDocumentPartCommand
        : ICommand
    {
        public string Name
        {
            get { return "ValidationInspector.ValidatePart"; }
        }

        public ValidateDocumentPartCommand()
        {
        }

        public void Execute()
        {
            WorkbenchService service = ServiceManager.GetService<WorkbenchService>();
            IWindow window = service.GetWindow(ValidationInspectorControl.ID);
            window.Show();
            System.Windows.Forms.Application.DoEvents();

            Document document = Application.ActiveDocument;
            if (document != null)
            {
                DocumentPart internalPart = document.ActivePart;
                if (internalPart != null)
                {
                    IValidationService validationService = (IValidationService)
                        ServiceManager.Services[typeof(IValidationService)];
                    validationService.Validate(internalPart);
                }
            }
        }
    }
}
