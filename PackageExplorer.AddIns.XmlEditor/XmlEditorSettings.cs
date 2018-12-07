using System;
using System.Configuration;

namespace PackageExplorer.AddIns.XmlEditor
{
    class XmlEditorSettings
        : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool FormatXmlOnOpen
        {
            get { return (bool)this["FormatXmlOnOpen"]; }
            set { this["FormatXmlOnOpen"] = value; }
        }
    }
}
