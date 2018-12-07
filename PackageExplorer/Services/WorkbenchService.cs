using System;
using PackageExplorer.ObjectModel;
using PackageExplorer.UI.Workbench;
using System.Collections.Generic;
using PackageExplorer.Core.AddInModel;
using System.Windows.Forms;
using System.IO;
using PackageExplorer.Core.Services;
using Application = System.Windows.Forms.Application;
using System.ComponentModel;
using PackApp = PackageExplorer.ObjectModel.Application;
using System.Configuration;
using System.Text;

namespace PackageExplorer.Services
{
    public class WorkbenchService
    {
        Dictionary<IWindow, WindowManager> _documentWindows = null;
        Dictionary<Guid, IWindow> _inspectorWindows = null;
        IWorkbench _defaultWorkbench;

        public IWorkbench DefaultWorkbench
        {
            get
            {
                if (_defaultWorkbench == null)
                {
                    IAddInTreeNode workbenchLoaderNode =
                       AddInTreeSingleton.AddInTree.GetTreeNode(
                           "/workspace/workbench/workbenchLoader");
                    if (workbenchLoaderNode == null)
                    {
                        throw new ApplicationException("No workbench loader defined");
                    }
                    IWorkbenchLoader loader = workbenchLoaderNode.BuildItem(null) as IWorkbenchLoader;
                    if (loader == null)
                    {
                        throw new ApplicationException("Defined workbench loader doesn't derive from IWorkbenchLoader.");
                    }
                    _defaultWorkbench = loader.CreateWorkbench();
                    loader.InitializeWorkbench(FirstTimeStartup.IsFirstTimeStartup);
                }
                return _defaultWorkbench;
            }
        }      

        public IEnumerable<IWindow> DocumentWindows
        {
            get { return _documentWindows.Keys; }
        }

        public IEnumerable<IWindow> InspectorWindows
        {
            get { return _inspectorWindows.Values; }
        }

        public WorkbenchService()
        {
            _documentWindows = new Dictionary<IWindow, WindowManager>();
            _inspectorWindows = new Dictionary<Guid, IWindow>();
            foreach (Document document in PackApp.Documents)
            {
                RegisterDocument(document);
            }
            PackApp.Documents.ItemAdded += new EventHandler<ItemEventArgs<Document>>(Documents_ItemAdded);
            PackApp.Documents.ItemRemoved += new EventHandler<ItemEventArgs<Document>>(Documents_ItemRemoved);
        }

        public WindowManager GetWindowManager(IWindow window)
        {
            WindowManager manager;
            _documentWindows.TryGetValue(window, out manager);
            return manager;
        }

        public IWindow Open(DocumentPart part)
        {
            return Open(part, false);
        }

        public IWindow Open(DocumentPart part, bool readOnly)
        {
            IContentEditor contentEditor =
                DetermineDefaultEditor(part);
            return Open(part, readOnly, contentEditor);
        }

        public IWindow Open(DocumentPart part, Encoding encoding)
        {
            IContentEditor contentEditor =
                DetermineDefaultEditor(part);
            return Open(part, encoding, contentEditor);
        }

        public IWindow Open(DocumentPart part, 
            Encoding encoding, IContentEditor contentEditor)
        {
            return Open(part, false, contentEditor, encoding);
        }

        public IWindow Open(DocumentPart part, bool readOnly, 
            IContentEditor contentEditor, Encoding encoding)
        {
            IContentSource contentSource =
                new DocumentPartContentSource(part);
            return Open(contentSource, contentEditor, readOnly, encoding);
        }

        public IWindow Open(DocumentPart part, bool readOnly, 
            IContentEditor contentEditor)
        {
            IContentSource contentSource =
                new DocumentPartContentSource(part);
            return Open(contentSource, contentEditor, readOnly);
        }

        public IWindow Open(string path)
        {
            return Open(path, false);
        }

        public IWindow Open(string path, bool readOnly)
        {
            IContentEditor editor = DetermineDefaultEditor(path);
            return Open(path, readOnly, editor);
        }

