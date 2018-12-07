namespace PackageExplorer.UI.Dialogs
{
    partial class EncodingPickerDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._filenameLabel = new System.Windows.Forms.Label();
            this._encodingLabel = new System.Windows.Forms.Label();
            this._encodingField = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._filenameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._encodingLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._encodingField, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(495, 102);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _filenameLabel
            // 
            this._filenameLabel.AutoSize = true;
            this._filenameLabel.Location = new System.Drawing.Point(3, 0);
            this._filenameLabel.Name = "_filenameLabel";
            this._filenameLabel.Padding = new System.Windows.Forms.Padding(0, 9, 0, 6);
            this._filenameLabel.Size = new System.Drawing.Size(139, 28);
            this._filenameLabel.TabIndex = 0;
            this._filenameLabel.Text = "This will display the filename";
            // 
            // _encodingLabel
            // 
            this._encodingLabel.AutoSize = true;
            this._encodingLabel.Location = new System.Drawing.Point(3, 28);
            this._encodingLabel.Name = "_encodingLabel";
            this._encodingLabel.Size = new System.Drawing.Size(55, 13);
            this._encodingLabel.TabIndex = 1;
            this._encodingLabel.Text = "Encoding:";
            // 
            // _encodingField
            // 
            this._encodingField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._encodingField.DisplayMember = "DisplayName";
            this._encodingField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._encodingField.FormattingEnabled = true;
            this._encodingField.Location = new System.Drawing.Point(3, 44);
            this._encodingField.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this._encodingField.Name = "_encodingField";
            this._encodingField.Size = new System.Drawing.Size(489, 21);
            this._encodingField.TabIndex = 2;
            this._encodingField.ValueMember = "CodePage";
            // 
            // EncodingPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EncodingPickerDialog";
            this.Size = new System.Drawing.Size(495, 102);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _filenameLabel;
        private System.Windows.Forms.Label _encodingLabel;
        private System.Windows.Forms.ComboBox _encodingField;
    }
}
