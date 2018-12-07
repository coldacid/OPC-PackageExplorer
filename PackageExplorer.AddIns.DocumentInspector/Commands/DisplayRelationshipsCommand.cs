using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.UI.Menu;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class DisplayRelationshipsCommand
        : ICommand, ICheckableMenuCommand
    {
        public bool IsChecked
        {
            get
            {
                ISettingsService service = ServiceManager.GetService<ISettingsService>();
                DocumentInspectorSettings settings = service.GetSettings<DocumentInspectorSettings>();
                return (settings.DisplayMode & DisplayModes.Relationships) == DisplayModes.Relationships;
            }
        }

        public string Name
        {
            get { return "DocumentInspector.DisplayRelationships"; }
        }

        public DisplayRelationshipsCommand()
        {

        }

        public void Execute()
        {
            ISettingsService service = ServiceManager.GetService<ISettingsService>();
            DocumentInspectorSettings settings = service.GetSettings<DocumentInspectorSettings>();
            settings.DisplayMode ^= DisplayModes.Relationships;
        }
    }
}
