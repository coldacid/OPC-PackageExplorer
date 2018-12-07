namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    partial class NewDocumentDialog
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._vocabularyField = new System.Windows.Forms.ListView();
            this._vocabularyIcons = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this._contentTypeField = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 9, 0, 3);
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vocabulary:";
            // 
            // _vocabularyField
            // 
            this._vocabularyField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._vocabularyField.HideSelection = false;
            this._vocabularyField.LabelWrap = false;
            this._vocabularyField.LargeImageList = this._vocabularyIcons;
            this._vocabularyField.Location = new System.Drawing.Point(3, 28);
            this._vocabularyField.MultiSelect = false;
            this._vocabularyField.Name = "_vocabularyField";
            this._vocabularyField.Size = new System.Drawing.Size(492, 116);
            this._vocabularyField.TabIndex = 1;
            this._vocabularyField.UseCompatibleStateImageBehavior = false;
            this._vocabularyField.Validating += new System.ComponentModel.CancelEventHandler(this._vocabularyField_Validating);
            this._vocabularyField.SelectedIndexChanged += new System.EventHandler(this.VocabularyField_SelectedIndexChanged);
            // 
            // _vocabularyIcons
            // 
            this._vocabularyIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._vocabularyIcons.ImageSize = new System.Drawing.Size(32, 32);
            this._vocabularyIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 147);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
            this.label2.Size = new System.Drawing.Size(199, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Content type for the main document part:";
            // 
            // _contentTypeField
            // 
            this._contentTypeField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._contentTypeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._contentTypeField.FormattingEnabled = true;
            this._contentTypeField.Location = new System.Drawing.Point(3, 172);
            this._contentTypeField.Name = "_contentTypeField";
            this._contentTypeField.Size = new System.Drawing.Size(492, 21);
            this._contentTypeField.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._contentTypeField, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this._vocabularyField, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 196);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // NewDocumentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NewDocumentDialog";
            this.Size = new System.Drawing.Size(498, 196);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView _vocabularyField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _contentTypeField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ImageList _vocabularyIcons;
    }
}
