namespace PackageExplorer.AddIns.XmlEditor
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using ICSharpCode.TextEditor;
    using ICSharpCode.TextEditor.Document;
    using System.Windows.Forms;
 
    public class XmlEditorControl : TextEditorControl
    {
        public XmlEditorControl()
        {
            Document.DocumentChanged += Document_DocumentChanged;
            Document.FoldingManager.FoldingStrategy = new XmlFoldingStrategy();
            Document.FormattingStrategy = new XmlFormattingStrategy();
            HighlightingManager.Manager.AddSyntaxModeFileProvider(
                new XmlSyntaxModeProvider());
            this.TextEditorProperties.ShowInvalidLines = false;
            Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("Xml");
        }

        void Document_DocumentChanged(object sender, DocumentEventArgs e)
        {
            Document.FoldingManager.UpdateFoldings("", null);
        }

        class XmlSyntaxModeProvider : ISyntaxModeFileProvider
        {
            public static readonly string _syntaxName = "Xml";

            List<SyntaxMode> _modes = new List<SyntaxMode>();

            public ICollection<SyntaxMode> SyntaxModes
            {
                get { return _modes; }
            }

            public XmlSyntaxModeProvider()
            {
                _modes.Add(new SyntaxMode("XmlHighlighting.xml", _syntaxName,
                    new string[] { "xml" }));
            }

            public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
            {
                XmlTextReader reader = null;
                if (syntaxMode.Name == _syntaxName)
                {
                    reader = new XmlTextReader(
                        new StringReader(Properties.Resources.XmlHighlighting));
                }
                return reader;
            }

            public void UpdateSyntaxModeList()
            {
            }
        }

        internal void Format()
        {
            ActiveTextAreaControl.Document.TextContent =
                FormatXml(ActiveTextAreaControl.Document.TextContent);
        }

        internal string FormatXml(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return data;
            }
            XmlDocument document = null;
            try
            {
                document = new XmlDocument();
                document.LoadXml(data);
            }
            catch (XmlException)
            {
                MessageBox.Show(
                    RS.FormatDocumentErrorMessage,
                    Application.ProductName);
                return data;
            }
            StringBuilder builder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = Environment.NewLine;
            settings.NewLineHandling = NewLineHandling.Replace;
            using (XmlWriter writer = XmlWriter.Create(
                builder, settings))
            {
                document.WriteContentTo(writer);
            }
            return builder.ToString();
        }
    }
}
