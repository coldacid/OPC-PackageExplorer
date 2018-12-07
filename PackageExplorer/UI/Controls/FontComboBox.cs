using System;
using System.Drawing;
using System.Windows.Forms;

namespace PackageExplorer.UI.Controls
{
    class FontComboBox
        : ComboBox
    {
        public FontComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DisplayMember = "Name";
        }

        protected override void SetItemCore(int index, object value)
        {
            if (value is FontFamily == false)
            {
                throw new ArgumentException("Only FontFamily items allowed.");
            }
            base.SetItemCore(index, value);
        }

        protected override void SetItemsCore(System.Collections.IList values)
        {
            foreach (object value in values)
            {
                FontFamily family = value as FontFamily;

                if (family == null)
                {
                    throw new ArgumentException("Only FontFamily items allowed.");
                }
            }
            base.SetItemsCore(values);
        }       

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                base.OnDrawItem(e);
                return;
            }
            e.DrawBackground();

            if ((e.State & DrawItemState.Focus) != 0)
            {
                e.DrawFocusRectangle();
            }
            Brush brush = null;
            System.Drawing.Font font = null;
            FontFamily family = null;
            family = (FontFamily)Items[e.Index];
            try
            {
                brush = new SolidBrush(e.ForeColor);
                if (family.IsStyleAvailable(FontStyle.Regular))
                {
                    font = new Font(family.Name, Font.Size);
                }
                else if (family.IsStyleAvailable(FontStyle.Bold))
                {
                    font = new Font(family.Name, Font.Size, FontStyle.Bold);
                }
                else if (family.IsStyleAvailable(FontStyle.Italic))
                {
                    font = new Font(family.Name, Font.Size, FontStyle.Italic);
                }
                else if (family.IsStyleAvailable(FontStyle.Strikeout))
                {
                    font = new Font(family.Name, Font.Size, FontStyle.Strikeout);
                }
                else if (family.IsStyleAvailable(FontStyle.Underline))
                {
                    font = new Font(family.Name, Font.Size, FontStyle.Underline);
                }
                else
                {
                    font = Font;
                }
                e.Graphics.DrawString(family.Name, font, brush, e.Bounds);
            }
            finally
            {
                if (brush != null)
                {
                    brush.Dispose();
                    brush = null;
                }
                if (font != null) 
                {
                    font.Dispose();
                    font = null;
                }
            }
            base.OnDrawItem(e);
        }
    }
}
