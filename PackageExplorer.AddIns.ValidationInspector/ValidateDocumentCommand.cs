using System;
using PackageExplorer.Core;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;

namespace PackageExplorer.AddIns.ValidationInspector
{
    class ValidateDocumentCommand
        : ICommand
    {
        public string Name
        {
            get { return "ValidationInspector.ValidateDocument"; }
        }

        public ValidateDocumentCommand()
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
                IValidationService validationService = (IValidationService)
                    ServiceManager.Services[typeof(IValidationService)];
                validationService.Validate(document);
            }            
        }
    }
}
