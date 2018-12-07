using System;
using System.Xml.Schema;
using System.Collections.Generic;

namespace PackageExplorer.AddIns.ValidationInspector
{
    static class SchemaCache
    {
        static Dictionary<string, XmlSchemaSet> _schemaCache;

        static SchemaCache()
        {
            _schemaCache = new Dictionary<string, XmlSchemaSet>();
        }

        public static void Set(string path, XmlSchemaSet schemas)
        {
            _schemaCache[path] = schemas;
        }

        public static XmlSchemaSet Get(string path)
        {
            XmlSchemaSet set = null;
            if (_schemaCache.ContainsKey(path))
            {
                set = _schemaCache[path];
            }
            return set;
        }
    }
}
