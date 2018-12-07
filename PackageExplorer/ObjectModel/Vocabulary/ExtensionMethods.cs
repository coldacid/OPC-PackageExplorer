using System;
using System.Xml.Linq;

namespace PackageExplorer.ObjectModel.Vocabulary
{
    public static class ExtensionMethods
    {
        public static string GetAttributeValue(this XElement element, XName name)
        {
            return element.Attribute(name) != null ? element.Attribute(name).Value : null;
        }
    }
}
