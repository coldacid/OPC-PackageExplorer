using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace PackageExplorer.UI.Workbench
{
    public class FontSettings
        : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("Consolas")]
        public string FontName
        {
            get { return (string)this["FontName"]; }
            set { this["FontName"] = value; }
        }


        [UserScopedSetting]
        [DefaultSettingValue("10")]
        public int FontSize
        {
            get { return (int)this["FontSize"]; }
            set { this["FontSize"] = value; }
        }
    }
}
