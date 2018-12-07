using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.ObjectModel;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Security;
using System.Xml;
using System.Windows.Forms;
using System.ComponentModel;

namespace PackageExplorer.StartPage
{
    [ComVisible(true)]
    public class ScriptProxy
    {
        IRecentDocumentService _service;
        RSSSettings _rssSettings = null;
        WebBrowser _webBrowser = null;

        IRecentDocumentService RecentDocumentService
        {
            get
            {
                if (_service == null)
                {
                    _service = ServiceManager.GetService<IRecentDocumentService>();
                }
                return _service;
            }
        }

        RSSSettings RSSSettings
        {
            get
            {
                if(_rssSettings == null)
                {
                    ISettingsService settingsService = 
                        ServiceManager.GetService<ISettingsService>();
                    _rssSettings= settingsService.GetSettings<RSSSettings>();
                }
                return _rssSettings;
            }
        }

        public ScriptProxy(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
        }

        public void ExecuteCommand(string commandName)
        {
            ICommand command = PackageExplorer.ObjectModel.Application.Commands[commandName];
            if (command != null)
            {
                command.Execute();
            }
        }

        public void OpenRecentDocument(string path)
        {
            RecentDocumentService.OpenRecentDocument(path);
        }

        public int GetRecentDocumentCount()
        {
            return RecentDocumentService.Count;
        }

        public string GetRecentDocumentTitle(int index)
        {
            return Path.GetFileName(RecentDocumentService[index]);
        }

        public string GetRecentDocumentPath(int index)
        {
            return RecentDocumentService[index];
        }

        public void BeginFeedGathering()
        {
            int maxMesagesPerFeed = RSSSettings.MaxNrMessagesPerFeed;
            foreach (string feed in RSSSettings.RSSFeeds)
            {
                BackgroundWorker worker = new BackgroundWorker();
                RSSHandler handler = new RSSHandler(feed);
                worker.DoWork +=
                    delegate(object sender, DoWorkEventArgs e)
                    {
                        e.Result = handler.GetMessages(maxMesagesPerFeed);
                    };
                worker.RunWorkerCompleted +=
                    delegate(object sender, RunWorkerCompletedEventArgs e)
                    {
                        if (e.Result != null)
                        {
                            foreach (RSSMessage message in (IEnumerable<RSSMessage>)e.Result)
                            {
                                _webBrowser.Document.InvokeScript(
                                    "CreateRSSMessage",
                                    new object[]
                                {
                                    message.Title,
                                    message.HRef,
                                    String.Format(
                                        "Published to {0} on {1}",
                                        message.BlogName, message.Date)
                                });
                            }
                        }
                    };
                worker.RunWorkerAsync();
            }
        }

        public enum HandlerState
        {
            Stopped,
            Running,
            Completed,
            CompletedError
        }

        class RSSHandler
        {
            string _feed = null;
            string _blogName = null;

            public string BlogName
            {
                get
                {
                    return _blogName;
                }
                private set
                {
                    _blogName = value;
                }
            }

            public RSSHandler(string feed)
            {
                _feed = feed;
            }

            public IEnumerable<RSSMessage> GetMessages(int maxMessages)
            {
                try
                {
                    HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(_feed);
                    webRequest.Timeout = 5000;
                    XmlDocument document = null;
                    using (WebResponse webResponse = webRequest.GetResponse())
                    {
                        if (webRequest.HaveResponse)
                        {
                            document = new XmlDocument();
                            using (Stream responseStream = webResponse.GetResponseStream())
                            {
                                document.Load(responseStream);
                            }
                        }
                    }
                    if (document != null)
                    {
                        return ParseFeedData(document, maxMessages);
                    }
                }
                catch (UriFormatException)
                {
                }
                catch (SecurityException)
                {
                }
                catch (WebException)
                {
                }
                return null;
            }

            private IEnumerable<RSSMessage> ParseFeedData(XmlDocument document, int maxMessages)
            {
                XmlNode node = document.SelectSingleNode("/rss/channel[1]/title");
                if (node != null)
                {
                    BlogName = node.InnerText;
                }
                int count = 0;
                foreach (XmlNode itemNode in document.SelectNodes(
                    "/rss/channel[1]/item"))
                {
                    yield return new RSSMessage()
                    {
                        Title = itemNode["title"].InnerText,
                        Date = itemNode["pubDate"].InnerText,
                        HRef = itemNode["link"].InnerText,
                        BlogName = _blogName
                    };
                    if (++count == maxMessages)
                    {
                        yield break;
                    }
                }
            }
        }
    }
}
