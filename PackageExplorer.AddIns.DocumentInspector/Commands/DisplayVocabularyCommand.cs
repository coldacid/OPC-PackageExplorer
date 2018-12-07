using System;
using PackageExplorer.Core;
using PackageExplorer.Core.Services;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.UI.Menu;
using PackageExplorer.Services;

namespace PackageExplorer.AddIns.DocumentInspector.Commands
{
    class DisplayVocabularyCommand
        : ICommand, ICheckableMenuCommand
    {
        public bool IsChecked
        {
            get
            {
                ISettingsService service = (ISettingsService)ServiceManager.Services[typeof(ISettingsService)];
                DocumentInspectorSettings settings = service.GetSettings<DocumentInspectorSettings>();
                return (settings.DisplayMode & DisplayModes.Vocabulary) == DisplayModes.Vocabulary;
            }
        }

        public string Name
        {
            get { return "DocumentInspector.DisplayVocabulary"; }
        }

        public void Execute()
        {
            ISettingsService service = (ISettingsService)ServiceManager.Services[typeof(ISettingsService)];
            DocumentInspectorSettings settings = service.GetSettings<DocumentInspectorSettings>();
            settings.DisplayMode ^= DisplayModes.Vocabulary;
        }
    }
}