        public IWindow Open(string path, bool readOnly, IContentEditor editor)
        {
            IContentSource contentSource =
                new FileContentSource(path);
            return Open(contentSource, editor, readOnly);
        }

        public IWindow Open(Uri externalUri)
        {
            IContentSource source = new BrowserContentSource(externalUri);
            IContentEditor editor = new BrowserContentEditor();
            return Open(source, editor, true);
        }

        public IWindow CreateInspectorWindow(IContentExplorer explorer, 
            string title, ToolStrip inspectorMenu)
        {
            IWindow window = null;
            if (explorer.WindowKind == WindowKind.ToolWindow)
            {
                if (_inspectorWindows.ContainsKey(explorer.ExplorerID))
                {
                    window = _inspectorWindows[explorer.ExplorerID];
                }
                else
                {
                    window = DefaultWorkbench.CreateInspectorWindow(
                        explorer.EditingControl, title, explorer.ExplorerID, inspectorMenu);
                    window.Closed += new EventHandler(Window_Closed);
                    _inspectorWindows.Add(explorer.ExplorerID, window);
                }
            }
            else
            {
                foreach (IWindow searchWindow in _documentWindows.Keys)
                {
                    WindowManager manager = _documentWindows[searchWindow];
                    if (manager.Explorer != null && manager.Explorer.ExplorerID == explorer.ExplorerID)
                    {
                        window = searchWindow;
                        break;
                    }
                }
                if (window == null)
                {
                    window = DefaultWorkbench.CreateDocumentWindow(explorer.EditingControl, title);
                    WindowManager manager = new WindowManager(explorer, window);
                    window.Closed += new EventHandler(Window_Closed);
                    _documentWindows.Add(window, manager);
                }
            }            
            return window;
        }

        public IWindow Open(RelationshipPart relationshipPart)
        {
            RelationshipPartContentSource source = new RelationshipPartContentSource(relationshipPart);
            IContentEditor editor = DetermineDefaultEditor(relationshipPart);
            return Open(source, editor, true);
        }

        public IEnumerable<IWindow> GetWindowsForDocument(Document document)
        {
            List<IWindow> windows = new List<IWindow>();
            foreach (KeyValuePair<IWindow, WindowManager> windowItem
                in _documentWindows)
            {
                DocumentPartContentSource source =
                    windowItem.Value.Source as DocumentPartContentSource;
                if (source != null && source.DocumentPart.Document == document)
                {
                    windows.Add(windowItem.Key);
                }
                else
                {
                    RelationshipPartContentSource relationshipSource =
                        windowItem.Value.Source as RelationshipPartContentSource;
                    if (relationshipSource != null &&
                        relationshipSource.RelationshipPart.Owner == document)
                    {
                        windows.Add(windowItem.Key);                       
                    }
                }
            }
            return windows;
        }
    

        public IWindow GetWindow(Guid id)
        {
            IWindow window = null;
            _inspectorWindows.TryGetValue(id, out window);
            return window;
        }

        public IWindow GetWindow(DocumentPart documentPart)
        {
            IWindow window = null;
            foreach (KeyValuePair<IWindow, WindowManager> managerItem in
                _documentWindows)
            {
                DocumentPartContentSource source =
                    managerItem.Value.Source as DocumentPartContentSource;
                if (source != null && source.DocumentPart == documentPart)
                {
                    window = managerItem.Key;
                    break;
                }
            }
            return window;
        }

        public IWindow GetWindow(string path)
        {
            IWindow window = null;
            foreach (KeyValuePair<IWindow, WindowManager> managerItem in
                _documentWindows)
            {
                FileContentSource source =
                    managerItem.Value.Source as FileContentSource;
                if (source != null && source.Path == path)
                {
                    window = managerItem.Key;
                    break;
                }
            }
            return window;
        }

        IContentEditor DetermineDefaultEditor(string path)
        {
            IEditorService service = ServiceManager.GetService<IEditorService>();
            return service.CreateDefaultEditor(
                Path.GetExtension(path));
        }

        IContentEditor DetermineDefaultEditor(DocumentPart part)
        {
            IEditorService service = ServiceManager.GetService<IEditorService>();
            return service.CreateDefaultEditor(
                Path.GetExtension(part.Uri.ToString()));
        }

