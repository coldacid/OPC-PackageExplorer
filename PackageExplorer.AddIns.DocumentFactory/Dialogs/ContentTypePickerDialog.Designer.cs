namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    partial class ContentTypePickerDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this._customContentTypeField = new System.Windows.Forms.TextBox();
            this._useCustomContentTypeField = new System.Windows.Forms.CheckBox();
            this._contentTypeField = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 9, 0, 3);
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Available content-types";
            // 
            // _customContentTypeField
            // 
            this._customContentTypeField.Dock = System.Windows.Forms.DockStyle.Top;
            this._customContentTypeField.Location = new System.Drawing.Point(0, 69);
            this._customContentTypeField.Name = "_customContentTypeField";
            this._customContentTypeField.Size = new System.Drawing.Size(462, 20);
            this._customContentTypeField.TabIndex = 7;
            this._customContentTypeField.Validating += new System.ComponentModel.CancelEventHandler(this.CustomContentTypeField_Validating);
            // 
            // _useCustomContentTypeField
            // 
            this._useCustomContentTypeField.AutoSize = true;
            this._useCustomContentTypeField.Dock = System.Windows.Forms.DockStyle.Top;
            this._useCustomContentTypeField.Location = new System.Drawing.Point(0, 46);
            this._useCustomContentTypeField.Name = "_useCustomContentTypeField";
            this._useCustomContentTypeField.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this._useCustomContentTypeField.Size = new System.Drawing.Size(462, 23);
            this._useCustomContentTypeField.TabIndex = 6;
            this._useCustomContentTypeField.Text = "Use a custom content-type";
            this._useCustomContentTypeField.UseVisualStyleBackColor = true;
            // 
            // _contentTypeField
            // 
            this._contentTypeField.Dock = System.Windows.Forms.DockStyle.Top;
            this._contentTypeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._contentTypeField.FormattingEnabled = true;
            this._contentTypeField.Location = new System.Drawing.Point(0, 25);
            this._contentTypeField.Name = "_contentTypeField";
            this._contentTypeField.Size = new System.Drawing.Size(462, 21);
            this._contentTypeField.TabIndex = 5;
            this._contentTypeField.Validating += new System.ComponentModel.CancelEventHandler(this.ContentTypeField_Validating);
            // 
            // ContentTypePickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._customContentTypeField);
            this.Controls.Add(this._useCustomContentTypeField);
            this.Controls.Add(this._contentTypeField);
            this.Controls.Add(this.label1);
            this.Name = "ContentTypePickerDialog";
            this.Size = new System.Drawing.Size(462, 116);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _customContentTypeField;
        private System.Windows.Forms.CheckBox _useCustomContentTypeField;
        private System.Windows.Forms.ComboBox _contentTypeField;

    }
}
