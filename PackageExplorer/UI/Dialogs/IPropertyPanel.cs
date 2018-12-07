using System;
using System.Windows.Forms;

namespace PackageExplorer.UI.Dialogs
{
    public class PropertyPanel
        : UserControl
    {
        protected internal bool IsDirty { get; set; }
        
        public virtual bool ApplyChanges() 
        { 
            return true; 
        }
    }
}
