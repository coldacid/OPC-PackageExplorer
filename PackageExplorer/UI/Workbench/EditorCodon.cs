using System;
using PackageExplorer.Core.AddInModel.Codons;
using PackageExplorer.Core.AddInModel;
using System.Collections.Generic;
using System.Xml;
using PackageExplorer.Utils;

namespace PackageExplorer.UI.Workbench
{
    [CodonName("Editor")]
    [RequiredAttribute("title")]
    [RequiredAttribute("supportedTypes")]
    class EditorCodon
        : ClassCodon
    {
        public bool SupportsEncoding { get; set; }
        public ContentTypes SupportedTypes { get; set; }
        public string Title { get; set; }

        public EditorCodon()
        {  
        }
    }
}
