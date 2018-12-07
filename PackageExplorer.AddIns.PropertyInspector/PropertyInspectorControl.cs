#region [===== Using =====]
using System;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using PackageExplorer.Services;
using PackageExplorer.UI;
#endregion

namespace PackageExplorer.AddIns.PropertyInspector
{
    class PropertyInspectorControl : UserControl
    {
        #region [===== Static fields =====]
        public static readonly Guid EditorID = new Guid("{F85543F4-2F4C-4612-9502-44F83F6F168B}");
        #endregion

        #region [===== Instance fields =====]
        PropertyGrid _properties = null;
        ISelectionService _selectionService = null;
        #endregion

        #region [===== Constructors =====]
        public PropertyInspectorControl()
        {
            _properties = new PropertyGrid();
            _properties.Dock = DockStyle.Fill;
            Controls.Add(_properties);
        }
        #endregion

        #region [===== Protected instance methods =====]
        protected override void OnCreateControl()
        {
            ISelectionService service = (ISelectionService)
                ServiceManager.Services[typeof(ISelectionService)];
            if (service != null)
            {
                service.SelectionChanged += new EventHandler(SelectionService_SelectionChanged);
            }
            base.OnCreateControl();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ISelectionService service = (ISelectionService)
                    ServiceManager.Services[typeof(ISelectionService)];
                if (service != null)
                {
                    service.SelectionChanged -= new EventHandler(SelectionService_SelectionChanged);
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region [===== Private instance methods =====]
        void SelectionService_SelectionChanged(object sender, EventArgs e)
        {
            ISelectionService service = (ISelectionService)
                ServiceManager.Services[typeof(ISelectionService)];
            if (service != null)
            {
                object[] selectedObjects = new object[service.SelectionCount];
                service.GetSelectedComponents().CopyTo(selectedObjects, 0);
                _properties.SelectedObjects = selectedObjects;
            }
        }
        #endregion
    }
}
