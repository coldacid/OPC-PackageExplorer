namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    partial class RelationshipPickerDialog
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
            System.Windows.Forms.ColumnHeader _locationColumn;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._relationshipIDPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._autoGenerateIDField = new System.Windows.Forms.CheckBox();
            this._customRelationshipIDPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._relationshipIDLabel = new System.Windows.Forms.Label();
            this._relationshipIDField = new System.Windows.Forms.TextBox();
            this._tabs = new System.Windows.Forms.TabControl();
            this._existingPartsTab = new System.Windows.Forms.TabPage();
            this._partsField = new System.Windows.Forms.ListView();
            this._vocabularyColumn = new System.Windows.Forms.ColumnHeader();
            this._partTypeColumn = new System.Windows.Forms.ColumnHeader();
            this._contentTypeColumn = new System.Windows.Forms.ColumnHeader();
            this._externalContentTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._locationLabel = new System.Windows.Forms.Label();
            this._locationField = new System.Windows.Forms.ComboBox();
            this._relationshipTypeLabel = new System.Windows.Forms.Label();
            this._relationshipTypeField = new System.Windows.Forms.ComboBox();
            _locationColumn = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel1.SuspendLayout();
            this._relationshipIDPanel.SuspendLayout();
            this._customRelationshipIDPanel.SuspendLayout();
            this._tabs.SuspendLayout();
            this._existingPartsTab.SuspendLayout();
            this._externalContentTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _locationColumn
            // 
            _locationColumn.Text = "Location";
            _locationColumn.Width = 155;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._relationshipIDPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._tabs, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 216);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // _relationshipIDPanel
            // 
            this._relationshipIDPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._relationshipIDPanel.AutoSize = true;
            this._relationshipIDPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._relationshipIDPanel.Controls.Add(this._autoGenerateIDField);
            this._relationshipIDPanel.Controls.Add(this._customRelationshipIDPanel);
            this._relationshipIDPanel.Location = new System.Drawing.Point(3, 190);
            this._relationshipIDPanel.Name = "_relationshipIDPanel";
            this._relationshipIDPanel.Size = new System.Drawing.Size(506, 23);
            this._relationshipIDPanel.TabIndex = 11;
            // 
            // _autoGenerateIDField
            // 
            this._autoGenerateIDField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._autoGenerateIDField.AutoSize = true;
            this._autoGenerateIDField.Checked = true;
            this._autoGenerateIDField.CheckState = System.Windows.Forms.CheckState.Checked;
            this._autoGenerateIDField.Location = new System.Drawing.Point(3, 3);
            this._autoGenerateIDField.Name = "_autoGenerateIDField";
            this._autoGenerateIDField.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._autoGenerateIDField.Size = new System.Drawing.Size(166, 17);
            this._autoGenerateIDField.TabIndex = 9;
            this._autoGenerateIDField.Text = "Auto-generate relationship ID";
            this._autoGenerateIDField.UseVisualStyleBackColor = true;
            this._autoGenerateIDField.CheckedChanged += new System.EventHandler(this.AutoGenerateIDField_CheckedChanged);
            // 
            // _customRelationshipIDPanel
            // 
            this._customRelationshipIDPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._customRelationshipIDPanel.AutoSize = true;
            this._customRelationshipIDPanel.Controls.Add(this._relationshipIDLabel);
            this._customRelationshipIDPanel.Controls.Add(this._relationshipIDField);
            this._customRelationshipIDPanel.Location = new System.Drawing.Point(172, 0);
            this._customRelationshipIDPanel.Margin = new System.Windows.Forms.Padding(0);
            this._customRelationshipIDPanel.Name = "_customRelationshipIDPanel";
            this._customRelationshipIDPanel.Size = new System.Drawing.Size(288, 20);
            this._customRelationshipIDPanel.TabIndex = 10;
            this._customRelationshipIDPanel.Visible = false;
            this._customRelationshipIDPanel.WrapContents = false;
            // 
            // _relationshipIDLabel
            // 
            this._relationshipIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._relationshipIDLabel.AutoSize = true;
            this._relationshipIDLabel.Location = new System.Drawing.Point(3, 0);
            this._relationshipIDLabel.Name = "_relationshipIDLabel";
            this._relationshipIDLabel.Size = new System.Drawing.Size(82, 20);
            this._relationshipIDLabel.TabIndex = 0;
            this._relationshipIDLabel.Text = "Relationship ID:";
            this._relationshipIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _relationshipIDField
            // 
            this._relationshipIDField.Location = new System.Drawing.Point(88, 0);
            this._relationshipIDField.Margin = new System.Windows.Forms.Padding(0);
            this._relationshipIDField.Name = "_relationshipIDField";
            this._relationshipIDField.Size = new System.Drawing.Size(200, 20);
            this._relationshipIDField.TabIndex = 0;
            this._relationshipIDField.TextChanged += new System.EventHandler(this.RelationshipIDField_TextChanged);
            this._relationshipIDField.Validating += new System.ComponentModel.CancelEventHandler(this.RelationshipIDField_Validating);
            // 
            // _tabs
            // 
            this._tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tabs.Controls.Add(this._existingPartsTab);
            this._tabs.Controls.Add(this._externalContentTab);
            this._tabs.Location = new System.Drawing.Point(3, 3);
            this._tabs.Name = "_tabs";
            this._tabs.SelectedIndex = 0;
            this._tabs.Size = new System.Drawing.Size(506, 181);
            this._tabs.TabIndex = 1;
            this._tabs.Validating += new System.ComponentModel.CancelEventHandler(this.Tabs_Validating);
            this._tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // _existingPartsTab
            // 
            this._existingPartsTab.Controls.Add(this._partsField);
            this._existingPartsTab.Location = new System.Drawing.Point(4, 22);
            this._existingPartsTab.Name = "_existingPartsTab";
            this._existingPartsTab.Padding = new System.Windows.Forms.Padding(3);
            this._existingPartsTab.Size = new System.Drawing.Size(498, 155);
            this._existingPartsTab.TabIndex = 0;
            this._existingPartsTab.Text = "Existing parts";
            this._existingPartsTab.UseVisualStyleBackColor = true;
            // 
            // _partsField
            // 
            this._partsField.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            _locationColumn,
            this._vocabularyColumn,
            this._partTypeColumn,
            this._contentTypeColumn});
            this._partsField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._partsField.HideSelection = false;
            this._partsField.Location = new System.Drawing.Point(3, 3);
            this._partsField.MultiSelect = false;
            this._partsField.Name = "_partsField";
            this._partsField.Size = new System.Drawing.Size(492, 149);
            this._partsField.TabIndex = 0;
            this._partsField.UseCompatibleStateImageBehavior = false;
            this._partsField.View = System.Windows.Forms.View.Details;
            this._partsField.Validating += new System.ComponentModel.CancelEventHandler(this.PartsField_Validating);
            this._partsField.SelectedIndexChanged += new System.EventHandler(this.PartsField_SelectedIndexChanged);
            // 
            // _vocabularyColumn
            // 
            this._vocabularyColumn.Text = "Vocabulary";
            this._vocabularyColumn.Width = 94;
            // 
            // _partTypeColumn
            // 
            this._partTypeColumn.Text = "Part Type";
            this._partTypeColumn.Width = 75;
            // 
            // _contentTypeColumn
            // 
            this._contentTypeColumn.Text = "Content Type";
            this._contentTypeColumn.Width = 293;
            // 
            // _externalContentTab
            // 
            this._externalContentTab.Controls.Add(this.tableLayoutPanel2);
            this._externalContentTab.Location = new System.Drawing.Point(4, 22);
            this._externalContentTab.Name = "_externalContentTab";
            this._externalContentTab.Padding = new System.Windows.Forms.Padding(3);
            this._externalContentTab.Size = new System.Drawing.Size(498, 155);
            this._externalContentTab.TabIndex = 1;
            this._externalContentTab.Text = "External content";
            this._externalContentTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this._locationLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this._locationField, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this._relationshipTypeLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this._relationshipTypeField, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(492, 149);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // _locationLabel
            // 
            this._locationLabel.AutoSize = true;
            this._locationLabel.Location = new System.Drawing.Point(3, 0);
            this._locationLabel.Name = "_locationLabel";
            this._locationLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._locationLabel.Size = new System.Drawing.Size(75, 16);
            this._locationLabel.TabIndex = 0;
            this._locationLabel.Text = "Target loction:";
            // 
            // _locationField
            // 
            this._locationField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._locationField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._locationField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this._locationField.FormattingEnabled = true;
            this._locationField.Location = new System.Drawing.Point(3, 19);
            this._locationField.Name = "_locationField";
            this._locationField.Size = new System.Drawing.Size(486, 21);
            this._locationField.TabIndex = 1;
            this._locationField.Validating += new System.ComponentModel.CancelEventHandler(this.LocationField_Validating);
            // 
            // _relationshipTypeLabel
            // 
            this._relationshipTypeLabel.AutoSize = true;
            this._relationshipTypeLabel.Location = new System.Drawing.Point(3, 43);
            this._relationshipTypeLabel.Name = "_relationshipTypeLabel";
            this._relationshipTypeLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._relationshipTypeLabel.Size = new System.Drawing.Size(91, 16);
            this._relationshipTypeLabel.TabIndex = 2;
            this._relationshipTypeLabel.Text = "Relationship type:";
            // 
            // _relationshipTypeField
            // 
            this._relationshipTypeField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._relationshipTypeField.DisplayMember = "Name";
            this._relationshipTypeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._relationshipTypeField.FormattingEnabled = true;
            this._relationshipTypeField.Location = new System.Drawing.Point(3, 62);
            this._relationshipTypeField.Name = "_relationshipTypeField";
            this._relationshipTypeField.Size = new System.Drawing.Size(486, 21);
            this._relationshipTypeField.TabIndex = 3;
            this._relationshipTypeField.Validating += new System.ComponentModel.CancelEventHandler(this.RelationshipTypeField_Validating);
            // 
            // RelationshipPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RelationshipPickerDialog";
            this.Size = new System.Drawing.Size(512, 216);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._relationshipIDPanel.ResumeLayout(false);
            this._relationshipIDPanel.PerformLayout();
            this._customRelationshipIDPanel.ResumeLayout(false);
            this._customRelationshipIDPanel.PerformLayout();
            this._tabs.ResumeLayout(false);
            this._existingPartsTab.ResumeLayout(false);
            this._externalContentTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl _tabs;
        private System.Windows.Forms.TabPage _existingPartsTab;
        private System.Windows.Forms.TabPage _externalContentTab;
        private System.Windows.Forms.FlowLayoutPanel _relationshipIDPanel;
        private System.Windows.Forms.CheckBox _autoGenerateIDField;
        private System.Windows.Forms.FlowLayoutPanel _customRelationshipIDPanel;
        private System.Windows.Forms.Label _relationshipIDLabel;
        private System.Windows.Forms.TextBox _relationshipIDField;
        private System.Windows.Forms.ListView _partsField;
        private System.Windows.Forms.ColumnHeader _partTypeColumn;
        private System.Windows.Forms.ColumnHeader _contentTypeColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label _locationLabel;
        private System.Windows.Forms.ComboBox _locationField;
        private System.Windows.Forms.Label _relationshipTypeLabel;
        private System.Windows.Forms.ComboBox _relationshipTypeField;
        private System.Windows.Forms.ColumnHeader _vocabularyColumn;
    }
}
