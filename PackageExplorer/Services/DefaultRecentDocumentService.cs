using System;
using PackageExplorer.Core.Services;
using System.Collections.Generic;
using PackageExplorer.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections;

namespace PackageExplorer.Services
{
    class DefaultRecentDocumentService
        : ServiceBase, IRecentDocumentService
    {
        RecentDocumentSettings _settings = null;

        RecentDocumentSettings RecentDocumentSettings
        {
            get
            {
                if (_settings == null)
                {
                    ISettingsService settingsService =
                        ServiceManager.GetService<ISettingsService>();
                    _settings = settingsService.GetSettings<RecentDocumentSettings>();
                    if (_settings.RecentDocuments == null)
                    {
                        _settings.RecentDocuments = new StringCollection();
                    }
                }
                return _settings;
            }
        }

        public int Count
        {
            get { return RecentDocumentSettings.RecentDocuments.Count; }
        }

        public string this[int index]
        {
            get { return _settings.RecentDocuments[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            return new StringIEnumerator(RecentDocumentSettings.RecentDocuments.GetEnumerator());
        }

        public void OpenRecentDocument(string path)
        {
            if (File.Exists(path) == false)
            {
                string message = String.Format("The document {0} could not be found. Do you wish to remove it from the list?",
                    path);
                if (MessageBox.Show(message, "Package Explorer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RecentDocumentSettings.RecentDocuments.Remove(path);
                }
            }
            else
            {
                PackageExplorer.ObjectModel.Application.Documents.Open(path);
            }
        }

        public void Clear()
        {
            RecentDocumentSettings.RecentDocuments.Clear();
        }

        public override void InitializeService()
        {
            PackageExplorer.ObjectModel.Application.Documents.ItemAdded += new EventHandler<ItemEventArgs<Document>>(Documents_ItemAdded);
            base.InitializeService();
        }

        public override void ShutdownService()
        {
            PackageExplorer.ObjectModel.Application.Documents.ItemAdded -= new EventHandler<ItemEventArgs<Document>>(Documents_ItemAdded);            
            base.ShutdownService();
        }

        void Documents_ItemAdded(object sender, ItemEventArgs<Document> e)
        {
            RecentDocumentSettings settings = RecentDocumentSettings;
            if (e.Item.IsSaved && String.IsNullOrEmpty(e.Item.Path) == false)
            {
                if (settings.RecentDocuments.Contains(e.Item.Path))
                {
                    int currentIndex = settings.RecentDocuments.IndexOf(e.Item.Path);
                    settings.RecentDocuments.RemoveAt(currentIndex);
                }
                settings.RecentDocuments.Insert(0, e.Item.Path);
                if (settings.RecentDocuments.Count > settings.MaxNrRecentDocuments)
                {
                    settings.TrimListToSize(settings.MaxNrRecentDocuments);
                }
            }
        }

        class StringIEnumerator
       : IEnumerator
        {
            StringEnumerator _innerEnumerator = null;

            public StringIEnumerator(StringEnumerator innerEnumerator)
            {
                _innerEnumerator = innerEnumerator;
            }
            public object Current
            {
                get { return _innerEnumerator.Current; }
            }

            public bool MoveNext()
            {
                return _innerEnumerator.MoveNext();
            }

            public void Reset()
            {
                _innerEnumerator.Reset();
            }
        }
    }
}
