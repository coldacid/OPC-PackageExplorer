namespace PackageExplorer.AddIns.XmlEditor
{
    partial class XmlEditorOptionsPanel
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
            this._formatXmlField = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _formatXmlField
            // 
            this._formatXmlField.AutoSize = true;
            this._formatXmlField.Location = new System.Drawing.Point(4, 4);
            this._formatXmlField.Name = "_formatXmlField";
            this._formatXmlField.Size = new System.Drawing.Size(210, 17);
            this._formatXmlField.TabIndex = 0;
            this._formatXmlField.Text = "Format XML on opening of a document";
            this._formatXmlField.UseVisualStyleBackColor = true;
            this._formatXmlField.CheckedChanged += new System.EventHandler(this._formatXmlField_CheckedChanged);
            // 
            // XmlEditorOptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._formatXmlField);
            this.Name = "XmlEditorOptionsPanel";
            this.Size = new System.Drawing.Size(375, 318);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _formatXmlField;
    }
}
