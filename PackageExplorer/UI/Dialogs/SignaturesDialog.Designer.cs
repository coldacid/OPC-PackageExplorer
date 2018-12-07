namespace PackageExplorer.UI.Dialogs
{
    partial class SignaturesDialog
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
            this._signaturesList = new System.Windows.Forms.ListView();
            this._signatureTypeHeader = new System.Windows.Forms.ColumnHeader();
            this._signerNameHeadder = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // _signaturesList
            // 
            this._signaturesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._signatureTypeHeader,
            this._signerNameHeadder});
            this._signaturesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._signaturesList.Location = new System.Drawing.Point(0, 0);
            this._signaturesList.Name = "_signaturesList";
            this._signaturesList.Size = new System.Drawing.Size(450, 221);
            this._signaturesList.TabIndex = 0;
            this._signaturesList.UseCompatibleStateImageBehavior = false;
            this._signaturesList.View = System.Windows.Forms.View.Details;
            // 
            // _signatureTypeHeader
            // 
            this._signatureTypeHeader.Text = "Signature Type";
            this._signatureTypeHeader.Width = 251;
            // 
            // _signerNameHeadder
            // 
            this._signerNameHeadder.Text = "Signing party";
            this._signerNameHeadder.Width = 310;
            // 
            // SignaturesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._signaturesList);
            this.Name = "SignaturesDialog";
            this.Size = new System.Drawing.Size(450, 221);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _signaturesList;
        private System.Windows.Forms.ColumnHeader _signatureTypeHeader;
        private System.Windows.Forms.ColumnHeader _signerNameHeadder;
    }
}
