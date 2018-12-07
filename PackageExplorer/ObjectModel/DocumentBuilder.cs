using System;
using System.IO.Packaging;
using System.Collections.Generic;
using PackageExplorer.ObjectModel.Extension;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using PackageExplorer.ObjectModel.Vocabulary;

namespace PackageExplorer.ObjectModel
{
    internal static class DocumentBuilder
    {
        internal static void InitializeCollections(Document owner,
            PackageRelationshipCollection relationships, 
            DocumentPartCollection parts,
            ExternalRelationshipCollection externalRelationships,
            IRelatable parent)
        {
            foreach (PackageRelationship relationship in relationships)
            {
                if (relationship.TargetMode == TargetMode.Internal)
                {
                    Uri partUri = PackUriHelper.ResolvePartUri(
                        relationship.SourceUri, relationship.TargetUri);
                    DocumentPart part = owner.GetPart(partUri);
                    if (part != null)
                    {
                        VocabularyPart vocabularyPart = parent.GetVocabularyPart(relationship.RelationshipType);
                        if (vocabularyPart == null)
                        {
                            owner.PackagingErrors.Add(
                                new PackagingError(
                                    String.Format("Part {0} is related to {1} using a relationship type which is not expected",
                                    relationship.SourceUri, relationship.TargetUri), false));
                        }
                        else if (part.VocabularyPart != null && part.VocabularyPart.Name != vocabularyPart.Name)
                        {
                            owner.PackagingErrors.Add(
                                new PackagingError(
                                    string.Format("Part {0} relates to {1} using a relationship type which is not expected based on the content-type",
                                    relationship.SourceUri, relationship.TargetUri), false));
                        }
                        else if (part.VocabularyPart == null)
                        {
                            part.VocabularyPart = vocabularyPart;
                        }
                        parts.AddInternal(part, relationship);
                    }
                    else
                    {
                        string message = String.Format(
                            "The relationship {0} from {1} points to a location that does not exist.",
                            relationship.Id, relationship.SourceUri);
                        owner.PackagingErrors.Add(
                            new PackagingError(message, false));
                    }
                }
                else
                {
                    externalRelationships.AddInternal(relationship,
                        new ExternalRelationship(externalRelationships, relationship.TargetUri));
                }
            }
        }

        internal static PackageVocabulary DetermineVocabulary(Package package)
        {
            PackageVocabulary vocabulary = null;
            PackageRelationship relationship  = 
                package.GetRelationshipByType(PackageVocabulary.RT_OfficeDocument);
            if (relationship != null)
            {
                Uri partUri = PackUriHelper.ResolvePartUri(
                    relationship.SourceUri, relationship.TargetUri);
                PackagePart part = package.GetPart(partUri);
                IVocabularyService service = ServiceManager.GetService<IVocabularyService>();
                vocabulary = service.GetVocabularyByContentType(part.ContentType);
            }
            return vocabulary;
        }
    }
}
