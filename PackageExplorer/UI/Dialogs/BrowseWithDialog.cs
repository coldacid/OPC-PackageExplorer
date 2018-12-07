using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;
using PackageExplorer.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Dialogs
{
    public partial class BrowseWithDialog
        : DialogContent
    {
        ListBox _editorsField;

        public EditorInfo SelectedItem
        {
            get
            {
                return (EditorInfo)_editorsField.SelectedItem;
            }
        }

        public DocumentPart DocumentPart { get; set; }

        public BrowseWithDialog()
        {
            InitializeComponent();            
        }

        protected override void OnLoad(EventArgs e)
        {
            string extension = Path.GetExtension(DocumentPart.Uri.ToString());
            IEditorService editorService = ServiceManager.GetService<IEditorService>();
            _editorsField.DataSource =
                editorService.GetEditors(extension)
                .OrderBy
                (
                    item => item.Title
                ).ThenBy
                (
                    item => item.SupportsEncoding
                ).ToArray();

            _editorsField.Format +=
                delegate(object sender, ListControlConvertEventArgs args)
                {
                    EditorInfo editor = (EditorInfo)args.ListItem;
                    args.Value = editor.IsDefaultEditor ?
                        editor.Title + " (default)" : editor.Title;
                };
            _editorsField.SelectedIndex = -1;
            _editorsField.SelectedIndexChanged += 
                (sender, args) => PerformValidation();
            base.OnLoad(e);
        }

        void SetDefaultButton_Click(object sender, EventArgs e)
        {
            if (_editorsField.SelectedItem != null)
            {
                SetDefaultEditor((EditorInfo)_editorsField.SelectedItem);
            }
        }

        void EditorsField_Validating(object sender, 
            System.ComponentModel.CancelEventArgs e)
        {
            if (_editorsField.SelectedItem == null)
            {
                e.Cancel = true;
            }
            else
            {
                DocumentPart part = DocumentPart;
                WorkbenchService ws = ServiceManager.GetService<WorkbenchService>();
                IEditorService es = ServiceManager.GetService<IEditorService>();
                ContentTypes sourceTypes = ContentTypeMappings.GetContentTypeForExtension(
                    Path.GetExtension(part.Uri.ToString()));
                ContentTypes editorTypes = es.GetContentTypesForEditor(((EditorInfo)_editorsField.SelectedItem).ID);
                if ((sourceTypes & editorTypes) == ContentTypes.Unknown)
                {
                    SetError("The selected editor cannot handle that type of content.");
                    e.Cancel = true;
                }
            }
            _setDefaultButton.Enabled = !e.Cancel;
        }

        void SetDefaultEditor(EditorInfo selectedEditor)
        {
            string extension = Path.GetExtension(DocumentPart.Uri.ToString());
            IEditorService editorService = ServiceManager.GetService<IEditorService>();
            editorService.SetDefaultEditor(extension, selectedEditor.ID);
            try
            {
                _editorsField.BeginUpdate();
                foreach (EditorInfo editor in _editorsField.Items)
                {
                    editor.IsDefaultEditor = false;
                }
                selectedEditor.IsDefaultEditor = true;
                CurrencyManager cm = (CurrencyManager)ParentForm.BindingContext[_editorsField.DataSource, null];
                cm.Refresh();
            }
            finally
            {
                _editorsField.EndUpdate();
            }
        }    
    }
}
