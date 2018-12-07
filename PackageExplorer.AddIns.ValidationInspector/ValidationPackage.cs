using System;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Xml.Schema;
using System.Collections.Generic;

namespace PackageExplorer.AddIns.ValidationInspector
{
    class ValidationPackage
        : IDisposable
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        ZipFile _zipFile;
        bool _disposed;

        ZipFile ZipFile
        {
            get
            {
                if (_zipFile == null)
                {
                    if (_disposed)
                    {
                        throw new ObjectDisposedException("Object is disposed");
                    }
                    _zipFile = new ZipFile(File.OpenRead(FileName));
                }
                return _zipFile;
            }
        }

        public XmlSchemaSet GetSchemas()
        {
            XmlSchemaSet schemas = SchemaCache.Get(FileName);
            if (schemas == null)
            {
                schemas = new XmlSchemaSet();
                ValidationPackageResolver resolver = new ValidationPackageResolver() { ValidationPackage = this };
                schemas.XmlResolver = resolver;
                Uri schemaUri = resolver.ResolveUri(null, "all.xsd");
                schemas.Add((XmlSchema)resolver.GetEntity(schemaUri, null, typeof(XmlSchema)));
                SchemaCache.Set(FileName, schemas);
            }
            return schemas;
        }

        Stream GetSchema(Uri absoluteUri)
        {
            ZipFile file = ZipFile;
            ZipEntry entry = file.GetEntry(absoluteUri.ToString());
            if (entry != null)
            {
                return file.GetInputStream(entry);
            }
            else
            {
                return null;
            }
        }

        public void Dispose()
        {
            if (_disposed == false)
            {
                if (_zipFile != null)
                {
                    _zipFile.Close();
                    _zipFile = null;
                }
                _disposed = true;
            }
        }

        class ValidationPackageResolver
            : XmlResolver
        {
            public ValidationPackage ValidationPackage { get; set; }

            public override ICredentials Credentials
            {
                set { }
            }

            public override Uri ResolveUri(Uri baseUri, string relativeUri)
            {
                return new Uri(relativeUri, UriKind.Relative);
            }

            public override object GetEntity(Uri absoluteUri,
                string role, Type type)
            {
                if (type == typeof(Stream) || type == null)
                {
                    return ValidationPackage.GetSchema(absoluteUri);
                }
                else if (type == typeof(XmlSchema))
                {
                    using (Stream stream = ValidationPackage.GetSchema(absoluteUri))
                    {
                        return XmlSchema.Read(stream, null);
                    }
                }
                throw new NotSupportedException();
            }
        }
    }
}
