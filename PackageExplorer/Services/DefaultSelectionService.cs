namespace PackageExplorer.Services
{
    using System;
    using System.Collections;
    using System.ComponentModel.Design;
    using PackageExplorer.Core.Services;
using System.Collections.Specialized;

    public class DefaultSelectionService
        : ServiceBase, PackageExplorer.Services.ISelectionService
    {
        ArrayList _selectedComponents = null;
        Hashtable _selectionGroups = null;

        public object PrimarySelection
        {
            get 
            {
                return _selectedComponents.Count > 0 ? _selectedComponents[0] : null;
            }
        }

        public int SelectionCount
        {
            get { return _selectedComponents.Count; }
        }

        public DefaultSelectionService()
        {
            _selectedComponents = new ArrayList();
            _selectionGroups = new Hashtable();
        }

        public object GetSelectionForGroup(string group)
        {
            return _selectionGroups[group];
        }

        public void SetSelectionForGroup(string group, object selection)
        {
            _selectionGroups[group] = selection;
        }

        public bool GetComponentSelected(object component)
        {
            return _selectedComponents.Contains(component);
        }

        public ICollection GetSelectedComponents()
        {
            return _selectedComponents;
        }

        public void SetSelectedComponents(ICollection components, SelectionTypes selectionType)
        {
            OnSelectionChanging(EventArgs.Empty);
            _selectedComponents.Clear();
            if (components != null)
            {
                foreach (object component in components)
                {
                    if (component != null)
                    {
                        _selectedComponents.Add(component);
                    }
                }
            }
            OnSelectionChanged(EventArgs.Empty);
        }

        public void SetSelectedComponents(ICollection components)
        {
            SetSelectedComponents(components, SelectionTypes.Auto);
        }

        protected virtual void OnSelectionChanging(EventArgs e)
        {
            EventHandler handler = SelectionChanging;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler SelectionChanged;

        public event EventHandler SelectionChanging;
    }
}