        IContentEditor DetermineDefaultEditor(RelationshipPart part)
        {
            IEditorService service = ServiceManager.GetService<IEditorService>();
            return service.CreateDefaultEditor(
                Path.GetExtension(part.Uri.ToString()));
        }

        void RegisterDocument(Document document)
        {
            document.Closing += Document_Closing;
        }

        void UnregisterDocument(Document document)
        {
            document.Closing -= Document_Closing;
        }

        IWindow Open(IContentSource contentSource,
            IContentEditor contentEditor,
            bool readOnly)
        {
            return Open(contentSource, contentEditor, readOnly, null);
        }

        IWindow Open(IContentSource contentSource,
            IContentEditor contentEditor,
            bool readOnly, Encoding encoding)
        {
            if (contentEditor == null)
            {
                MessageBox.Show("There is no editor available for this type of content.");
                return null;
            }
            IWindow window = GetWindowBySource(contentSource);
            bool createNewWindow = window == null;
            if (window != null)
            {
                WindowManager manager = _documentWindows[window];
                if (manager.Editor.EditorTypeID != contentEditor.EditorTypeID)
                {
                    DialogResult result = MessageBox.Show(
                        String.Format("The document '{0}' is already open in another window. Do you want to close it?", contentSource.Title),
                        Application.ProductName, MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        if (window.Close())
                        {
                            createNewWindow = true;
                        }
                    }
                }
            }
            if (createNewWindow)
            {
                // create window
                window = DefaultWorkbench.CreateDocumentWindow(
                    contentEditor.EditingControl, contentSource.Title);
                window.Closing += Window_Closing;
                window.Closed += Window_Closed;
                WindowManager manager = new WindowManager(
                    contentEditor, contentSource, window, readOnly, encoding);
                _documentWindows.Add(window, manager);
            }
            return window;
        }

        IWindow GetWindowBySource(IContentSource source)
        {
            IWindow window = null;
            foreach (KeyValuePair<IWindow, WindowManager> windows in _documentWindows)
            {
                if (windows.Value.HasSameSourceAs(source))
                {
                    window = windows.Key;
                    break;
                }
            }
            return window;
        }

        void RemoveWindow(IWindow window)
        {
            if (_documentWindows.ContainsKey(window))
            {
                window.Closed -= Window_Closed;
                _documentWindows.Remove(window);
            }
        }

        bool CloseWindow(IWindow window)
        {
            bool canCloseWindow = false;
            bool windowClosed = false;
            WindowManager manager = GetWindowManager(window);
            if (manager.IsDirty)
            {
                DialogResult result = MessageBox.Show(
                    String.Format("The document '{0}' is dirty. Do you wish to save the document?", manager.Title), Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    manager.Save();
                    canCloseWindow = true;
                }
                else
                {
                    canCloseWindow = result == DialogResult.No;
                }
            }
            else
            {
                canCloseWindow = true;
            }
            if (canCloseWindow)
            {
                window.Closing -= Window_Closing;
                window.Close();
                windowClosed = true;
            }
            return windowClosed;
        }

        bool CloseDocumentWindows(Document document)
        {
            bool closedAllWindow = true;         
            List<IWindow> windowsToClose = new List<IWindow>();
            foreach (IWindow window in GetWindowsForDocument(document))
            {
                windowsToClose.Add(window);
            }
            foreach (IWindow window in windowsToClose)
            {
                if (CloseWindow(window) == false)
                {
                    closedAllWindow = false;
                    break;
                }
            }
            return closedAllWindow;
        }

        void Documents_ItemAdded(object sender, ItemEventArgs<Document> e)
        {
            RegisterDocument(e.Item);
        }

        void Documents_ItemRemoved(object sender, ItemEventArgs<Document> e)
        {
            UnregisterDocument(e.Item);
        }

        void Document_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel |= CloseDocumentWindows((Document)sender) == false;
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel |= CloseWindow((IWindow)sender) == false;
        }

        void Window_Closed(object sender, EventArgs e)
        {
            RemoveWindow((IWindow)sender);
        }
    }
}
