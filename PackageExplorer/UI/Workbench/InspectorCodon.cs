using System;
using PackageExplorer.Core.AddInModel.Codons;
using System.Collections;
using PackageExplorer.Core.AddInModel;
using System.Windows.Forms;
using PackageExplorer.Core.Services;
using WeifenLuo.WinFormsUI;
using WeifenLuo.WinFormsUI.Docking;

namespace PackageExplorer.UI.Workbench
{
    [CodonName("Inspector")]
    [RequiredAttribute("title")]
    [RequiredAttribute("inspectorID")]
    class InspectorCodon
        : ClassCodon
    {
        string _title;
        Guid _inspectorID;
        string _inspectorMenuTreePath;
        DockState _defaultDockState = DockState.DockLeft;
        DockState _startupDockState = DockState.Hidden;

        public DockState StartupDockState
        {
            get { return _startupDockState; }
            set { _startupDockState = value; }
        }

        public DockState DefaultDockState
        {
            get { return _defaultDockState; }
            set { _defaultDockState = value; }
        }

        public string InspectorMenuTreePath
        {
            get { return _inspectorMenuTreePath; }
            set { _inspectorMenuTreePath = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Guid InspectorID
        {
            get { return _inspectorID; }
            set { _inspectorID = value; }
        }

        public override object BuildItem(object owner, ArrayList subItems)
        {
            IContentExplorer explorer = null;
            object baseItem = base.BuildItem(owner, subItems);
            explorer = baseItem as IContentExplorer;
            if (explorer == null)
            {
                explorer = new ContentExplorerWrapper(_inspectorID, (Control)baseItem);
            }
            return explorer;
        }
    }
}
