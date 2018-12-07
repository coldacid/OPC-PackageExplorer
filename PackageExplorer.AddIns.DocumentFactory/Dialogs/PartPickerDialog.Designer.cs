namespace PackageExplorer.AddIns.DocumentFactory.Dialogs
{
    partial class PartPickerDialog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label _vocabulariesLabel;
            System.Windows.Forms.Label _partTypesLabel;
            System.Windows.Forms.Label _locationLabel;
            this._layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._partTypesField = new System.Windows.Forms.ListView();
            this._largeImages = new System.Windows.Forms.ImageList(this.components);
            this._vocabularyImages = new System.Windows.Forms.ImageList(this.components);
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._vocabulariesField = new System.Windows.Forms.TreeView();
            this._bottomRowLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._locationField = new System.Windows.Forms.TextBox();
            this._relationshipIDPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._autoGenerateIDField = new System.Windows.Forms.CheckBox();
            this._customRelationshipIDPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._relationshipIDLabel = new System.Windows.Forms.Label();
            this._relationshipIDField = new System.Windows.Forms.TextBox();
            _vocabulariesLabel = new System.Windows.Forms.Label();
            _partTypesLabel = new System.Windows.Forms.Label();
            _locationLabel = new System.Windows.Forms.Label();
            this._layoutPanel.SuspendLayout();
            this._bottomRowLayoutPanel.SuspendLayout();
            this._relationshipIDPanel.SuspendLayout();
            this._customRelationshipIDPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _vocabulariesLabel
            // 
            _vocabulariesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            _vocabulariesLabel.AutoSize = true;
            _vocabulariesLabel.Location = new System.Drawing.Point(3, 9);
            _vocabulariesLabel.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            _vocabulariesLabel.Name = "_vocabulariesLabel";
            _vocabulariesLabel.Size = new System.Drawing.Size(68, 13);
            _vocabulariesLabel.TabIndex = 0;
            _vocabulariesLabel.Text = "Vocabularies";
            // 
            // _partTypesLabel
            // 
            _partTypesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            _partTypesLabel.AutoSize = true;
            _partTypesLabel.Location = new System.Drawing.Point(149, 9);
            _partTypesLabel.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            _partTypesLabel.Name = "_partTypesLabel";
            _partTypesLabel.Size = new System.Drawing.Size(58, 13);
            _partTypesLabel.TabIndex = 1;
            _partTypesLabel.Text = "Part Types";
            // 
            // _locationLabel
            // 
            _locationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            _locationLabel.AutoSize = true;
            _locationLabel.Location = new System.Drawing.Point(3, 0);
            _locationLabel.Name = "_locationLabel";
            _locationLabel.Size = new System.Drawing.Size(48, 26);
            _locationLabel.TabIndex = 0;
            _locationLabel.Text = "Location";
            _locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _layoutPanel
            // 
            this._layoutPanel.ColumnCount = 3;
            this._layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._layoutPanel.Controls.Add(_vocabulariesLabel, 0, 0);
            this._layoutPanel.Controls.Add(_partTypesLabel, 1, 0);
            this._layoutPanel.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this._layoutPanel.Controls.Add(this._partTypesField, 1, 1);
            this._layoutPanel.Controls.Add(this._descriptionLabel, 0, 2);
            this._layoutPanel.Controls.Add(this._vocabulariesField, 0, 1);
            this._layoutPanel.Controls.Add(this._bottomRowLayoutPanel, 0, 3);
            this._layoutPanel.Controls.Add(this._relationshipIDPanel, 0, 4);
            this._layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._layoutPanel.Location = new System.Drawing.Point(0, 0);
            this._layoutPanel.Name = "_layoutPanel";
            this._layoutPanel.RowCount = 5;
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._layoutPanel.Size = new System.Drawing.Size(574, 366);
            this._layoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(571, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // _partTypesField
            // 
            this._layoutPanel.SetColumnSpan(this._partTypesField, 2);
            this._partTypesField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._partTypesField.GridLines = true;
            this._partTypesField.HideSelection = false;
            this._partTypesField.LargeImageList = this._largeImages;
            this._partTypesField.Location = new System.Drawing.Point(149, 28);
            this._partTypesField.MultiSelect = false;
            this._partTypesField.Name = "_partTypesField";
            this._partTypesField.Size = new System.Drawing.Size(422, 261);
            this._partTypesField.SmallImageList = this._vocabularyImages;
            this._partTypesField.TabIndex = 1;
            this._partTypesField.UseCompatibleStateImageBehavior = false;
            this._partTypesField.Validating += new System.ComponentModel.CancelEventHandler(this.PartTypesField_Validating);
            this._partTypesField.SelectedIndexChanged += new System.EventHandler(this.PartTypesField_SelectedIndexChanged);
            // 
            // _largeImages
            // 
            this._largeImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._largeImages.ImageSize = new System.Drawing.Size(32, 32);
            this._largeImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _vocabularyImages
            // 
            this._vocabularyImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._vocabularyImages.ImageSize = new System.Drawing.Size(16, 16);
            this._vocabularyImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._layoutPanel.SetColumnSpan(this._descriptionLabel, 3);
            this._descriptionLabel.Location = new System.Drawing.Point(3, 292);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this._descriptionLabel.Size = new System.Drawing.Size(568, 19);
            this._descriptionLabel.TabIndex = 7;
            this._descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _vocabulariesField
            // 
            this._vocabulariesField.Dock = System.Windows.Forms.DockStyle.Fill;
            this._vocabulariesField.HideSelection = false;
            this._vocabulariesField.ImageIndex = 0;
            this._vocabulariesField.ImageList = this._vocabularyImages;
            this._vocabulariesField.Location = new System.Drawing.Point(3, 28);
            this._vocabulariesField.Name = "_vocabulariesField";
            this._vocabulariesField.SelectedImageIndex = 0;
            this._vocabulariesField.ShowRootLines = false;
            this._vocabulariesField.Size = new System.Drawing.Size(140, 261);
            this._vocabulariesField.TabIndex = 0;
            // 
            // _bottomRowLayoutPanel
            // 
            this._bottomRowLayoutPanel.AutoSize = true;
            this._bottomRowLayoutPanel.ColumnCount = 2;
            this._layoutPanel.SetColumnSpan(this._bottomRowLayoutPanel, 3);
            this._bottomRowLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._bottomRowLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._bottomRowLayoutPanel.Controls.Add(_locationLabel, 0, 0);
            this._bottomRowLayoutPanel.Controls.Add(this._locationField, 1, 0);
            this._bottomRowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bottomRowLayoutPanel.Location = new System.Drawing.Point(0, 311);
            this._bottomRowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this._bottomRowLayoutPanel.Name = "_bottomRowLayoutPanel";
            this._bottomRowLayoutPanel.RowCount = 1;
            this._bottomRowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._bottomRowLayoutPanel.Size = new System.Drawing.Size(574, 26);
            this._bottomRowLayoutPanel.TabIndex = 8;
            // 
            // _locationField
            // 
            this._locationField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._locationField.Location = new System.Drawing.Point(57, 3);
            this._locationField.Name = "_locationField";
            this._locationField.Size = new System.Drawing.Size(514, 20);
            this._locationField.TabIndex = 0;
            this._locationField.TextChanged += new System.EventHandler(this.LocationField_TextChanged);
            this._locationField.Validating += new System.ComponentModel.CancelEventHandler(this.LocationField_Validating);
            // 
            // _relationshipIDPanel
            // 
            this._relationshipIDPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._relationshipIDPanel.AutoSize = true;
            this._relationshipIDPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._layoutPanel.SetColumnSpan(this._relationshipIDPanel, 2);
            this._relationshipIDPanel.Controls.Add(this._autoGenerateIDField);
            this._relationshipIDPanel.Controls.Add(this._customRelationshipIDPanel);
            this._relationshipIDPanel.Location = new System.Drawing.Point(3, 340);
            this._relationshipIDPanel.Name = "_relationshipIDPanel";
            this._relationshipIDPanel.Size = new System.Drawing.Size(562, 23);
            this._relationshipIDPanel.TabIndex = 10;
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
            // PartPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._layoutPanel);
            this.Name = "PartPickerDialog";
            this.Size = new System.Drawing.Size(574, 366);
            this._layoutPanel.ResumeLayout(false);
            this._layoutPanel.PerformLayout();
            this._bottomRowLayoutPanel.ResumeLayout(false);
            this._bottomRowLayoutPanel.PerformLayout();
            this._relationshipIDPanel.ResumeLayout(false);
            this._relationshipIDPanel.PerformLayout();
            this._customRelationshipIDPanel.ResumeLayout(false);
            this._customRelationshipIDPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _layoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListView _partTypesField;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.TreeView _vocabulariesField;
        private System.Windows.Forms.TableLayoutPanel _bottomRowLayoutPanel;
        private System.Windows.Forms.TextBox _locationField;
        private System.Windows.Forms.CheckBox _autoGenerateIDField;
        private System.Windows.Forms.FlowLayoutPanel _relationshipIDPanel;
        private System.Windows.Forms.FlowLayoutPanel _customRelationshipIDPanel;
        private System.Windows.Forms.Label _relationshipIDLabel;
        private System.Windows.Forms.TextBox _relationshipIDField;
        private System.Windows.Forms.ImageList _vocabularyImages;
        private System.Windows.Forms.ImageList _largeImages;
    }
}
