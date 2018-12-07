using System;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Xsl;
using System.Reflection;
using System.Text;

namespace PackageExplorer.AddIns.BrowserEditor
{
    class ContentEditor
        : IContentEditor
    {
        BrowserEditorControl _control = null;
        static XmlDocument _xmlToHtmlStylesheet = null;

        static XmlDocument XmlToHtmlStylesheet
        {
            get
            {
                if (_xmlToHtmlStylesheet == null)
                {
                    _xmlToHtmlStylesheet = new XmlDocument();
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PackageExplorer.AddIns.BrowserEditor.XmlToHtml.xslt"))
                    {
                        _xmlToHtmlStylesheet.Load(stream);
                    }
                }
                return _xmlToHtmlStylesheet;
            }
        }

        public Guid EditorTypeID
        {
            get { return new Guid("{7AE53365-F390-4b13-8C62-0A8945CEF562}"); }
        }

        public Control EditingControl
        {
            get { return _control; }
        }

        public bool IsDirty
        {
            get { return false; }
        }

        public ContentEditor()
        {
            _control = new BrowserEditorControl();
        }

        public void LoadFrom(IContentSource contentSource, Encoding encoding)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(XmlToHtmlStylesheet);
            using (MemoryStream outputStream = new MemoryStream())
            {
                using (XmlWriter outputWriter = XmlWriter.Create(outputStream))
                {
                    using (XmlReader inputReader = XmlReader.Create(contentSource.GetContent()))
                    {
                        transform.Transform(inputReader, null, outputWriter);
                    }
                }
                if (encoding == null)
                {
                    encoding = Encoding.Default;
                }
                _control.DocumentText = encoding.GetString(outputStream.ToArray());
            }
        }

        public void SaveTo(IContentSource contentSource, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public void OnClose()
        {
        }

        public void SetReadOnly()
        {
        }

        event EventHandler<EventArgs> IContentEditor.ContentChanged
        {
            add { }
            remove { }
        }
    }
}
