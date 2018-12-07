using System;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.AddIns.ValidationInspector
{
    public partial class DefaultValidationService
    {
        class DocumentValidationJob
            : ValidationJob
        {
            public Document Document { get; set; }

            public override void Execute()
            {
                try
                {
                    SendInitializationMessage(Document.Filename);
                    ValidationResult globalResult = ValidationResult.Valid;
                    foreach (DocumentPart part in Document.AllParts)
                    {
                        if (ValidatePart(part) == ValidationResult.Invalid)
                        {
                            globalResult = ValidationResult.Invalid;
                        }
                    }
                    SendValidationResult(globalResult);
                }
                catch (Exception e)
                {
                    SendMessage(
                        ValidationMessageType.Information,
                        RS.GetString(RS.RS_CriticalError,
                            e.Message));
                }
            }
        }
    }
}
