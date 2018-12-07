namespace PackageExplorer.AddIns.AddInScout
{
	partial class ExtensionDetailsPanel
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
            this._extensionDetailsView = new System.Windows.Forms.ListView();
            this._extensionField = new System.Windows.Forms.Label();
            this._extensionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _extensionDetailsView
            // 
            this._extensionDetailsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._extensionDetailsView.FullRowSelect = true;
            this._extensionDetailsView.Location = new System.Drawing.Point(3, 38);
            this._extensionDetailsView.Name = "_extensionDetailsView";
            this._extensionDetailsView.Size = new System.Drawing.Size(641, 410);
            this._extensionDetailsView.TabIndex = 1;
            this._extensionDetailsView.UseCompatibleStateImageBehavior = false;
            this._extensionDetailsView.View = System.Windows.Forms.View.Details;
            // 
            // _extensionField
            // 
            this._extensionField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._extensionField.AutoSize = true;
            this._extensionField.Location = new System.Drawing.Point(65, 0);
            this._extensionField.Name = "_extensionField";
            this._extensionField.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this._extensionField.Size = new System.Drawing.Size(0, 29);
            this._extensionField.TabIndex = 1;
            this._extensionField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _extensionLabel
            // 
            this._extensionLabel.AutoSize = true;
            this._extensionLabel.Location = new System.Drawing.Point(3, 0);
            this._extensionLabel.Name = "_extensionLabel";
            this._extensionLabel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this._extensionLabel.Size = new System.Drawing.Size(56, 29);
            this._extensionLabel.TabIndex = 0;
            this._extensionLabel.Text = "Extension:";
            this._extensionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._extensionDetailsView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(647, 451);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this._extensionLabel);
            this.flowLayoutPanel1.Controls.Add(this._extensionField);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(641, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // ExtensionDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExtensionDetailsPanel";
            this.Size = new System.Drawing.Size(647, 451);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ListView _extensionDetailsView;
		private System.Windows.Forms.Label _extensionField;
		private System.Windows.Forms.Label _extensionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
