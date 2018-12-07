using System;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel;
using System.Collections.Generic;
using WinApp = System.Windows.Forms.Application;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using PackageExplorer.Core.AddInModel;
using PackageExplorer.ObjectModel.Vocabulary;

namespace PackageExplorer.Services
{
    class DefaultVocabularyService
        : ServiceBase, IVocabularyService
    {
        List<PackageVocabulary> _vocabularies;

        public IEnumerable<PackageVocabulary> Vocabularies
        {
            get { return _vocabularies; }
        }

        public DefaultVocabularyService()
        {
            _vocabularies = new List<PackageVocabulary>();
        }

        public override void InitializeService()
        {
            string vocabularyFolder = Path.Combine(WinApp.StartupPath, "Vocabularies");
            IAddInTreeNode vocabulariesNode = AddInTreeSingleton.AddInTree.GetTreeNode(
                "/core/vocabularies");
            if (vocabulariesNode != null)
            {
                XNamespace ns = "http://PackageExplorer/Vocabulary";
                foreach (string fileName in vocabulariesNode.BuildChildItems(this))
                {
                    XDocument vocabularyDocument = XDocument.Load(Path.Combine(vocabularyFolder, fileName));
                    XElement vocabularyElement = vocabularyDocument.Element(ns + "vocabulary");
                    PackageVocabulary vocabulary = new PackageVocabulary()
                    {
                        Name = vocabularyElement.Attribute("name").Value,
                        StartPart = vocabularyElement.Attribute("startPart") != null ? vocabularyElement.Attribute("startPart").Value : null
                    };
                    vocabulary.GlobalReferences = VocabularyPartReference.FromXElement(vocabulary, ns, vocabularyElement.Element(ns + "globalReferences"));
                    vocabulary.Parts = VocabularyPart.FromXElement(vocabulary, ns, vocabularyElement.Element(ns + "partTypes"));
                    vocabulary.SupportingVocabularies = from supportingVocabularyElement in vocabularyElement.Element(ns + "supportingVocabularies").Elements(ns + "vocabulary")
                                                 select _vocabularies.Where( supportingVocabulary => supportingVocabulary.Name == supportingVocabularyElement.Attribute("name").Value).First();
                    vocabulary.Links = VocabularyLink.FromXElement(vocabulary, ns, vocabularyElement.Element(ns + "links"));
                    _vocabularies.Add(vocabulary);
                }
            }
            base.InitializeService();
        }

        public PackageVocabulary GetVocabularyByContentType(string contentType)
        {
            return _vocabularies.Where(
                vocabulary => 
                    vocabulary.StartPart != null && vocabulary.Parts.Where(
                        part => part.Name == vocabulary.StartPart && part.ContentTypes.Contains(contentType)
                    ).Count() > 0
                ).FirstOrDefault();
        }
    }
}
