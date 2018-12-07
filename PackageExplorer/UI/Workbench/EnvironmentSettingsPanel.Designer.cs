namespace PackageExplorer.UI.Workbench
{
    partial class EnvironmentSettingsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._clearMRUListButton = new System.Windows.Forms.Button();
            this._showPackagingErrorsField = new System.Windows.Forms.CheckBox();
            this._showStartpageField = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._numberOfRecentDocumentsLabel = new System.Windows.Forms.Label();
            this._numberOfRecentDocumentsField = new System.Windows.Forms.NumericUpDown();
            this._layoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numberOfRecentDocumentsField)).BeginInit();
            this.SuspendLayout();
            // 
            // _layoutPanel
            // 
            this._layoutPanel.ColumnCount = 2;
            this._layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._layoutPanel.Controls.Add(this.panel1, 1, 3);
            this._layoutPanel.Controls.Add(this._showPackagingErrorsField, 1, 0);
            this._layoutPanel.Controls.Add(this._showStartpageField, 1, 1);
            this._layoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this._layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._layoutPanel.Location = new System.Drawing.Point(0, 0);
            this._layoutPanel.Name = "_layoutPanel";
            this._layoutPanel.RowCount = 4;
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._layoutPanel.Size = new System.Drawing.Size(384, 285);
            this._layoutPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this._clearMRUListButton);
            this.panel1.Location = new System.Drawing.Point(3, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 207);
            this.panel1.TabIndex = 4;
            // 
            // _clearMRUListButton
            // 
            this._clearMRUListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._clearMRUListButton.Location = new System.Drawing.Point(195, 167);
            this._clearMRUListButton.Name = "_clearMRUListButton";
            this._clearMRUListButton.Size = new System.Drawing.Size(169, 23);
            this._clearMRUListButton.TabIndex = 3;
            this._clearMRUListButton.Text = "Clear Recent Documents";
            this._clearMRUListButton.UseVisualStyleBackColor = true;
            // 
            // _showPackagingErrorsField
            // 
            this._showPackagingErrorsField.AutoSize = true;
            this._showPackagingErrorsField.Location = new System.Drawing.Point(3, 3);
            this._showPackagingErrorsField.Name = "_showPackagingErrorsField";
            this._showPackagingErrorsField.Size = new System.Drawing.Size(253, 17);
            this._showPackagingErrorsField.TabIndex = 1;
            this._showPackagingErrorsField.Text = "Show packaging errors on opening a document.";
            this._showPackagingErrorsField.UseVisualStyleBackColor = true;
            this._showPackagingErrorsField.CheckedChanged += new System.EventHandler(this.ShowPackagingErrorsField_CheckedChanged);
            // 
            // _showStartpageField
            // 
            this._showStartpageField.AutoSize = true;
            this._showStartpageField.Location = new System.Drawing.Point(3, 26);
            this._showStartpageField.Name = "_showStartpageField";
            this._showStartpageField.Size = new System.Drawing.Size(211, 17);
            this._showStartpageField.TabIndex = 2;
            this._showStartpageField.Text = "Show startpage when application starts";
            this._showStartpageField.UseVisualStyleBackColor = true;
            this._showStartpageField.CheckedChanged += new System.EventHandler(this.ShowStartpageField_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this._numberOfRecentDocumentsLabel);
            this.flowLayoutPanel1.Controls.Add(this._numberOfRecentDocumentsField);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 26);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // _numberOfRecentDocumentsLabel
            // 
            this._numberOfRecentDocumentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._numberOfRecentDocumentsLabel.AutoSize = true;
            this._numberOfRecentDocumentsLabel.Location = new System.Drawing.Point(3, 0);
            this._numberOfRecentDocumentsLabel.Name = "_numberOfRecentDocumentsLabel";
            this._numberOfRecentDocumentsLabel.Size = new System.Drawing.Size(198, 26);
            this._numberOfRecentDocumentsLabel.TabIndex = 0;
            this._numberOfRecentDocumentsLabel.Text = "Number of recent documents to maintain";
            this._numberOfRecentDocumentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _numberOfRecentDocumentsField
            // 
            this._numberOfRecentDocumentsField.Location = new System.Drawing.Point(207, 3);
            this._numberOfRecentDocumentsField.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this._numberOfRecentDocumentsField.Name = "_numberOfRecentDocumentsField";
            this._numberOfRecentDocumentsField.Size = new System.Drawing.Size(44, 20);
            this._numberOfRecentDocumentsField.TabIndex = 6;
            this._numberOfRecentDocumentsField.ValueChanged += new System.EventHandler(this.NumberOfRecentDocumentsField_ValueChanged);
            // 
            // EnvironmentSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._layoutPanel);
            this.Name = "EnvironmentSettingsPanel";
            this.Size = new System.Drawing.Size(384, 285);
            this._layoutPanel.ResumeLayout(false);
            this._layoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numberOfRecentDocumentsField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _layoutPanel;
        private System.Windows.Forms.CheckBox _showPackagingErrorsField;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _clearMRUListButton;
        private System.Windows.Forms.CheckBox _showStartpageField;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label _numberOfRecentDocumentsLabel;
        private System.Windows.Forms.NumericUpDown _numberOfRecentDocumentsField;
    }
}
