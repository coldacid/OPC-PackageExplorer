using System;
using PackageExplorer.UI.Workbench;
using PackageExplorer.Core.Services;
using System.Collections.Specialized;
using PackageExplorer.Utils;
using System.Collections.Generic;

namespace PackageExplorer.Services
{
    public interface IEditorService 
        : IService
    {
        string GetDefaultEditor(string extension);
        void SetDefaultEditor(string extension, string editorName);
        
        IContentEditor CreateEditor(EditorInfo editorInfo);
        IContentEditor CreateDefaultEditor(string extension);
        
        IEnumerable<EditorInfo> GetEditors(string extension);
        EditorInfo GetEditor(string editorName);

        ContentTypes GetContentTypesForEditor(string editorName);
    }
}
