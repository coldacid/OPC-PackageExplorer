using System;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.ObjectModel
{
    [ConditionName("HasDocumentPartRelationshipPart")]
    public class HasDocumentPartRelationshipPartCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            bool isValid = false;
            Document document = Application.ActiveDocument;
            if (document != null)
            {
                DocumentPart part = document.ActivePart;
                if (part != null)
                {
                    isValid = part.RelationshipPart != null;
                }
            }
            return isValid;
        }
    }
}
