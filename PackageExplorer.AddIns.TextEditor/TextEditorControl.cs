#region [===== Using =====]
using System;
using System.Windows.Forms;
#endregion

namespace PackageExplorer.AddIns.TextEditor
{
    class TextEditorControl
        : TextBox
    {
        #region [===== Constructors =====]
        public TextEditorControl()
        {
            Multiline = true;
            ScrollBars = ScrollBars.Both;
        }
        #endregion
    }
}
