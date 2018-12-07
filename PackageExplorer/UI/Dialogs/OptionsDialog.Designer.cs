namespace PackageExplorer.UI.Dialogs
{
    partial class OptionsDialog
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
            this._mainContainer = new System.Windows.Forms.SplitContainer();
            this._optionGroupsTreeView = new System.Windows.Forms.TreeView();
            this._mainContainer.Panel1.SuspendLayout();
            this._mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainContainer
            // 
            this._mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainContainer.Location = new System.Drawing.Point(0, 0);
            this._mainContainer.Name = "_mainContainer";
            // 
            // _mainContainer.Panel1
            // 
            this._mainContainer.Panel1.Controls.Add(this._optionGroupsTreeView);
            this._mainContainer.Size = new System.Drawing.Size(581, 285);
            this._mainContainer.SplitterDistance = 193;
            this._mainContainer.TabIndex = 0;
            // 
            // _optionGroupsTreeView
            // 
            this._optionGroupsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._optionGroupsTreeView.Location = new System.Drawing.Point(0, 0);
            this._optionGroupsTreeView.Name = "_optionGroupsTreeView";
            this._optionGroupsTreeView.Size = new System.Drawing.Size(193, 285);
            this._optionGroupsTreeView.TabIndex = 0;
            this._optionGroupsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OptionGroupsTreeView_AfterSelect);
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainContainer);
            this.Name = "OptionsDialog";
            this.Size = new System.Drawing.Size(581, 285);
            this._mainContainer.Panel1.ResumeLayout(false);
            this._mainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _mainContainer;
        private System.Windows.Forms.TreeView _optionGroupsTreeView;
    }
}
