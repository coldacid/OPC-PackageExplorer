using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace PackageExplorer.UI.Workbench.Default
{
    class WorkbenchSettings
        : ApplicationSettingsBase
    {
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point WindowLocation
        {
            get
            {
                return ((global::System.Drawing.Point)(this["WindowLocation"]));
            }
            set
            {
                this["WindowLocation"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Normal")]
        public global::System.Windows.Forms.FormWindowState WindowState
        {
            get
            {
                return ((global::System.Windows.Forms.FormWindowState)(this["WindowState"]));
            }
            set
            {
                this["WindowState"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CenterScreen")]
        public global::System.Windows.Forms.FormStartPosition WindowStartPosition
        {
            get
            {
                return ((global::System.Windows.Forms.FormStartPosition)(this["WindowStartPosition"]));
            }
            set
            {
                this["WindowStartPosition"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("800, 600")]
        public global::System.Drawing.Size WindowSize
        {
            get
            {
                return ((global::System.Drawing.Size)(this["WindowSize"]));
            }
            set
            {
                this["WindowSize"] = value;
            }
        }
    }
}
