using System;
using PackageExplorer.Commands;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;
using PackageExplorer.Core.Services;

namespace PackageExplorer.StartPage
{
    class AutoShowStartPageCommand
        : CommandBase
    {
        public AutoShowStartPageCommand()
            : base("Environment.AutoShowStartPage")
        {
        }

        public override void Execute()
        {
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            EnvironmentSettings settings = settingsService.GetSettings<EnvironmentSettings>();
            if (settings.ShowStartPageOnApplicationStart)
            {
                new ShowStartPageCommand().Execute();
            }
        }
    }
}
