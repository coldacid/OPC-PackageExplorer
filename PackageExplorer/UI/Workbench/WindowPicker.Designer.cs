namespace PackageExplorer.UI.Workbench
{
    partial class WindowPicker
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel _borderPanel;
            this.label2 = new System.Windows.Forms.Label();
            this._inspectorsField = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this._currentWindowLabel = new System.Windows.Forms.Label();
            this._windowsField = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            _borderPanel = new System.Windows.Forms.Panel();
            _borderPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _borderPanel
            // 
            _borderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _borderPanel.Controls.Add(this.tableLayoutPanel1);
            _borderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _borderPanel.Location = new System.Drawing.Point(0, 0);
            _borderPanel.Name = "_borderPanel";
            _borderPanel.Size = new System.Drawing.Size(383, 232);
            _borderPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 29);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label2.Size = new System.Drawing.Size(144, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Document Windows";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _inspectorsField
            // 
            this._inspectorsField.DisplayMember = "Text";
            this._inspectorsField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inspectorsField.FormattingEnabled = true;
            this._inspectorsField.Location = new System.Drawing.Point(3, 51);
            this._inspectorsField.Name = "_inspectorsField";
            this._inspectorsField.Size = new System.Drawing.Size(144, 173);
            this._inspectorsField.TabIndex = 0;
            this._inspectorsField.SelectedIndexChanged += new System.EventHandler(this.InspectorsField_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inspector Windows";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _currentWindowLabel
            // 
            this._currentWindowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._currentWindowLabel.AutoSize = true;
            this._currentWindowLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.SetColumnSpan(this._currentWindowLabel, 3);
            this._currentWindowLabel.Location = new System.Drawing.Point(0, 0);
            this._currentWindowLabel.Margin = new System.Windows.Forms.Padding(0);
            this._currentWindowLabel.Name = "_currentWindowLabel";
            this._currentWindowLabel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this._currentWindowLabel.Size = new System.Drawing.Size(381, 29);
            this._currentWindowLabel.TabIndex = 0;
            this._currentWindowLabel.Text = "<current window name>";
            this._currentWindowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _windowsField
            // 
            this._windowsField.DisplayMember = "Text";
            this._windowsField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._windowsField.FormattingEnabled = true;
            this._windowsField.Location = new System.Drawing.Point(153, 51);
            this._windowsField.Name = "_windowsField";
            this._windowsField.Size = new System.Drawing.Size(144, 173);
            this._windowsField.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._windowsField, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this._currentWindowLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._inspectorsField, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(381, 230);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // WindowPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 232);
            this.Controls.Add(_borderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowPicker";
            this.ShowInTaskbar = false;
            this.Text = "WindowPicker";
            this.TopMost = true;
            _borderPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox _windowsField;
        private System.Windows.Forms.Label _currentWindowLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox _inspectorsField;
        private System.Windows.Forms.Label label2;


    }
}