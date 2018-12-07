using System;
using PackageExplorer.UI.Workbench;
using System.Windows.Forms;

namespace PackageExplorer
{
    static partial class Program
    {
        class WindowPickerMessageFilter
            : IMessageFilter
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;

            WindowPicker _windowPicker;
            Form _workbenchForm;

            public WindowPickerMessageFilter(Form workbenchForm)
            {
                _workbenchForm = workbenchForm;
                _windowPicker = new WindowPicker();
                _windowPicker.StartPosition = FormStartPosition.CenterScreen;
            }

            public bool PreFilterMessage(ref Message m)
            {
                Keys keyData = ((Keys)((int)((long)m.WParam))) | Control.ModifierKeys;
                Keys keys = keyData & Keys.KeyCode;
                Keys keys2 = keyData & ~Keys.KeyCode;
                if (m.Msg == WM_KEYDOWN &&
                    keys == Keys.Tab && keys2 == Keys.Control)
                {
                    if (WorkbenchSingleton.DefaultWorkbench.ActiveDocumentWindow != null)
                    {
                        if (_windowPicker.Visible == false)
                        {
                            _windowPicker.InitializeItems();
                            _windowPicker.Show(_workbenchForm);
                        }
                        else
                        {
                            _windowPicker.SelectNext();
                        }
                        return true;
                    }
                }
                if (_windowPicker.Visible && m.Msg == WM_KEYUP && keys == Keys.ControlKey)
                {
                    _windowPicker.ActivateSelectedDocumentWindow();
                    return true;
                }
                return false;
            }
        }
    }
}
