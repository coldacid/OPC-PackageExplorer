using System;
using System.Collections.Generic;
using System.Text;

namespace PackageExplorer.AddIns.DocumentInspector
{
    [Flags]
    public enum DisplayModes
    {
        Normal = 0,
        Relationships = 1,
        Directories = 2,
        Vocabulary = 4
    }
}
