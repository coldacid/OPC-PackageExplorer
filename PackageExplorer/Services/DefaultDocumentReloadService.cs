using System;
using PackageExplorer.Core.Services;
using System.Collections.Generic;
using PackageExplorer.ObjectModel;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using PackApp = PackageExplorer.ObjectModel.Application;

namespace PackageExplorer.Services
{
    class DefaultDocumentReloadService
        : ServiceBase, IDocumentReloadService
    {
        delegate void ReloadDocumentCallback(FileSystemWatcher watcher);

        Dictionary<Document, FileSystemWatcher> _watchers = null;
        Dictionary<FileSystemWatcher, Document> _documents = null;
        Dictionary<FileSystemWatcher, DateTime?> _lastWriteTimes = null;

        public DefaultDocumentReloadService()
        {
            _watchers = new Dictionary<Document, FileSystemWatcher>();
            _documents = new Dictionary<FileSystemWatcher, Document>();
            _lastWriteTimes = new Dictionary<FileSystemWatcher, DateTime?>();
            foreach (Document document in PackApp.Documents)
            {
                StartMonitoring(document);
            }
            PackApp.Documents.ItemAdded +=
                delegate(object sender, ItemEventArgs<Document> e)
                {
                    StartMonitoring(e.Item);
                };
            PackApp.Documents.ItemRemoved +=
                delegate(object sender, ItemEventArgs<Document> e)
                {
                    StopMonitoring(e.Item);
                };
            PackApp.Exiting +=
                delegate(object sender, EventArgs e)
                {
                    List<Document> documentsToClose =
                        new List<Document>();
                    documentsToClose.AddRange(_watchers.Keys);
                    foreach (Document document in documentsToClose)
                    {
                        StopMonitoring(document);
                    }
                };   
        } 

        void StartMonitoring(Document document)
        {
            lock (_watchers)
            {
                document.PropertyChanged += new PropertyChangedEventHandler(Document_PropertyChanged);
                if (document.IsSaved)
                {
                    CreateWatcher(document);
                }
            }
        }

        void StopMonitoring(Document document)
        {
            lock (_watchers)
            {
                if (_watchers.ContainsKey(document))
                {
                    FileSystemWatcher watcher = _watchers[document];
                    watcher.EnableRaisingEvents = false;
                    watcher.Changed -= Watcher_Changed;
                    _watchers.Remove(document);
                    _documents.Remove(watcher);
                    _lastWriteTimes.Remove(watcher);
                }
                document.PropertyChanged -= Document_PropertyChanged;
            }
        }

        FileSystemWatcher CreateWatcher(Document document)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(
                    Path.GetDirectoryName(document.Path),
                    Path.GetFileName(document.Path));
            watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.Attributes | NotifyFilters.FileName;
            watcher.Changed += new FileSystemEventHandler(Watcher_Changed);
            watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);
            watcher.EnableRaisingEvents = true;
            _watchers.Add(document, watcher);
            _lastWriteTimes.Add(watcher, null);
            _documents.Add(watcher, document);
            return watcher;
        }

        void RefreshDocumentWatcher(Document document)
        {
            lock (_watchers)
            {
                FileSystemWatcher watcher = null;
                if (_watchers.ContainsKey(document))
                {
                    watcher = _watchers[document];
                }
                else
                {
                    watcher = CreateWatcher(document);
                }
                watcher.Path = Path.GetDirectoryName(document.Path);
                watcher.Filter = Path.GetFileName(document.Path);
            }
        }

        void ReloadDocument(FileSystemWatcher watcher)
        {
            lock (_watchers)
            {
                if (_documents.ContainsKey(watcher))
                {
                    DateTime? lastTimeQueried = _lastWriteTimes[watcher];
                    if (lastTimeQueried == null || 
                        ((TimeSpan)(DateTime.Now - lastTimeQueried)).TotalSeconds > 2)
                    {
                        IMethodInvocationService invokeService = ServiceManager.GetService<IMethodInvocationService>();
                        invokeService.Invoke(
                            new ReloadDocumentCallback(ReloadDocumentSafe), watcher);
                        _lastWriteTimes[watcher] = DateTime.Now;
                    }
                }
            }
        }

        void ReloadDocumentSafe(FileSystemWatcher watcher)
        {
            Document document = _documents[watcher];
            FileInfo fileInfo = new FileInfo(document.Path);
            if (fileInfo.LastWriteTime > document.LastWriteTime)
            {
                String message = String.Format("An outside change to {0} was detected. Do you wish to reload the document?", document.Filename);
                if (MessageBox.Show(message, "Package Explorer",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (IsFileLocked(document.Path) == false)
                    {
                        string path = document.Path;
                        if (document.Close())
                        {
                            PackApp.Documents.Open(path);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File is locked", "Package Explorer");
                    }
                }
            }
        }

        bool IsFileLocked(string path)
        {
            bool locked = true;
            try
            {
                using (FileStream fs = File.Open(path, 
                    FileMode.Open, FileAccess.Read, FileShare.None))
                {
                }
                locked = false;
            }
            catch (IOException)
            {
            }
            return locked;
        } 

        void Document_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Path")
            {
                Document document = (Document)sender;
                RefreshDocumentWatcher(document);
            }
        }

        void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                FileSystemWatcher watcher = (FileSystemWatcher)sender;
                ReloadDocument(watcher);
            }
        }

        void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Renamed)
            {
                FileSystemWatcher watcher = (FileSystemWatcher)sender;
                ReloadDocument(watcher);
            }
        }       
    }
}
