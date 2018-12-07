using System;
using WinApp = System.Windows.Forms.Application;
using System.ComponentModel;
using PackageExplorer.Core.AddInModel.Codons;
using System.Collections.Generic;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.Core.Services;
using System.Windows.Forms;
using PackageExplorer.Utils;
using System.IO;
namespace PackageExplorer.ObjectModel
{
    public class Application
    {
        static Application _instance = null;
        DocumentCollection _documents = null;
        CommandCollection _commands = null;

        public static Application Default
        {
            get { return _instance; }
        }

        public static DocumentCollection Documents
        {
            get { return _instance._documents; }
        }

        public static CommandCollection Commands
        {
            get { return _instance._commands; }
        }

        public static Document ActiveDocument
        {
            get { return _instance._documents.PrimarySelection; }
        }

        static Application()
        {
            _instance = new Application();
            StringParserService parser = ServiceManager.GetService<StringParserService>();
            parser.AddReplacementCallback("APP",
                delegate(string tokenData)
                {
                    string result = null;
                    if (String.Equals(tokenData, "ActiveDocument", StringComparison.InvariantCultureIgnoreCase))
                    {
                        result = ActiveDocument != null ?
                            ActiveDocument.Filename : null;
                    }
                    return result;
                });
        }

        Application()
        {
            _documents = new DocumentCollection(this);
            _documents.ItemAdded +=
                delegate(object sender, ItemEventArgs<Document> e)
                {
                    AddDocument(e.Item);
                };
            _documents.ItemRemoved +=
                delegate(object sender, ItemEventArgs<Document> e)
                {
                    RemoveDocument(e.Item);
                };
            _commands = new CommandCollection();
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/commands");
            if (node != null)
            {
                foreach (ICommand command in node.BuildChildItems(this))
                {
                    _commands.Add(command.Name, command);
                }
            }
        }

        public static bool Exit()
        {
            bool canExit = true;
            List<Document> documents = new List<Document>();
            foreach (Document document in Documents)
            {
                documents.Add(document);
            }
            foreach (Document document in documents)
            {
                if (document.Close() == false)
                {
                    canExit = false;
                    break;
                }
            }            
            if (canExit)
            {
                OnExiting(EventArgs.Empty);
                WinApp.Exit();
            }
            return canExit;
        }

        public static bool SaveAs(Document document)
        {
            bool saved = false;
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = FileFilters.BuildFileFilter();
                dialog.FileName = document.Filename;
                dialog.FilterIndex = FileFilters.GetFilterIndexForExtension(
                    Path.GetExtension(document.Filename));
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    saved = document.SaveAs(dialog.FileName);
                }
            }
            return saved;
        }

        public static bool Save(Document document)
        {
            bool saved = false;
            if (String.IsNullOrEmpty(document.Path) == false)
            {
                saved = document.Save();
            }
            else
            {
                saved = SaveAs(document);
            }
            return saved;
        }

        static void OnExiting(EventArgs e)
        {
            EventHandler<EventArgs> handler = Exiting;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        void AddDocument(Document document)
        {
            document.Closing += new EventHandler<CancelEventArgs>(Document_Closing);
        }

        void RemoveDocument(Document document)
        {
            document.Closing -= new EventHandler<CancelEventArgs>(Document_Closing);
        }

        void Document_Closing(object sender, CancelEventArgs e)
        {
            Document document = (Document)sender;
            e.Cancel |= TrySave(document) == false;
        }

        public static bool TrySave(Document document)
        {
            bool saved = document.IsDirty == false;
            if (document.IsDirty)
            {
                DialogResult result = MessageBox.Show(
                     String.Format("The document '{0}' is dirty. Do you wish to save the document?", document.Filename),
                     System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saved = Save(document);
                }
                else
                {
                    saved = result == DialogResult.No;
                }
            }
            return saved;
        }

        public static event EventHandler<EventArgs> Exiting;
    }
}
