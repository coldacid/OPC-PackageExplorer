using System;
using System.Configuration;

namespace PackageExplorer.UI.Workbench
{
    public class EnvironmentSettings
        : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool ShowPackagingErrorsOnDocumentOpen
        {
            get { return (bool)this["ShowPackagingErrorsOnDocumentOpen"]; }
            set { this["ShowPackagingErrorsOnDocumentOpen"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool ShowStartPageOnApplicationStart
        {
            get { return (bool)this["ShowStartPageOnApplicationStart"]; }
            set { this["ShowStartPageOnApplicationStart"] = value; }
        }
    }
}
