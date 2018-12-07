using System;
using PackageExplorer.Core.AddInModel.Conditions;

namespace PackageExplorer.ObjectModel
{
    [ConditionName("HasDocumentRelationshipPart")]
    public class HasDocumentRelationshipPartCondition
        : ConditionBase
    {
        public override bool IsValid(object caller)
        {
            Document document = Application.ActiveDocument;
            return document != null && document.RelationshipPart != null;
        }
    }
}
