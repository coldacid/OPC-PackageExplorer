using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Schema;
using System.Xml;

namespace PackageExplorer.Tools.Validation
{
    class Program
    {
        const string XMLNS_XSD = "http://www.w3.org/2001/XMLSchema";

        static void Main(string[] args)
        {
            foreach (string path in Directory.GetDirectories(
                Directory.GetCurrentDirectory()))
            {
                string allXsd = Path.Combine(path, "all.xsd");
                if (File.Exists(allXsd))
                {
                    File.Delete(allXsd);
                }
                XmlSchema schema = new XmlSchema();
                schema.Id = new DirectoryInfo(path).Name;
                schema.TargetNamespace = "http://tempuri.org";
                schema.Namespaces.Add("tns", "http://tempuri.org");
                foreach (string file in Directory.GetFiles(path))
                {
                    XmlSchemaImport import = new XmlSchemaImport();
                    string targetNamespace = null;
                    using (XmlReader reader = XmlReader.Create(file))
                    {
                        reader.MoveToContent();
                        targetNamespace = reader.GetAttribute("targetNamespace");
                    }
                    import.Namespace = targetNamespace;
                    import.SchemaLocation = Path.GetFileName(file);
                    schema.Includes.Add(import);
                }
                using (FileStream fs = File.Create(allXsd))
                {
                    schema.Write(fs);
                }
            }
        }
    }
}
