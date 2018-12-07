#region [===== Using =====]
using System;
using System.Reflection;
using System.Resources;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using PackageExplorer.Core.AddInModel;
#endregion

namespace PackageExplorer.Core.Services
{
    public class ResourceService : ServiceBase
    {
        Dictionary<string, List<Resource>> _resources = null;

        public override void InitializeService()
        {
            _resources = new Dictionary<string, List<Resource>>();
            IAddInTreeNode resourcesNode =
                AddInTreeSingleton.AddInTree.GetTreeNode("/core/resources");
            if (resourcesNode != null)
            {
                foreach (Resource resource in
                    resourcesNode.BuildChildItems(this))
                {
                    if (_resources.ContainsKey(resource.GroupName) == false)
                    {
                        _resources.Add(resource.GroupName, new List<Resource>());
                    }
                    _resources[resource.GroupName].Add(resource);
                }
            }
            base.InitializeService();
        }

        public string GetString(string resourceName)
        {
            string value = null;
            string[] resourceNames = resourceName.Split(',');
            string groupName = resourceNames[0].Trim();
            string name = resourceNames[1].Trim();
            if (_resources.ContainsKey(groupName))
            {
                foreach (Resource resource in _resources[groupName])
                {
                    try
                    {
                        value = resource.ResourceManager.GetString(name);
                        if (value != null)
                        {
                            break;
                        }
                    }
                    catch (MissingManifestResourceException)
                    {
                    }
                }
            }
            return value;
        }

        public Image GetImage(string resourceName)
        {
            string group = null;
            string name = null;
            string[] resourceItems = resourceName.Split(',');
            group = resourceItems[0].Trim();
            name = resourceItems[1].Trim();
            Image value = null;
            if (_resources.ContainsKey(group))
            {
                foreach (Resource resource in _resources[group])
                {
                    try
                    {
                        value = resource.ResourceManager.GetObject(name) as Image;
                        if (value != null)
                        {
                            break;
                        }
                    }
                    catch (MissingManifestResourceException)
                    {
                    }
                }
            }
            return value;
        }
    }
}
