namespace PackageExplorer.UI.Dialogs
{
    partial class ErrorDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._titleLabel = new System.Windows.Forms.Label();
            this._errorMessageField = new System.Windows.Forms.Label();
            this._reportErrorLabel = new System.Windows.Forms.LinkLabel();
            this._okButton = new System.Windows.Forms.Button();
            this._detailsField = new System.Windows.Forms.TextBox();
            this._viewDetailsButton = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _titleLabel
            // 
            this._titleLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this._titleLabel, 2);
            this._titleLabel.Location = new System.Drawing.Point(3, 0);
            this._titleLabel.MaximumSize = new System.Drawing.Size(436, 0);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(436, 26);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "An unexpected error has occured and the application needs to close. We are sorry " +
                "for the inconvenience. Please help make Package Explorer a better product by rep" +
                "orting this error.";
            // 
            // _errorMessageField
            // 
            this._errorMessageField.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this._errorMessageField, 2);
            this._errorMessageField.Location = new System.Drawing.Point(3, 26);
            this._errorMessageField.MaximumSize = new System.Drawing.Size(436, 0);
            this._errorMessageField.MinimumSize = new System.Drawing.Size(0, 50);
            this._errorMessageField.Name = "_errorMessageField";
            this._errorMessageField.Padding = new System.Windows.Forms.Padding(12, 6, 12, 0);
            this._errorMessageField.Size = new System.Drawing.Size(58, 50);
            this._errorMessageField.TabIndex = 1;
            this._errorMessageField.Text = "[error]";
            // 
            // _reportErrorLabel
            // 
            this._reportErrorLabel.AutoSize = true;
            this._reportErrorLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this._reportErrorLabel.Location = new System.Drawing.Point(3, 0);
            this._reportErrorLabel.Name = "_reportErrorLabel";
            this._reportErrorLabel.Size = new System.Drawing.Size(82, 13);
            this._reportErrorLabel.TabIndex = 2;
            this._reportErrorLabel.TabStop = true;
            this._reportErrorLabel.Text = "Report this error";
            this._reportErrorLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._reportErrorLabel_LinkClicked);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(372, 79);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(72, 23);
            this._okButton.TabIndex = 3;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _detailsField
            // 
            this._detailsField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._detailsField, 2);
            this._detailsField.Location = new System.Drawing.Point(3, 108);
            this._detailsField.MinimumSize = new System.Drawing.Size(4, 100);
            this._detailsField.Multiline = true;
            this._detailsField.Name = "_detailsField";
            this._detailsField.Size = new System.Drawing.Size(441, 152);
            this._detailsField.TabIndex = 4;
            // 
            // _viewDetailsButton
            // 
            this._viewDetailsButton.AutoSize = true;
            this._viewDetailsButton.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this._viewDetailsButton.Location = new System.Drawing.Point(91, 0);
            this._viewDetailsButton.Name = "_viewDetailsButton";
            this._viewDetailsButton.Size = new System.Drawing.Size(63, 13);
            this._viewDetailsButton.TabIndex = 5;
            this._viewDetailsButton.TabStop = true;
            this._viewDetailsButton.Text = "View details";
            this._viewDetailsButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._viewDetailsButton_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this._titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._detailsField, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this._errorMessageField, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._okButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 257);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this._reportErrorLabel);
            this.flowLayoutPanel1.Controls.Add(this._viewDetailsButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 79);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 13);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // ErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(447, 257);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(455, 34);
            this.Name = "ErrorDialog";
            this.Text = "ErrorDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _errorMessageField;
        private System.Windows.Forms.LinkLabel _reportErrorLabel;
        private System.Windows.Forms.TextBox _detailsField;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.LinkLabel _viewDetailsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}