#region [===== Using =====]
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using System.Drawing;
using System.ComponentModel;
#endregion

namespace PackageExplorer.AddIns.TextEditor
{
    class ContentEditor
        : IContentEditor, ISupportEditing
    {
        #region [===== Static fields =====]
        static readonly Guid EditorID = 
            new Guid("{B30D7957-D11C-4831-8F4B-DFD817006167}");
        #endregion

        #region [===== Instance fields =====]
        TextEditorControl _control = null;
        bool _isDirty = false;
        bool _loading = false;
        FontSettings fontSettings;
        #endregion

        #region [===== Properties =====]
        public Guid EditorTypeID
        {
            get { return EditorID; }
        }

        public Control EditingControl
        {
            get { return _control; }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
        }
        #endregion

        #region [===== Constructors =====]
        public ContentEditor()
        {
            _control = new TextEditorControl();
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            fontSettings = settingsService.GetSettings<FontSettings>();
            fontSettings.PropertyChanged += FontSettings_PropertyChanged;
            _control.Font = new Font(fontSettings.FontName, fontSettings.FontSize);
            _control.TextChanged +=
                delegate(object sender, EventArgs e)
                {
                    if (_loading == false)
                    {
                        _isDirty = true;
                        OnContentChanged(EventArgs.Empty);
                    }
                };
        }
        #endregion

        #region [===== Public instance methods =====]
        public void SetReadOnly()
        {
            _control.ReadOnly = true;
            _control.BackColor = Color.White;
        }

        public void LoadFrom(IContentSource contentSource, Encoding encoding)
        {
            try
            {
                _loading = true;
                StreamReader reader = encoding == null ?
                    new StreamReader(contentSource.GetContent(), true) :
                    new StreamReader(contentSource.GetContent(), encoding);
                using (reader)
                {
                    _control.Text = reader.ReadToEnd();
                }
            }
            finally
            {
                _loading = false;
            }
            _isDirty = false;
        }

        public void SaveTo(IContentSource contentSource, Encoding encoding)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            contentSource.SetContent(encoding.GetBytes(_control.Text));
            _isDirty = false;
        }

        public void OnClose()
        {
            fontSettings.PropertyChanged -= FontSettings_PropertyChanged;
        }
        #endregion

        #region [===== Protected instance methods =====]
        protected virtual void OnContentChanged(EventArgs e)
        {
            EventHandler<EventArgs> handler = ContentChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        void FontSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _control.Font = new Font(fontSettings.FontName, fontSettings.FontSize);
        }


        #region [===== Events =====]
        public event EventHandler<EventArgs> ContentChanged;
        #endregion

        #region ISupportEditing Members

        void ISupportEditing.Cut()
        {
            _control.Cut();
        }

        void ISupportEditing.Copy()
        {
            _control.Copy();
        }

        void ISupportEditing.Paste()
        {
            _control.Paste();
        }

        void ISupportEditing.SelectAll()
        {
            _control.SelectAll();
        }

        #endregion
    }
}
