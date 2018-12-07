using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace PackageExplorer.ObjectModel.Vocabulary
{
    public enum VocabularyReferenceType
    {
        Implicit,
        Explicit
    }

    public class VocabularyPartReference
    {
        public string Name { get; private set; }
        public VocabularyReferenceType Type { get; private set; }
        public int MinOccurs { get; private set; }
        public int MaxOccurs { get; private set; }
        public string Vocabulary { get; private set; }
        public PackageVocabulary Owner { get; private set; }

        internal static IEnumerable<VocabularyPartReference> FromXElement(PackageVocabulary vocabulary, XNamespace ns, XElement containerElement)
        {
            return from refElement in containerElement.Elements(ns + "reference")
                   select new VocabularyPartReference()
                   {
                       Name = refElement.GetAttributeValue("name"),
                       MinOccurs = Int32.Parse(refElement.GetAttributeValue("minOccurs")),
                       MaxOccurs = refElement.Attribute("maxOccurs").Value == "unbounded" ? 0 : Int32.Parse(refElement.Attribute("maxOccurs").Value),
                       Type = (VocabularyReferenceType)Enum.Parse(typeof(VocabularyReferenceType), refElement.Attribute("type").Value, true),
                       Vocabulary = refElement.Attribute("vocabulary") != null ? refElement.Attribute("vocabulary").Value  : vocabulary.Name,
                       Owner = vocabulary
                   };
        }
    }

    public class VocabularyLinkReference
    {
        public string Name { get; private set; }
        public VocabularyReferenceType Type { get; private set; }
        public int MinOccurs { get; private set; }
        public int MaxOccurs { get; private set; }
        public string Vocabulary { get; private set; }
        public PackageVocabulary Owner { get; private set; }

        internal static IEnumerable<VocabularyLinkReference> FromXElement(PackageVocabulary vocabulary, XNamespace ns, XElement containerElement)
        {
            return from refElement in containerElement.Elements(ns + "linkReference")
                   select new VocabularyLinkReference()
                   {
                       Name = refElement.GetAttributeValue("name"),
                       MinOccurs = Int32.Parse(refElement.GetAttributeValue("minOccurs")),
                       MaxOccurs = refElement.Attribute("maxOccurs").Value == "unbounded" ? 0 : Int32.Parse(refElement.Attribute("maxOccurs").Value),
                       Type = (VocabularyReferenceType)Enum.Parse(typeof(VocabularyReferenceType), refElement.Attribute("type").Value, true),
                       Vocabulary = refElement.Attribute("vocabulary") != null ? refElement.Attribute("vocabulary").Value : vocabulary.Name,
                       Owner = vocabulary
                   };
        }
    }

    public class VocabularyLink
    {
        public string Name { get; internal set; }
        public string Description { get; set; }
        public string SourceRelationship { get; internal set; }
        public bool AllowExternal { get; internal set; }
        public bool AllowInteral { get; internal set; }
        public PackageVocabulary Owner { get; internal set; }

        internal static IEnumerable<VocabularyLink> FromXElement(
            PackageVocabulary owner, XNamespace ns, XElement vocabularyElement)
        {
            return from partElement in vocabularyElement.Elements(ns + "link")
                   select new VocabularyLink()
                   {
                       Name = partElement.GetAttributeValue("name"),
                       Description = partElement.GetAttributeValue("description"),
                       AllowExternal = Boolean.Parse(partElement.GetAttributeValue("allowExternal") ?? "false"),
                       AllowInteral = Boolean.Parse(partElement.GetAttributeValue("allowInternal") ?? "true"),
                       SourceRelationship = partElement.GetAttributeValue("sourceRelationship"),
                       Owner = owner
                   };
        }
    }

    public class VocabularyPart
    {
        public string Name { get; internal set; }
        public string Description { get; set; }
        public string SourceRelationship { get; internal set; }
        public bool AllowExternal { get; internal set; }
        public bool AllowInteral { get; internal set; }
        public string RootNamespace { get; internal set; }
        public string RootElement { get; internal set; }
        public IEnumerable<VocabularyPartReference> References { get; internal set; }
        public IEnumerable<VocabularyLinkReference> LinkReferences { get; internal set; }
        public IEnumerable<string> ContentTypes { get; internal set; }
        public PackageVocabulary Owner { get; internal set; }

        public bool AllowsChildRelationship(string relationshipType)
        {
            return Owner.AllParts.Where(
                part => References.Where(reference => reference.Name == part.Name).Count() > 0 &&
                    part.SourceRelationship == relationshipType).Count() > 0;
        }


        internal static IEnumerable<VocabularyPart> FromXElement(PackageVocabulary owner, XNamespace ns, XElement vocabularyElement)
        {
            return from partElement in vocabularyElement.Elements(ns + "partType")
                   select new VocabularyPart()
                   {
                       Name = partElement.GetAttributeValue("name"),
                       Description= partElement.GetAttributeValue("description"),
                       AllowExternal = Boolean.Parse(partElement.GetAttributeValue("allowExternal") ?? "false"),
                       AllowInteral = Boolean.Parse(partElement.GetAttributeValue("allowInternal") ?? "true"),
                       SourceRelationship = partElement.GetAttributeValue("sourceRelationship"),
                       RootElement = partElement.GetAttributeValue("rootElement"),
                       RootNamespace = partElement.GetAttributeValue("rootNamespace"),
                       ContentTypes = from contentTypeElement in partElement.Elements(ns + "contentType")
                                      select contentTypeElement.GetAttributeValue("name"),
                       References = VocabularyPartReference.FromXElement(owner, ns, partElement),
                       LinkReferences = VocabularyLinkReference.FromXElement(owner, ns, partElement),
                       Owner = owner 
                   };
        }
    }

    public class PackageVocabulary
    {
        public const string RT_OfficeDocument = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
        public const string CT_RelationshipPart = "application/vnd.openxmlformats-package.relationships+xml";

        public string Name { get; internal set; }
        public string StartPart { get; internal set; }
        public IEnumerable<VocabularyPart> Parts { get; internal set; }
        public IEnumerable<VocabularyPartReference> GlobalReferences { get; internal set; }
        public IEnumerable<VocabularyLink> Links { get; internal set; }
        public IEnumerable<PackageVocabulary> SupportingVocabularies { get; internal set; }

        public PackageVocabulary GetVocabulary(string name)
        {
            PackageVocabulary vocabulary = null;
            if (name == Name)
            {
                vocabulary = this;
            }
            else
            {
                vocabulary = (from v in SupportingVocabularies
                             where v.Name == name
                             select v).First();
            }
            return vocabulary;
        }

        public VocabularyPart GetPart(string name)
        {
            return (from p in Parts
                    where p.Name == name
                    select p).FirstOrDefault();
        }

        public IEnumerable<VocabularyPart> AllParts
        {
            get
            {
                foreach (VocabularyPart part in Parts)
                {
                    yield return part;
                }
                foreach (PackageVocabulary vocabulary in SupportingVocabularies)
                {
                    foreach (VocabularyPart part in vocabulary.Parts)
                    {
                        yield return part;
                    }
                }
            }
        }

        public IEnumerable<VocabularyPartReference> AllGlobalReferences
        {
            get
            {
                foreach (VocabularyPartReference reference in GlobalReferences)
                {
                    yield return reference;
                }
                foreach (PackageVocabulary vocabulary in SupportingVocabularies)
                {
                    foreach (VocabularyPartReference reference in vocabulary.GlobalReferences)
                    {
                        yield return reference;
                    }
                }
            }
        }

        public IEnumerable<VocabularyLink> AllLinks
        {
            get
            {
                foreach (VocabularyLink link in Links)
                {
                    yield return link;
                }

                foreach (PackageVocabulary vocabulary in SupportingVocabularies)
                {
                    foreach (VocabularyLink link in vocabulary.Links)
                    {
                        yield return link;
                    }
                }
            }
        }
    }
}