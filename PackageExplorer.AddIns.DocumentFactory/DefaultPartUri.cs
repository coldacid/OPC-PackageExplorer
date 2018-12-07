using System;
using System.Xml.Linq;
using System.IO;
using WinApp = System.Windows.Forms.Application;
using PackageExplorer.ObjectModel.Vocabulary;
using System.Linq;

namespace PackageExplorer.AddIns.DocumentFactory
{
    static class DefaultPartUri
    {
        static XDocument _defaultUris;

        static DefaultPartUri()
        {
            string path = Path.Combine(WinApp.StartupPath, @"AddIns\DefaultPartUri.xml");
            _defaultUris = XDocument.Load(path);
        }

        public static string GetDefaultUri(string documentVocabulary, VocabularyPart part)
        {
            XElement vocabularyUris = _defaultUris.Element("partUris").Elements("vocabulary").Where(
                e => e.Attribute("name").Value == documentVocabulary).FirstOrDefault();
            if (vocabularyUris != null)
            {
                XElement partUri = vocabularyUris.Elements("partUri").Where(
                        e => e.Attribute("partName").Value == part.Name &&
                            (part.Owner.Name == documentVocabulary ||
                            e.Attribute("partVocabulary").Value == part.Owner.Name)).FirstOrDefault();
                if (partUri != null)
                {
                    return partUri.Attribute("location").Value;
                }
            }
            return null;
        }
    }
}
