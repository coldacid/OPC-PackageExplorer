using System;
using PackageExplorer.UI.Menu;
using System.Collections.Generic;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;

namespace PackageExplorer.AddIns.ValidationInspector
{
    public class ValidationPackageComboBoxBuilder
        : IComboBoxBuilder
    {
        public IEnumerable<ToolStripComboBoxItem> BuildComboBox()
        {
            ISettingsService settingsService =
                ServiceManager.GetService<ISettingsService>();
            IValidationService validationService =
                ServiceManager.GetService<IValidationService>();
            ValidationSettings settings = settingsService.GetSettings<ValidationSettings>();
            foreach (string validationPackage in validationService.ValidationPackages)
            {
                ToolStripComboBoxItem menuItem = new ToolStripComboBoxItem();
                menuItem.Title = validationPackage;
                menuItem.Command = new SelectValidationPackageCommand()
                {
                    ValidationPackage = validationPackage,
                    ValidationSettings = settings
                };
                yield return menuItem;
            }
        }

        class SelectValidationPackageCommand
            : ICommand
        {
            public string ValidationPackage { get; set; }
            public ValidationSettings ValidationSettings { get; set; }

            public string Name
            {
                get { return "SelectValidationPackage"; }
            }

            public void Execute()
            {
                ValidationSettings.ActiveValidationPackage = ValidationPackage;        
            }
        }
    }
}
