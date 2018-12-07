using System;
using PackageExplorer.Core.Services;

namespace PackageExplorer.AddIns.XmlEditor
{
    static class RS
    {
        static ResourceService _resourceService = null;
        const string RS_FormatDocumentErrorMessage =
            "XmlEditor,FormatDocumentError";

        public static string FormatDocumentErrorMessage
        {
            get
            {
                return _resourceService.GetString(
                    RS_FormatDocumentErrorMessage);
            }
        }

        static RS()
        {
            _resourceService = ServiceManager.GetService<ResourceService>();
        }

    }
}
