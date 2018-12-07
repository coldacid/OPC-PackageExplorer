namespace PackageExplorer.UI.Dialogs
{
    partial class PackagingErrorsDialog
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
            this._errorsLabel = new System.Windows.Forms.Label();
            this._layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._errorsField = new System.Windows.Forms.ListBox();
            this._layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _errorsLabel
            // 
            this._errorsLabel.AutoSize = true;
            this._errorsLabel.Location = new System.Drawing.Point(3, 3);
            this._errorsLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this._errorsLabel.Name = "_errorsLabel";
            this._errorsLabel.Size = new System.Drawing.Size(221, 13);
            this._errorsLabel.TabIndex = 0;
            this._errorsLabel.Text = "The document {0} contains packaging errors.";
            // 
            // _layoutPanel
            // 
            this._layoutPanel.ColumnCount = 1;
            this._layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._layoutPanel.Controls.Add(this._errorsField, 0, 1);
            this._layoutPanel.Controls.Add(this._errorsLabel, 0, 0);
            this._layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._layoutPanel.Location = new System.Drawing.Point(0, 0);
            this._layoutPanel.Name = "_layoutPanel";
            this._layoutPanel.RowCount = 2;
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._layoutPanel.Size = new System.Drawing.Size(405, 203);
            this._layoutPanel.TabIndex = 1;
            // 
            // _errorsField
            // 
            this._errorsField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._errorsField.FormattingEnabled = true;
            this._errorsField.HorizontalScrollbar = true;
            this._errorsField.Location = new System.Drawing.Point(0, 19);
            this._errorsField.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._errorsField.Name = "_errorsField";
            this._errorsField.ScrollAlwaysVisible = true;
            this._errorsField.Size = new System.Drawing.Size(405, 173);
            this._errorsField.TabIndex = 1;
            // 
            // PackagingErrorsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._layoutPanel);
            this.Name = "PackagingErrorsDialog";
            this.Size = new System.Drawing.Size(405, 203);
            this._layoutPanel.ResumeLayout(false);
            this._layoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _errorsLabel;
        private System.Windows.Forms.TableLayoutPanel _layoutPanel;
        private System.Windows.Forms.ListBox _errorsField;

    }
}
