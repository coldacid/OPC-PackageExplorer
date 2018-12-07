using System;
using System.Configuration;
using System.Collections.Specialized;

namespace PackageExplorer.UI.Workbench
{
    class EditorSettings
        : ApplicationSettingsBase
    {
        [UserScopedSetting]
        public DefaultEditorCollection DefaultEditors
        {
            get { return (DefaultEditorCollection)this["DefaultEditors"]; }
            set { this["DefaultEditors"] = value; }
        }

        public EditorSettings()
        {
        }
    }
}
