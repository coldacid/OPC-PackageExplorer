using System;
using System.Windows.Forms;
using System.Text;

namespace PackageExplorer.UI.Workbench
{
    public interface IContentEditor
    {
        Guid EditorTypeID { get;}
        Control EditingControl { get;}
        bool IsDirty { get;}

        void SetReadOnly();
        void LoadFrom(IContentSource source, Encoding encoding);
        void SaveTo(IContentSource source, Encoding _encoding);
        void OnClose();
        
        event EventHandler<EventArgs> ContentChanged;

    }
}
