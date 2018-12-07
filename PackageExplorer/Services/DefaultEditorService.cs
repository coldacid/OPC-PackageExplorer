using System;
using System.Collections.Generic;
using System.Text;
using PackageExplorer.Core.Services;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.AddInModel;
using System.Collections.Specialized;
using PackageExplorer.Utils;

namespace PackageExplorer.Services
{
    class DefaultEditorService
        : ServiceBase, IEditorService
    {
        EditorSettings _settings = null;

        EditorSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    ISettingsService settingsService =
                        ServiceManager.GetService<ISettingsService>();
                    _settings = settingsService.GetSettings<EditorSettings>();
                    if (_settings.DefaultEditors == null)
                    {
                        _settings.DefaultEditors = new DefaultEditorCollection();
                    }
                }
                return _settings;
            }
        }

        public IEnumerable<EditorInfo> GetEditors(string extension)
        {
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/editors");
            StringParserService stringParser = ServiceManager.GetService<StringParserService>();
            string defaultEditor = GetDefaultEditor(extension);
            if (node != null)
            {
                foreach (IAddInTreeNode editorNode in node.ChildNodes)
                {
                    EditorCodon codon = editorNode.Codon as EditorCodon;
                    yield return new EditorInfo()
                    {
                        ID = codon.ID,
                        Title = stringParser.Parse(codon.Title),
                        SupportsEncoding = codon.SupportsEncoding,
                        IsDefaultEditor = codon.ID == defaultEditor
                    };
                }
            }
        }

        public string GetDefaultEditor(string extension)
        {
            string editorName = null;
            if (Settings.DefaultEditors.ContainsKey(extension))
            {
                editorName = Settings.DefaultEditors[extension];
            }
            else
            {
                editorName = FindMatchingEditor(extension);
                if (editorName != null)
                {
                    SetDefaultEditor(extension, editorName);
                }
            }
            return editorName;
        }

        public void SetDefaultEditor(string extension, string editorName)
        {
            Settings.DefaultEditors[extension] = editorName;
        }

        public IContentEditor CreateDefaultEditor(string extension)
        {
            string editorName = GetDefaultEditor(extension);
            return editorName != null ? CreateEditor(GetEditor(editorName)) : null;
        }

        public EditorInfo GetEditor(string editorName)
        {
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/editors");
            StringParserService stringParser = ServiceManager.GetService<StringParserService>();
            if (node != null)
            {
                foreach (IAddInTreeNode editorNode in node.ChildNodes)
                {
                    EditorCodon codon = editorNode.Codon as EditorCodon;
                    if (codon.ID == editorName)
                    {
                        return new EditorInfo()
                        {
                            ID = codon.ID,
                            IsDefaultEditor = false,
                            SupportsEncoding = codon.SupportsEncoding,
                            Title = stringParser.Parse(codon.Title)
                        };
                    }
                }
            }
            return null;
        }

        public ContentTypes GetContentTypesForEditor(string editorName)
        {
            ContentTypes types = ContentTypes.Unknown;
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/editors");
            if (node != null)
            {
                foreach (IAddInTreeNode editorNode in node.ChildNodes)
                {
                    EditorCodon codon = editorNode.Codon as EditorCodon;
                    if (codon.ID == editorName)
                    {
                        types = codon.SupportedTypes;
                        break;
                    }
                }
            }
            return types;
        }

        public PackageExplorer.UI.Workbench.IContentEditor CreateEditor(EditorInfo editorInfo)
        { 
            IContentEditor editor = null;
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/editors");
            if (node != null)
            {
                foreach (IAddInTreeNode editorNode in node.ChildNodes)
                {
                    EditorCodon codon = editorNode.Codon as EditorCodon;
                    if (codon != null && codon.ID == editorInfo.ID)
                    {
                        editor = (IContentEditor)editorNode.BuildItem(this);
                        break;
                    }
                }
            }
            return editor;
        }

        string FindMatchingEditor(string extension)
        {
            string editorName = null;
            IAddInTreeNode node = AddInTreeSingleton.AddInTree.GetTreeNode("/workspace/editors");
            if (node != null)
            {
                ContentTypes sourceDataType = ContentTypeMappings.GetContentTypeForExtension(extension);
                foreach (IAddInTreeNode editorNode in node.ChildNodes)
                {
                    EditorCodon codon = editorNode.Codon as EditorCodon;
                    if ((sourceDataType & codon.SupportedTypes) != ContentTypes.Unknown)
                    {
                        editorName = codon.ID;
                    }
                }
            }
            return editorName;
        }
    }
}
