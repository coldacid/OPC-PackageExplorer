using System;
using System.Configuration;
using System.Collections.Specialized;

namespace PackageExplorer.StartPage
{
    class RSSSettings
        : ApplicationSettingsBase
    {
        const string WoutersFeed = "http://blogs.code-counsel.net/Wouter/_layouts/listfeed.aspx?List={C04A88A9-D138-4AC3-A2BB-B95C9FDD114E}";
        const string DougsFeed = "http://blogs.msdn.com/dmahugh/rss.xml";
        const string OpenXMLFeed = "http://openxmldeveloper.org/rss.aspx";
        
        [UserScopedSetting]
        public StringCollection RSSFeeds
        {
            get
            {
                StringCollection items = (StringCollection)this["RSSFeeds"];
                if (items == null)
                {
                    items = new StringCollection();
                    items.Add(WoutersFeed);
                    items.Add(DougsFeed);
                    items.Add(OpenXMLFeed);
                    RSSFeeds = items;
                }
                return items;
            }
            set { this["RSSFeeds"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool QueryRSSAtStartup
        {
            get { return (bool)this["QueryRSSAtStartup"]; }
            set { this["QueryRSSAtStartup"] = value; }
        }
    
        [UserScopedSetting]
        [DefaultSettingValue("3")]
        public int MaxNrMessagesPerFeed
        {
            get { return (int)this["MaxNrMessagesPerFeed"]; }
            set { this["MaxNrMessagesPerFeed"] = value; }
        }    
    }
}
