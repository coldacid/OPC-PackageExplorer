using System;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.AddIns.ValidationInspector
{
    public partial class DefaultValidationService
    {
        class DocumentPartValidationJob
            : ValidationJob
        {
            public DocumentPart DocumentPart { get; set; }

            public override void Execute()
            {
                try
                {
                    SendInitializationMessage(DocumentPart.Uri.ToString());
                    ValidationResult result = ValidatePart(DocumentPart);
                    SendValidationResult(result);
                }
                catch (Exception e)
                {
                    SendMessage(ValidationMessageType.Information,
                        RS.GetString(RS.RS_CriticalError,
                            e.Message));
                }
            }
        }
    }
}
