namespace PackageExplorer.UI.Workbench
{
    partial class BrowserContentControl
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
            this._urlLabel = new System.Windows.Forms.Label();
            this._urlField = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._webBrowser = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _urlLabel
            // 
            this._urlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._urlLabel.AutoSize = true;
            this._urlLabel.Location = new System.Drawing.Point(3, 0);
            this._urlLabel.Name = "_urlLabel";
            this._urlLabel.Size = new System.Drawing.Size(32, 27);
            this._urlLabel.TabIndex = 0;
            this._urlLabel.Text = "URL:";
            this._urlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _urlField
            // 
            this._urlField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._urlField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._urlField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this._urlField.FormattingEnabled = true;
            this._urlField.Location = new System.Drawing.Point(41, 3);
            this._urlField.Name = "_urlField";
            this._urlField.Size = new System.Drawing.Size(511, 21);
            this._urlField.TabIndex = 1;
            this._urlField.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this._urlField_PreviewKeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._urlField, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._urlLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._webBrowser, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 432);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _webBrowser
            // 
            this._webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._webBrowser, 2);
            this._webBrowser.Location = new System.Drawing.Point(3, 30);
            this._webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowser.Name = "_webBrowser";
            this._webBrowser.Size = new System.Drawing.Size(549, 399);
            this._webBrowser.TabIndex = 2;
            this._webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this._webBrowser_Navigated);
            // 
            // BrowserContentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BrowserContentControl";
            this.Size = new System.Drawing.Size(555, 432);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _urlLabel;
        private System.Windows.Forms.ComboBox _urlField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.WebBrowser _webBrowser;
    }
}
