using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PackageExplorer.UI.Dialogs
{
    public partial class BrowseWithDialog
        : PackageExplorer.UI.Dialogs.DialogContent
    {

        void InitializeComponent()
        {
            System.Windows.Forms.Label _selectEditorLabel;
            System.Windows.Forms.TableLayoutPanel _layoutPanel;
            this._editorsField = new System.Windows.Forms.ListBox();
            this._setDefaultButton = new System.Windows.Forms.Button();
            _selectEditorLabel = new System.Windows.Forms.Label();
            _layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            _layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _selectEditorLabel
            // 
            _selectEditorLabel.AutoSize = true;
            _layoutPanel.SetColumnSpan(_selectEditorLabel, 2);
            _selectEditorLabel.Location = new System.Drawing.Point(3, 0);
            _selectEditorLabel.Name = "_selectEditorLabel";
            _selectEditorLabel.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            _selectEditorLabel.Size = new System.Drawing.Size(218, 17);
            _selectEditorLabel.TabIndex = 0;
            _selectEditorLabel.Text = "Select the editor to open the document with:";
            // 
            // _layoutPanel
            // 
            _layoutPanel.ColumnCount = 2;
            _layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            _layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            _layoutPanel.Controls.Add(this._editorsField, 0, 1);
            _layoutPanel.Controls.Add(this._setDefaultButton, 1, 1);
            _layoutPanel.Controls.Add(_selectEditorLabel, 0, 0);
            _layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _layoutPanel.Location = new System.Drawing.Point(0, 0);
            _layoutPanel.Name = "_layoutPanel";
            _layoutPanel.RowCount = 2;
            _layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            _layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            _layoutPanel.Size = new System.Drawing.Size(386, 174);
            _layoutPanel.TabIndex = 3;
            // 
            // _editorsField
            // 
            this._editorsField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._editorsField.FormattingEnabled = true;
            this._editorsField.Location = new System.Drawing.Point(3, 20);
            this._editorsField.Name = "_editorsField";
            this._editorsField.Size = new System.Drawing.Size(292, 147);
            this._editorsField.TabIndex = 1;
            this._editorsField.Validating += new System.ComponentModel.CancelEventHandler(this.EditorsField_Validating);
            // 
            // _setDefaultButton
            // 
            this._setDefaultButton.AutoSize = true;
            this._setDefaultButton.Enabled = false;
            this._setDefaultButton.Location = new System.Drawing.Point(301, 20);
            this._setDefaultButton.Name = "_setDefaultButton";
            this._setDefaultButton.Size = new System.Drawing.Size(82, 23);
            this._setDefaultButton.TabIndex = 2;
            this._setDefaultButton.Text = "Set as default";
            this._setDefaultButton.UseVisualStyleBackColor = true;
            this._setDefaultButton.Click += new System.EventHandler(this.SetDefaultButton_Click);
            // 
            // BrowseWithDialog
            // 
            this.Controls.Add(_layoutPanel);
            this.Name = "BrowseWithDialog";
            this.Size = new System.Drawing.Size(386, 174);
            _layoutPanel.ResumeLayout(false);
            _layoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private Button _setDefaultButton;
    }
}
