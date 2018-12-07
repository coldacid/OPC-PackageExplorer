using System;

namespace PackageExplorer.AddIns.DocumentInspector
{
    [Flags]
    enum DocumentInspectorNodeType
    {
        None = 0,
        Document = 1,
        DocumentPart = 2,
        ExternalRelationship = 4,
        Binary = 8,
        Xml = 16
    }
}
