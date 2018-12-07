namespace PackageExplorer.AddIns.ValidationInspector
{
    using System;
    using System.Runtime.InteropServices;

    static class Win32
    {
        const int WM_VSCROLL = 277;
        const int SB_BOTTOM = 7;
        
        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        static extern int SendMessage(
             IntPtr hWnd,      // handle to destination window
             uint Msg,       // message
             IntPtr wParam,  // first message parameter
             IntPtr lParam   // second message parameter
             );

        public static void ScrollToBottom(IntPtr hwnd)
        {
            IntPtr wparam = new IntPtr(SB_BOTTOM);
            IntPtr lparam = new IntPtr(0);
            SendMessage(hwnd, WM_VSCROLL, wparam, lparam);
        }
    }
}
