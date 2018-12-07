using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageExplorer.UI.Dialogs
{
    partial class DialogWindow
        : System.Windows.Forms.Form
    {
        private void InitializeComponent()
        {
            System.Windows.Forms.FlowLayoutPanel _buttonPanel;
            System.Windows.Forms.Panel _barPanel;
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._dialogLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._errorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._errorImage = new System.Windows.Forms.PictureBox();
            this._errorLabel = new System.Windows.Forms.Label();
            _buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            _barPanel = new System.Windows.Forms.Panel();
            _buttonPanel.SuspendLayout();
            this._dialogLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this._errorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonPanel
            // 
            _buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            _buttonPanel.AutoSize = true;
            _buttonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _buttonPanel.Controls.Add(this._cancelButton);
            _buttonPanel.Controls.Add(this._okButton);
            _buttonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            _buttonPanel.Location = new System.Drawing.Point(0, 139);
            _buttonPanel.Margin = new System.Windows.Forms.Padding(0);
            _buttonPanel.Name = "_buttonPanel";
            _buttonPanel.Size = new System.Drawing.Size(307, 29);
            _buttonPanel.TabIndex = 0;
            // 
            // _cancelButton
            // 
            this._cancelButton.CausesValidation = false;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(229, 3);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.CausesValidation = false;
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(148, 3);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _barPanel
            // 
            _barPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            _barPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            _barPanel.Location = new System.Drawing.Point(0, 135);
            _barPanel.Margin = new System.Windows.Forms.Padding(0);
            _barPanel.Name = "_barPanel";
            _barPanel.Size = new System.Drawing.Size(307, 4);
            _barPanel.TabIndex = 1;
            // 
            // _dialogLayoutPanel
            // 
            this._dialogLayoutPanel.AutoSize = true;
            this._dialogLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._dialogLayoutPanel.ColumnCount = 1;
            this._dialogLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._dialogLayoutPanel.Controls.Add(_buttonPanel, 0, 3);
            this._dialogLayoutPanel.Controls.Add(_barPanel, 0, 2);
            this._dialogLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this._dialogLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dialogLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this._dialogLayoutPanel.Location = new System.Drawing.Point(5, 5);
            this._dialogLayoutPanel.Name = "_dialogLayoutPanel";
            this._dialogLayoutPanel.RowCount = 4;
            this._dialogLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._dialogLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._dialogLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this._dialogLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._dialogLayoutPanel.Size = new System.Drawing.Size(307, 168);
            this._dialogLayoutPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this._errorPanel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 24);
            this.panel1.TabIndex = 2;
            // 
            // _errorPanel
            // 
            this._errorPanel.AutoSize = true;
            this._errorPanel.BackColor = System.Drawing.Color.LightYellow;
            this._errorPanel.Controls.Add(this._errorImage);
            this._errorPanel.Controls.Add(this._errorLabel);
            this._errorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._errorPanel.Location = new System.Drawing.Point(0, 0);
            this._errorPanel.Name = "_errorPanel";
            this._errorPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this._errorPanel.Size = new System.Drawing.Size(301, 24);
            this._errorPanel.TabIndex = 4;
            this._errorPanel.Visible = false;
            // 
            // _errorImage
            // 
            this._errorImage.Image = global::PackageExplorer.ImageResources.error;
            this._errorImage.Location = new System.Drawing.Point(0, 3);
            this._errorImage.Margin = new System.Windows.Forms.Padding(0);
            this._errorImage.Name = "_errorImage";
            this._errorImage.Size = new System.Drawing.Size(20, 20);
            this._errorImage.TabIndex = 1;
            this._errorImage.TabStop = false;
            // 
            // _errorLabel
            // 
            this._errorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._errorLabel.AutoSize = true;
            this._errorLabel.Location = new System.Drawing.Point(23, 3);
            this._errorLabel.Name = "_errorLabel";
            this._errorLabel.Size = new System.Drawing.Size(95, 20);
            this._errorLabel.TabIndex = 0;
            this._errorLabel.Text = "The error message";
            // 
            // DialogWindow
            // 
            this.AcceptButton = this._okButton;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(317, 178);
            this.Controls.Add(this._dialogLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(325, 204);
            this.Name = "DialogWindow";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.Text = "Package Explorer";
            _buttonPanel.ResumeLayout(false);
            this._dialogLayoutPanel.ResumeLayout(false);
            this._dialogLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._errorPanel.ResumeLayout(false);
            this._errorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel _errorPanel;
        private System.Windows.Forms.PictureBox _errorImage;
        private System.Windows.Forms.Label _errorLabel;
    }
}
