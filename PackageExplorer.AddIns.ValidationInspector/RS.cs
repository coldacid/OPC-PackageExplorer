using System;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.ValidationInspector
{
    static class RS
    {
        static ResourceService _resourceService = null;
        
        public const string RS_CriticalError =
            "ValidationInspector, CriticalError";
        public const string RS_ValidationStarted =
            "ValidationInspector, ValidationStarted";
        public const string RS_CustomSchemaLoadError =
            "ValidationInspector, CustomSchemaLoadError";
        public const string RS_PartValidationStarted =
            "ValidationInspector, PartValidationStarted";
        public const string RS_PartValidationXmlError =
            "ValidationInspector, PartValidationXmlError";
        public const string RS_PartValidationSkipped =
            "ValidationInspector, PartValidationSkipped";
        public const string RS_PartValidationFailed =
            "ValidationInspector, PartValidationFailed";
        public const string RS_ValidationFailed =
            "ValidationInspector, ValidationFailed";
        public const string RS_ValidationSucceeded =
            "ValidationInspector, ValidationSucceeded";
        public const string RS_CustomSchemaXmlError =
            "ValidationInspector, CustomSchemaXmlError";
        public const string RS_CustomSchemaLoad =
            "ValidationInspector, CustomSchemaLoad";

        static RS()
        {
            _resourceService = ServiceManager.GetService<ResourceService>();
        }

        public static string GetString(string resourceName)
        {
            return _resourceService.GetString(resourceName);
        }

        public static string GetString(string resourceName,
            params object[] formatParameters)
        {
            return String.Format(_resourceService.GetString(resourceName),
                formatParameters);
        }
    }
}
