using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PackageExplorer.Core.AddInModel;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace PackageExplorer.UI.Dialogs
{
    public partial class AboutDialog 
        : DialogContent
    {
        private System.Windows.Forms.PictureBox _logo;
        private System.Windows.Forms.ListBox _addInsField;
        private System.Windows.Forms.Label _installedAddInslabel;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private LinkLabel linkLabel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label _versionLabel;

        public override bool ValidOnLoad
        {
            get { return true; }
        }

        public AboutDialog()
        {
            InitializeComponent();
            Bitmap logo = null;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                "PackageExplorer.Resources.Logo.png"))
            {
                logo = (Bitmap)Bitmap.FromStream(stream);
            }
            _logo.Image = logo;
            _versionLabel.Text = "Version: " + Application.ProductVersion;
            _versionLabel.Location = new Point(
                 _logo.Right - _versionLabel.Width, _versionLabel.Location.Y);
        }

        protected override void OnLoad(EventArgs e)
        {
            foreach (AddIn addIn in AddInTreeSingleton.AddInTree.AddIns)
            {
                _addInsField.Items.Add(addIn.Name);
            }
            base.OnLoad(e);
        }

        void InitializeComponent()
        {
            this._logo = new System.Windows.Forms.PictureBox();
            this._addInsField = new System.Windows.Forms.ListBox();
            this._installedAddInslabel = new System.Windows.Forms.Label();
            this._versionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._logo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _logo
            // 
            this._logo.Location = new System.Drawing.Point(0, 0);
            this._logo.Margin = new System.Windows.Forms.Padding(0);
            this._logo.Name = "_logo";
            this._logo.Size = new System.Drawing.Size(300, 70);
            this._logo.TabIndex = 0;
            this._logo.TabStop = false;
            // 
            // _addInsField
            // 
            this._addInsField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._addInsField, 2);
            this._addInsField.FormattingEnabled = true;
            this._addInsField.Location = new System.Drawing.Point(0, 128);
            this._addInsField.Margin = new System.Windows.Forms.Padding(0);
            this._addInsField.Name = "_addInsField";
            this._addInsField.Size = new System.Drawing.Size(400, 108);
            this._addInsField.TabIndex = 1;
            // 
            // _installedAddInslabel
            // 
            this._installedAddInslabel.AutoSize = true;
            this._installedAddInslabel.Location = new System.Drawing.Point(3, 115);
            this._installedAddInslabel.Name = "_installedAddInslabel";
            this._installedAddInslabel.Size = new System.Drawing.Size(84, 13);
            this._installedAddInslabel.TabIndex = 5;
            this._installedAddInslabel.Text = "Installed add-Ins";
            // 
            // _versionLabel
            // 
            this._versionLabel.AutoSize = true;
            this._versionLabel.Location = new System.Drawing.Point(303, 0);
            this._versionLabel.Name = "_versionLabel";
            this._versionLabel.Size = new System.Drawing.Size(42, 13);
            this._versionLabel.TabIndex = 8;
            this._versionLabel.Text = "Version";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._logo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._addInsField, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this._installedAddInslabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._versionLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 237);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.linkLabel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 73);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(113, 13);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "By";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(22, 0);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(88, 13);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Wouter van Vugt";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 92);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel2.TabIndex = 12;
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(400, 237);
            this.Name = "AboutDialog";
            this.Size = new System.Drawing.Size(400, 237);
            ((System.ComponentModel.ISupportInitialize)(this._logo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenWebsite("http://blogs.code-counsel.net/wouter");
        }

        private void OpenWebsite(string web)
        {
            ProcessStartInfo psi = new ProcessStartInfo(web);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
    }
}