using System;
using System.Configuration;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.UI.Workbench
{
    class FirstTimeStartup
    {
        static bool _isFirstTime = false;

        public static bool IsFirstTimeStartup
        {
            get { return _isFirstTime; }
        }
        
        static FirstTimeStartup()
        {
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            FirstTimeStartupSettings settings =
                settingsService.GetSettings<FirstTimeStartupSettings>();
            _isFirstTime = settings.IsFirstTimeStartup;
            Application.Exiting += delegate(object sender, EventArgs e)
            {
                settings.IsFirstTimeStartup = false;
            };
        }

        public class FirstTimeStartupSettings
            : ApplicationSettingsBase
        {
            [UserScopedSetting]
            [DefaultSettingValue("true")]
            public bool IsFirstTimeStartup
            {
                get { return (bool)this["IsFirstTimeStartup"]; }
                set { this["IsFirstTimeStartup"] = value; }
            }
        }
    }
}
