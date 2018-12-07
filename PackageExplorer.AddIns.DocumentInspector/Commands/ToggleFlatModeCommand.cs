using System;
using PackageExplorer.Commands;
using PackageExplorer.UI.Menu;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class ToggleFlatModeCommand
        : CommandBase, ICheckableMenuCommand
    {
        public bool IsChecked
        {
            get
            {
                ISettingsService service = ServiceManager.GetService<ISettingsService>();
                DocumentInspectorSettings settings = service.GetSettings<DocumentInspectorSettings>();
                return settings.FlatMode;
            }
        }

        public ToggleFlatModeCommand()
            : base("DocumentInspector.ToggleFlatMode")
        {
        }

        public override void Execute()
        {
            ISettingsService service = ServiceManager.GetService<ISettingsService>();
            DocumentInspectorSettings settings = service.GetSettings<DocumentInspectorSettings>();
            settings.FlatMode = !settings.FlatMode;
        }
    }
}
