namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    partial class DeletePartDialog
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
            System.Windows.Forms.ColumnHeader locationHeader;
            System.Windows.Forms.ColumnHeader contentTypeHeader;
            System.Windows.Forms.ColumnHeader vocabularyType;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._partSelectionLabel = new System.Windows.Forms.Label();
            this._partField = new System.Windows.Forms.ComboBox();
            this._childSelectionLabel = new System.Windows.Forms.Label();
            this._childPartField = new System.Windows.Forms.ListView();
            this._deleteChildrenField = new System.Windows.Forms.CheckBox();
            locationHeader = new System.Windows.Forms.ColumnHeader();
            contentTypeHeader = new System.Windows.Forms.ColumnHeader();
            vocabularyType = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // locationHeader
            // 
            locationHeader.Text = "Location";
            locationHeader.Width = 185;
            // 
            // contentTypeHeader
            // 
            contentTypeHeader.Text = "Content Type";
            contentTypeHeader.Width = 154;
            // 
            // vocabularyType
            // 
            vocabularyType.Text = "Vocabulary Type";
            vocabularyType.Width = 166;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._partSelectionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._partField, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._childSelectionLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._childPartField, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this._deleteChildrenField, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 259);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _partSelectionLabel
            // 
            this._partSelectionLabel.AutoSize = true;
            this._partSelectionLabel.Location = new System.Drawing.Point(3, 0);
            this._partSelectionLabel.Name = "_partSelectionLabel";
            this._partSelectionLabel.Padding = new System.Windows.Forms.Padding(0, 9, 0, 3);
            this._partSelectionLabel.Size = new System.Drawing.Size(209, 25);
            this._partSelectionLabel.TabIndex = 0;
            this._partSelectionLabel.Text = "Select the part to delete from the package:";
            // 
            // _partField
            // 
            this._partField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._partField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._partField.FormattingEnabled = true;
            this._partField.Location = new System.Drawing.Point(3, 28);
            this._partField.Name = "_partField";
            this._partField.Size = new System.Drawing.Size(435, 21);
            this._partField.TabIndex = 1;
            this._partField.Validating += new System.ComponentModel.CancelEventHandler(this.PartField_Validating);
            // 
            // _childSelectionLabel
            // 
            this._childSelectionLabel.AutoSize = true;
            this._childSelectionLabel.Location = new System.Drawing.Point(3, 52);
            this._childSelectionLabel.Name = "_childSelectionLabel";
            this._childSelectionLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
            this._childSelectionLabel.Size = new System.Drawing.Size(283, 22);
            this._childSelectionLabel.TabIndex = 3;
            this._childSelectionLabel.Text = "The following parts will become unreachable after deletion.";
            // 
            // _childPartField
            // 
            this._childPartField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._childPartField.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            locationHeader,
            contentTypeHeader,
            vocabularyType});
            this._childPartField.HideSelection = false;
            this._childPartField.Location = new System.Drawing.Point(3, 100);
            this._childPartField.Name = "_childPartField";
            this._childPartField.Size = new System.Drawing.Size(435, 156);
            this._childPartField.TabIndex = 2;
            this._childPartField.UseCompatibleStateImageBehavior = false;
            this._childPartField.View = System.Windows.Forms.View.Details;
            // 
            // _deleteChildrenField
            // 
            this._deleteChildrenField.AutoSize = true;
            this._deleteChildrenField.Checked = true;
            this._deleteChildrenField.CheckState = System.Windows.Forms.CheckState.Checked;
            this._deleteChildrenField.Location = new System.Drawing.Point(3, 77);
            this._deleteChildrenField.Name = "_deleteChildrenField";
            this._deleteChildrenField.Size = new System.Drawing.Size(318, 17);
            this._deleteChildrenField.TabIndex = 4;
            this._deleteChildrenField.Text = "Delete these unreachable chlildren together with my selection.";
            this._deleteChildrenField.UseVisualStyleBackColor = true;
            // 
            // DeletePartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DeletePartDialog";
            this.Size = new System.Drawing.Size(441, 259);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _partSelectionLabel;
        private System.Windows.Forms.ComboBox _partField;
        private System.Windows.Forms.Label _childSelectionLabel;
        private System.Windows.Forms.ListView _childPartField;
        private System.Windows.Forms.CheckBox _deleteChildrenField;
    }
}
