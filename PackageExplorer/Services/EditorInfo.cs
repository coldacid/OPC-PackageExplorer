using System;
using System.ComponentModel;

namespace PackageExplorer.Services
{
    public class EditorInfo
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public bool SupportsEncoding { get; set; }
        public bool IsDefaultEditor { get; set; }
    }
}
        