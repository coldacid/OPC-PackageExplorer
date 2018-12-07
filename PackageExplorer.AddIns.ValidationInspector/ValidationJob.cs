using System;
using System.Xml.Schema;
using System.IO;
using System.Xml;
using PackageExplorer.ObjectModel;

namespace PackageExplorer.AddIns.ValidationInspector
{
    public partial class DefaultValidationService
    {
        abstract class ValidationJob
        {
            public SendValidationMessageCallback sendMessage { get; set; }
            public ValidationPackage Package { get; set; }
            public string[] CustomSchemaPaths { get; set; }
            public bool ShowInformationMessages { get; set; }
            XmlSchemaSet _combinedSet;

            protected ValidationJob()
            { }

            public abstract void Execute();

            protected void SendMessage(ValidationMessageType type, string message)
            {
                if (type != ValidationMessageType.Information || ShowInformationMessages)
                {
                    sendMessage(message);
                }
            }

            protected void SendInitializationMessage(string title)
            {
                SendMessage(ValidationMessageType.System,
                    RS.GetString(RS.RS_ValidationStarted,
                        title, DateTime.Now, Package.Name));
            }

            protected void SendValidationResult(ValidationResult result)
            {
                string message = result == ValidationResult.Valid ?
                    RS.GetString(RS.RS_ValidationSucceeded) :
                    RS.GetString(RS.RS_ValidationFailed);
                SendMessage(ValidationMessageType.System,
                    message);
            }
            protected XmlSchemaSet GetCombinedSet()
            {
                if (_combinedSet == null)
                {
                    _combinedSet = new XmlSchemaSet();
                    _combinedSet.Add(Package.GetSchemas());
                    foreach (string path in CustomSchemaPaths)
                    {
                        using (FileStream schemaStream = File.OpenRead(path))
                        {
                            _combinedSet.Add(XmlSchema.Read(schemaStream, null));
                        }
                    }
                }
                return _combinedSet;
            }

            protected ValidationResult ValidatePart(DocumentPart documentPart)
            {
                if (documentPart.IsXmlPart == false)
                {
                    SendMessage(ValidationMessageType.Warning,
                        RS.GetString(RS.RS_PartValidationSkipped, documentPart.Title));
                    return ValidationResult.Skipped;
                }
                SendMessage(ValidationMessageType.Information,
                        RS.GetString(RS.RS_PartValidationStarted,
                            documentPart.Title));
                XmlDocument document = new XmlDocument();
                try
                {
                    using (StreamReader reader =
                        new StreamReader(
                            documentPart.GetContent(), true))
                    {
                        document.Load(reader);
                    }
                }
                catch (XmlException e)
                {
                    SendMessage(
                        ValidationMessageType.Error,
                        RS.GetString(RS.RS_PartValidationXmlError,
                            documentPart.Title));
                    return ValidationResult.Invalid;
                }
                try
                {
                    document.Schemas.Add(GetCombinedSet());
                    document.Validate(null);
                    return ValidationResult.Valid;
                }
                catch (XmlSchemaValidationException e)
                {
                    SendMessage(ValidationMessageType.Error,
                        RS.GetString(
                            RS.RS_PartValidationFailed,
                            documentPart.Title, e.LineNumber, e.LinePosition));
                    SendMessage(ValidationMessageType.Error, e.Message);
                    return ValidationResult.Invalid;
                }
            }
        }
    }
}