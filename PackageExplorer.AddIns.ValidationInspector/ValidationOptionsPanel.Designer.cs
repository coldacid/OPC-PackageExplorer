namespace PackageExplorer.AddIns.ValidationInspector
{
    partial class ValidationOptionsPanel
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
            this._showInfoMessagesField = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _showInfoMessagesField
            // 
            this._showInfoMessagesField.AutoSize = true;
            this._showInfoMessagesField.Location = new System.Drawing.Point(3, 3);
            this._showInfoMessagesField.Name = "_showInfoMessagesField";
            this._showInfoMessagesField.Size = new System.Drawing.Size(157, 17);
            this._showInfoMessagesField.TabIndex = 0;
            this._showInfoMessagesField.Text = "Show information messages";
            this._showInfoMessagesField.UseVisualStyleBackColor = true;
            this._showInfoMessagesField.CheckedChanged += new System.EventHandler(this.ShowInfoMessagesField_CheckedChanged);
            // 
            // ValidationOptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._showInfoMessagesField);
            this.Name = "ValidationOptionsPanel";
            this.Size = new System.Drawing.Size(384, 285);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _showInfoMessagesField;

    }
}
