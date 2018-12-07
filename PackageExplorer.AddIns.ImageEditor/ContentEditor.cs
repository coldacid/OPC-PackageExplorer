using System;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text;
using System.Drawing.Imaging;

namespace PackageExplorer.AddIns.ImageEditor
{
    class ContentEditor
        : IContentEditor, ISupportEditing
    {
        ImageEditorControl _control = null;
        bool _isDirty;
        Guid _imageFormat;

        public Guid EditorTypeID
        {
            get { return new Guid("{322B7881-6F9B-4847-B7CF-0DF0172EE54E}"); }
        }

        public Control EditingControl
        {
            get { return _control; }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
        }

        void ISupportEditing.Cut()
        {
            Clipboard.SetImage(_control.Image);
            _control.Image = null;
            _isDirty = true;
            OnContentChanged(EventArgs.Empty);
        }

        void ISupportEditing.Copy()
        {
            Clipboard.SetImage(_control.Image);
        }

        void ISupportEditing.Paste()
        {
            if (Clipboard.ContainsImage())
            {
                _control.Image = Clipboard.GetImage();
            }
            _isDirty = true;
            OnContentChanged(EventArgs.Empty);
        }

        void ISupportEditing.SelectAll()
        {
        }

        public ContentEditor()
        {
            _control = new ImageEditorControl();
        }

        public void LoadFrom(IContentSource contentSource, Encoding encoding)
        {
            Image image;
            using (Stream stream = contentSource.GetContent())
            {
                image = Image.FromStream(stream);
                _imageFormat = image.RawFormat.Guid;
                _control.Image = image;
            }
        }

        public void SaveTo(IContentSource contentSource, Encoding encoding)
        {
            _isDirty = false;
            using(MemoryStream ms = new MemoryStream())
            {
                _control.Image.Save(ms, new ImageFormat(_imageFormat));
                contentSource.SetContent(ms.ToArray());
            }
        }

        public void OnClose()
        {
        }

        public void SetReadOnly()
        {
            
        }

        protected void OnContentChanged(EventArgs e)
        {
            if (ContentChanged != null)
            {
                ContentChanged(this, e);
            }
        }

        public event EventHandler<EventArgs> ContentChanged;
    }
}
