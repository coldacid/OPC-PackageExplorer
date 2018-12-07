using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Timer = System.Threading.Timer;
using System.Threading;
using System.IO;
using System.Reflection;

namespace PackageExplorer.UI.Controls
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {            
            InitializeComponent();
            Bitmap background = null;
            
            using (Stream stream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    "PackageExplorer.Resources.SplashBackground.png"))
            {
                background = (Bitmap)Bitmap.FromStream(stream); 
            }
            using (Font font = new Font("Sans Serif", 6f))
            {
                using (Graphics graphics = Graphics.FromImage(background))
                {
                    graphics.DrawString(
                        Application.ProductVersion,
                        font, SystemBrushes.ControlText, 350f, 90f);
                }
            }
            ClientSize = background.Size;
            BackgroundImage = background;
        }
    }
}