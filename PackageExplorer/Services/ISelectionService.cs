using System;
using PackageExplorer.Core.Services;

namespace PackageExplorer.Services
{
    public interface ISelectionService
        : System.ComponentModel.Design.ISelectionService, IService
    {
        object GetSelectionForGroup(string group);
        void SetSelectionForGroup(string group, object selection);
    }
}
