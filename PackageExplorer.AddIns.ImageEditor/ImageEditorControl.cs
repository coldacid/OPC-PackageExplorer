using System;
using System.Windows.Forms;
using System.Drawing;

namespace PackageExplorer.AddIns.ImageEditor
{
    class ImageEditorControl
        : Panel
    {
        PictureBox _pictureBox = null;

        public Image Image
        {
            get { return _pictureBox.Image; }
            set { _pictureBox.Image = value; }
        }

        public ImageEditorControl()
        {
            AutoScroll = true;
            this.HScroll = true;
            this.VScroll = true;
            _pictureBox = new PictureBox();
            _pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            _pictureBox.Location = new Point(0, 0);
            Controls.Add(_pictureBox);
        }
    }
}
