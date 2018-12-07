namespace PackageExplorer.AddIns.ValidationInspector
{
    partial class CustomSchemaSettingsPanel
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
            this._removeButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._customSchemasField = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _removeButton
            // 
            this._removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._removeButton.Location = new System.Drawing.Point(84, 3);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(75, 23);
            this._removeButton.TabIndex = 1;
            this._removeButton.Text = "Remove";
            this._removeButton.UseVisualStyleBackColor = true;
            this._removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // _addButton
            // 
            this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._addButton.Location = new System.Drawing.Point(3, 3);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 2;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._addButton);
            this.flowLayoutPanel1.Controls.Add(this._removeButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 255);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 30);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // _customSchemasField
            // 
            this._customSchemasField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._customSchemasField.FormattingEnabled = true;
            this._customSchemasField.Location = new System.Drawing.Point(0, 42);
            this._customSchemasField.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._customSchemasField.Name = "_customSchemasField";
            this._customSchemasField.Size = new System.Drawing.Size(384, 212);
            this._customSchemasField.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._descriptionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._customSchemasField, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 285);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(3, 0);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(362, 39);
            this._descriptionLabel.TabIndex = 0;
            this._descriptionLabel.Text = "The following list of XML Schema files will be used for validating packages. This" +
                " allows you to validate custom XML files during the normal validation process.";
            // 
            // CustomSchemaSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CustomSchemaSettingsPanel";
            this.Size = new System.Drawing.Size(384, 285);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _removeButton;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox _customSchemasField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _descriptionLabel;

    }
}
