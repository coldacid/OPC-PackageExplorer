namespace PackageExplorer.AddIns.AddInScout
{
	partial class AddInDetailsPanel
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
            this._leftTextHeader = new System.Windows.Forms.Label();
            this._rightTextHeader = new System.Windows.Forms.Label();
            this._detailsList = new System.Windows.Forms.ListView();
            this._nameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this._valueColumnHeader = new System.Windows.Forms.ColumnHeader();
            this._propertyDescriptionField = new System.Windows.Forms.Label();
            this._propertyNameField = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _leftTextHeader
            // 
            this._leftTextHeader.AutoSize = true;
            this._leftTextHeader.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._leftTextHeader.Location = new System.Drawing.Point(0, 0);
            this._leftTextHeader.Margin = new System.Windows.Forms.Padding(0);
            this._leftTextHeader.Name = "_leftTextHeader";
            this._leftTextHeader.Size = new System.Drawing.Size(89, 26);
            this._leftTextHeader.TabIndex = 0;
            this._leftTextHeader.Text = "AddIn:";
            this._leftTextHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _rightTextHeader
            // 
            this._rightTextHeader.AutoSize = true;
            this._rightTextHeader.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rightTextHeader.Location = new System.Drawing.Point(92, 0);
            this._rightTextHeader.Name = "_rightTextHeader";
            this._rightTextHeader.Size = new System.Drawing.Size(0, 26);
            this._rightTextHeader.TabIndex = 1;
            this._rightTextHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _detailsList
            // 
            this._detailsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._detailsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._detailsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameColumnHeader,
            this._valueColumnHeader});
            this._detailsList.FullRowSelect = true;
            this._detailsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._detailsList.Location = new System.Drawing.Point(0, 34);
            this._detailsList.Margin = new System.Windows.Forms.Padding(0);
            this._detailsList.Name = "_detailsList";
            this._detailsList.ShowItemToolTips = true;
            this._detailsList.Size = new System.Drawing.Size(389, 220);
            this._detailsList.TabIndex = 2;
            this._detailsList.UseCompatibleStateImageBehavior = false;
            this._detailsList.View = System.Windows.Forms.View.Details;
            // 
            // _nameColumnHeader
            // 
            this._nameColumnHeader.Text = "Name";
            this._nameColumnHeader.Width = 120;
            // 
            // _valueColumnHeader
            // 
            this._valueColumnHeader.Text = "Value";
            this._valueColumnHeader.Width = 350;
            // 
            // _propertyDescriptionField
            // 
            this._propertyDescriptionField.AutoEllipsis = true;
            this._propertyDescriptionField.AutoSize = true;
            this._propertyDescriptionField.Location = new System.Drawing.Point(3, 13);
            this._propertyDescriptionField.Name = "_propertyDescriptionField";
            this._propertyDescriptionField.Size = new System.Drawing.Size(0, 13);
            this._propertyDescriptionField.TabIndex = 1;
            // 
            // _propertyNameField
            // 
            this._propertyNameField.AutoSize = true;
            this._propertyNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._propertyNameField.Location = new System.Drawing.Point(3, 0);
            this._propertyNameField.Name = "_propertyNameField";
            this._propertyNameField.Size = new System.Drawing.Size(0, 13);
            this._propertyNameField.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._detailsList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 288);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this._leftTextHeader);
            this.flowLayoutPanel1.Controls.Add(this._rightTextHeader);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(383, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this._propertyNameField);
            this.flowLayoutPanel2.Controls.Add(this._propertyDescriptionField);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 257);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(383, 28);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // AddInDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddInDetailsPanel";
            this.Size = new System.Drawing.Size(389, 288);
            this.Load += new System.EventHandler(this.AddInDetailsPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Label _leftTextHeader;
		private System.Windows.Forms.Label _rightTextHeader;
		private System.Windows.Forms.ListView _detailsList;
		private System.Windows.Forms.ColumnHeader _nameColumnHeader;
        private System.Windows.Forms.ColumnHeader _valueColumnHeader;
		private System.Windows.Forms.Label _propertyDescriptionField;
		private System.Windows.Forms.Label _propertyNameField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
	}
}
