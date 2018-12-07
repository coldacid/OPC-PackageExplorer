using System;
using System.Configuration;

namespace PackageExplorer.AddIns.DocumentInspector
{
    class DocumentInspectorSettings
        : ApplicationSettingsBase
    {
        [UserScopedSetting,
        DefaultSettingValue("Normal")]
        public DisplayModes DisplayMode
        {
            get { return (DisplayModes)this["DisplayMode"]; }
            set { this["DisplayMode"] = value; }
        }

        [UserScopedSetting,
        DefaultSettingValue("false")]
        public bool FlatMode
        {
            get { return (bool)this["FlatMode"]; }
            set { this["FlatMode"] = value; }
        }
    }
}
