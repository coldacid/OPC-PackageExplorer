using System;
using System.Text;

namespace PackageExplorer.UI.Workbench
{
    public class WindowManager
    {
        IContentEditor _editor = null;
        IContentSource _source = null;
        IContentExplorer _explorer = null;
        IWindow _window = null;       
        bool _isReadOnly;
        string _titleSource = null;
        Encoding _encoding;

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }

        public bool IsDirty
        {
            get { return _editor.IsDirty; }
        }

        public IContentSource Source
        {
            get { return _source; }
        }

        public IContentEditor Editor
        {
            get { return _editor; }
        }

        public IContentExplorer Explorer
        {
            get { return _explorer; }
        }

        public ContentTypes ContentType
        {
            get
            {
                ContentTypes contentType = _source != null ?
                    _source.ContentType : ContentTypes.Unknown;
                return contentType;
            }
        }

        public string Title
        {
            get { return _window.Text; }
        }

        public WindowManager(IContentExplorer explorer, IWindow window)
        {
            _isReadOnly = true;
            _window = window;
            _explorer = explorer;            
        }

        public WindowManager(
            IContentEditor editor, IContentSource source,
            IWindow window, bool isReadOnly, Encoding encoding)
        {
            _isReadOnly = isReadOnly;
            _editor = editor;
            _source = source;
            _window = window;
            _encoding = encoding;
            editor.LoadFrom(source, _encoding);
            _editor.ContentChanged += new EventHandler<EventArgs>(Editor_ContentChanged);
            if (_isReadOnly)
            {
                _editor.SetReadOnly();
            }
            RefreshWindowTitle();
        }

        public void Save()
        {
            if (_isReadOnly == false)
            {
                _editor.SaveTo(_source, _encoding);
                RefreshWindowTitle();
            }
        }

        public void Close()
        {
            _editor.OnClose();
        }

        public bool HasSameSourceAs(IContentSource other)
        {
            return _source == null ? false :
                _source.HasSameSourceAs(other);
        }

        void Editor_ContentChanged(object sender, EventArgs e)
        {
            RefreshWindowTitle();
        }

        void RefreshWindowTitle()
        {
            string title = _source.Title;
            if (_editor.IsDirty)
            {
                title += "*";
            }
            if (_isReadOnly)
            {
                title += "(read-only)";
            }
            _window.Text = title;
        }
    }
}
