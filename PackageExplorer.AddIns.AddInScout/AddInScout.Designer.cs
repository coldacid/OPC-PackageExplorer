namespace PackageExplorer.AddIns.AddInScout
{
	partial class AddInScout
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

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._verticalSplitter = new System.Windows.Forms.SplitContainer();
			this._addInViews = new System.Windows.Forms.TabControl();
			this._treeViewTab = new System.Windows.Forms.TabPage();
			this._listViewTab = new System.Windows.Forms.TabPage();
			this._horizontalSplitter = new System.Windows.Forms.SplitContainer();
			this._verticalSplitter.Panel1.SuspendLayout();
			this._verticalSplitter.Panel2.SuspendLayout();
			this._verticalSplitter.SuspendLayout();
			this._addInViews.SuspendLayout();
			this._horizontalSplitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// _verticalSplitter
			// 
			this._verticalSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this._verticalSplitter.Location = new System.Drawing.Point(0, 0);
			this._verticalSplitter.Name = "_verticalSplitter";
			// 
			// _verticalSplitter.Panel1
			// 
			this._verticalSplitter.Panel1.Controls.Add(this._addInViews);
			// 
			// _verticalSplitter.Panel2
			// 
			this._verticalSplitter.Panel2.Controls.Add(this._horizontalSplitter);
			this._verticalSplitter.Size = new System.Drawing.Size(597, 567);
			this._verticalSplitter.SplitterDistance = 199;
			this._verticalSplitter.TabIndex = 0;
			this._verticalSplitter.Text = "splitContainer1";
			// 
			// _addInViews
			// 
			this._addInViews.Controls.Add(this._treeViewTab);
			this._addInViews.Controls.Add(this._listViewTab);
			this._addInViews.Dock = System.Windows.Forms.DockStyle.Fill;
			this._addInViews.Location = new System.Drawing.Point(0, 0);
			this._addInViews.Name = "_addInViews";
			this._addInViews.SelectedIndex = 0;
			this._addInViews.Size = new System.Drawing.Size(199, 567);
			this._addInViews.TabIndex = 0;
			// 
			// _treeViewTab
			// 
			this._treeViewTab.Location = new System.Drawing.Point(4, 22);
			this._treeViewTab.Name = "_treeViewTab";
			this._treeViewTab.Padding = new System.Windows.Forms.Padding(3);
			this._treeViewTab.Size = new System.Drawing.Size(191, 541);
			this._treeViewTab.TabIndex = 0;
			this._treeViewTab.Text = "Tree";
			// 
			// _listViewTab
			// 
			this._listViewTab.Location = new System.Drawing.Point(4, 22);
			this._listViewTab.Name = "_listViewTab";
			this._listViewTab.Padding = new System.Windows.Forms.Padding(3);
			this._listViewTab.Size = new System.Drawing.Size(191, 541);
			this._listViewTab.TabIndex = 1;
			this._listViewTab.Text = "AddIns";
			// 
			// _horizontalSplitter
			// 
			this._horizontalSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this._horizontalSplitter.Location = new System.Drawing.Point(0, 0);
			this._horizontalSplitter.Name = "_horizontalSplitter";
			this._horizontalSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this._horizontalSplitter.Size = new System.Drawing.Size(394, 567);
			this._horizontalSplitter.SplitterDistance = 227;
			this._horizontalSplitter.TabIndex = 0;
			this._horizontalSplitter.Text = "splitContainer1";
			// 
			// AddInScout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._verticalSplitter);
			this.Name = "AddInScout";
			this.Size = new System.Drawing.Size(597, 567);
			this._verticalSplitter.Panel1.ResumeLayout(false);
			this._verticalSplitter.Panel2.ResumeLayout(false);
			this._verticalSplitter.ResumeLayout(false);
			this._addInViews.ResumeLayout(false);
			this._horizontalSplitter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private System.Windows.Forms.SplitContainer _verticalSplitter;
		private System.Windows.Forms.SplitContainer _horizontalSplitter;
		private System.Windows.Forms.TabControl _addInViews;
		private System.Windows.Forms.TabPage _treeViewTab;
		private System.Windows.Forms.TabPage _listViewTab;
	}
}
