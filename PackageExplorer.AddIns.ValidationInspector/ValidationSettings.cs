using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.Collections;

namespace PackageExplorer.AddIns.ValidationInspector
{
    class ValidationSettings
        : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool ShowInformationMessages
        {
            get { return (bool)this["ShowInformationMessages"]; }
            set { this["ShowInformationMessages"] = value; }
        }

        [UserScopedSetting]
        public StringCollection CustomSchemaPaths
        {
            get { return (StringCollection)this["CustomSchemaPaths"]; }
            set { this["CustomSchemaPaths"] = value; }
        }

        [UserScopedSetting]
        public string ActiveValidationPackage
        {
            get { return (string)this["ActiveValidationPackage"]; }
            set { this["ActiveValidationPackage"] = value; }
        }
    }
}
