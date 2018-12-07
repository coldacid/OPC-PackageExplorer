using System;
using System.Resources;

namespace PackageExplorer.Core.Services
{
    class Resource
    {
        string _groupName;
        ResourceManager _resourceManager;

        public string GroupName
        {
            get { return _groupName; }
        }
        
        public ResourceManager ResourceManager
        {
            get { return _resourceManager; }
        }

        public Resource(string groupName, ResourceManager manager)
        {
            _groupName = groupName;
            _resourceManager = manager;
        }
    }
}
