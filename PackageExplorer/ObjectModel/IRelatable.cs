using System;
using System.IO.Packaging;
using PackageExplorer.ObjectModel.Vocabulary;

namespace PackageExplorer.ObjectModel
{
    interface IRelatable
    {
        PackageRelationship RelateTo(DocumentPart part, string relationshipType, string relationshipID);
        PackageRelationship RelateTo(Uri externalUri, string relationshipType, string relationshipID);
        void RemoveRelationship(string relationshipID);
        VocabularyPart GetVocabularyPart(string relationshipType);
    }
}
