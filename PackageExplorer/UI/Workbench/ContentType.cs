using System;

namespace PackageExplorer.UI.Workbench
{
    [Flags]
    public enum ContentTypes
    {
        Unknown = 0,
        Text = 1,
        Xml = 2,
        Binary = 4,
        Image = 8
    }
}
