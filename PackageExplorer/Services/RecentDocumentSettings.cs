using System;
using System.Configuration;
using System.Collections.Specialized;

namespace PackageExplorer.Services
{
    class RecentDocumentSettings
        : ApplicationSettingsBase
    {
        [UserScopedSetting]
        public StringCollection RecentDocuments
        {
            get
            {
                StringCollection items = (StringCollection)this["RecentDocuments"];
                if (items == null)
                {
                    items = new StringCollection();
                    RecentDocuments = items;
                }
                return items;
            }
            set { this["RecentDocuments"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("10")]
        public int MaxNrRecentDocuments
        {
            get { return (int)this["MaxNrRecentDocuments"]; }
            set 
            {
                if (value < 0)
                {
                    this["MaxNrRecentDocuments"] = 0;
                }
                else
                {
                    this["MaxNrRecentDocuments"] = value;
                }
                TrimListToSize(MaxNrRecentDocuments);
            }
        }

        public void TrimListToSize(int size)
        {
            if (RecentDocuments.Count > size)
            {
                while (RecentDocuments.Count > size)
                {
                    RecentDocuments.RemoveAt(RecentDocuments.Count - 1);
                }
            }
        }
    }
}
