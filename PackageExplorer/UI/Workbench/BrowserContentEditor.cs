using System;
using System.Windows.Forms;
using System.Text;

namespace PackageExplorer.UI.Workbench
{
    class BrowserContentEditor
        : IContentEditor
    {
        BrowserContentControl _browser;

        public Guid EditorTypeID
        {
            get { return new Guid("{14F1B573-A257-4a13-9629-927DF6830EEB}"); }
        }

        public Control EditingControl
        {
            get { return _browser; }
        }

        public BrowserContentEditor()
        {
            _browser = new BrowserContentControl();
        }

        public bool IsDirty
        {
            get { return false; }
        }

        public void OnClose()
        {
        }

        public void LoadFrom(IContentSource contentSource, Encoding encoding)
        {
            _browser.Uri = ((BrowserContentSource)contentSource).TargetUri;            
        }

        public void SaveTo(IContentSource contentSource, Encoding encoding)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        public void SetReadOnly()
        {       
        }

        event EventHandler<EventArgs> IContentEditor.ContentChanged
        {
            add { }
            remove {  }
        }
    }
}
