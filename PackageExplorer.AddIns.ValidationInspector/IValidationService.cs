namespace PackageExplorer.AddIns.ValidationInspector
{
    using System;
    using System.Collections.Generic;
    using PackageExplorer.Core.Services;
    using PackageExplorer.Core;
    using PackageExplorer.ObjectModel;
    
    public interface IValidationService
        : IService
    {
        IEnumerable<string> ValidationPackages { get; }
        void Validate(Document document);
        void Validate(DocumentPart documentPart);

        event EventHandler<ValidationEventArgs> ValidationMessage;
    }
}
