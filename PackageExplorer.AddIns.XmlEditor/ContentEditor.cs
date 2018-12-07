using System;
using PackageExplorer.Core;
using System.IO;
using System.Text;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;
using System.Xml;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using System.ComponentModel;

namespace PackageExplorer.AddIns.XmlEditor
{
    class ContentEditor
        : IContentEditor, ISupportEditing
    {
        XmlEditorControl _control = null;
        bool _isDirty = false;
        XmlEditorSettings _settings;
        FontSettings _fontSettings;

        public Guid EditorTypeID
        {
            get { return new Guid("{851356AF-0D44-4f12-B4DE-F2C5A73213C2}"); }
        }

        public Control EditingControl
        {
            get { return _control; }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
        }

        public ContentEditor()
        {
            _control = new XmlEditorControl();
            _control.Document.DocumentChanged += new ICSharpCode.TextEditor.Document.DocumentEventHandler(Document_DocumentChanged);
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            _fontSettings = settingsService.GetSettings<FontSettings>();
            _fontSettings.PropertyChanged += FontSettings_PropertyChanged;
            _control.Font = new System.Drawing.Font(_fontSettings.FontName, _fontSettings.FontSize);
            _settings = settingsService.GetSettings<XmlEditorSettings>();
        }

        void ISupportEditing.Cut()
        {
            _control.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(null, EventArgs.Empty);
        }

        void ISupportEditing.Copy()
        {
            _control.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(null, EventArgs.Empty);
        }

        void ISupportEditing.Paste()
        {
            _control.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(null, EventArgs.Empty);
        }

        void ISupportEditing.SelectAll()
        {
            _control.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(null, EventArgs.Empty);
        }

        public void LoadFrom(IContentSource contentSource, Encoding encoding)
        {
            StreamReader reader = encoding == null ?
                new StreamReader(contentSource.GetContent(), true) :
                new StreamReader(contentSource.GetContent(), encoding);
            using (reader)
            {
                _control.Document.TextContent =
                    _settings.FormatXmlOnOpen ?
                    _control.FormatXml(reader.ReadToEnd()) :
                    reader.ReadToEnd();
            }
            _isDirty = false;
        }

        public void SaveTo(IContentSource contentSource, Encoding encoding)
        {
            if(encoding == null)
            {
                try
                {
                    using(StringReader textReader = new StringReader(_control.Document.TextContent))
                    using (XmlTextReader reader = new XmlTextReader(textReader))
                    {
                        reader.MoveToContent();
                        encoding = reader.Encoding;
                    }
                }
                catch (XmlException)
                {
                    encoding = Encoding.Default;
                }
            }
            contentSource.SetContent(encoding.GetBytes(_control.Document.TextContent));
            _isDirty = false;
        }

        public void OnClose()
        {
            _fontSettings.PropertyChanged -= FontSettings_PropertyChanged;
        }

        public void SetReadOnly()
        {
            _control.Document.ReadOnly = true;
        }

        protected virtual void OnContentChanged(EventArgs e)
        {
            EventHandler<EventArgs> handler = ContentChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        void FontSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _control.Font = new System.Drawing.Font(_fontSettings.FontName, _fontSettings.FontSize);
        }

        void Document_DocumentChanged(object sender,
            ICSharpCode.TextEditor.Document.DocumentEventArgs e)
        {
            _isDirty = true;
            OnContentChanged(EventArgs.Empty);
        }

        public event EventHandler<EventArgs> ContentChanged;
    }
}
