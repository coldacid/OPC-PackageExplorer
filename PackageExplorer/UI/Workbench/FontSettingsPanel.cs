using System;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;
using System.Drawing;
using PackageExplorer.UI.Controls;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;

namespace PackageExplorer.UI.Workbench
{
    class FontSettingsPanel
        : PropertyPanel
    {
        private FontDialog fontDialog1;
        private PackageExplorer.UI.Controls.FontComboBox _fontField;
        private Label _fontNameLabel;
        private NumericUpDown _fontSizeField;
        private Label _fontSizeLabel;
        private TableLayoutPanel _mainLayoutPanel;
        FontSettings _fontSettings = null;

        public FontSettingsPanel()
        {
            InitializeComponent();
        }

        public override bool ApplyChanges()
        {
            if (_fontSettings.FontName != ((FontFamily)_fontField.SelectedItem).Name)
            {
                _fontSettings.FontName = ((FontFamily)_fontField.SelectedItem).Name;
            }
            if (_fontSettings.FontSize != _fontSizeField.Value)
            {
                _fontSettings.FontSize = Convert.ToInt32(_fontSizeField.Value);
            }
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            ISettingsService settingsService = ServiceManager.GetService<ISettingsService>();
            _fontSettings = settingsService.GetSettings<FontSettings>();
            FontFamily selectedFamily = null;
            foreach (FontFamily family in FontFamily.Families)
            {
                _fontField.Items.Add(family);
                if (family.Name == _fontSettings.FontName)
                {
                    selectedFamily = family;
                }
            }
            _fontField.Sorted = true;
            _fontField.SelectedItem = selectedFamily;
            _fontSizeField.Value = _fontSettings.FontSize;      
            base.OnLoad(e);
        }

        private void InitializeComponent()
        {
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this._fontField = new PackageExplorer.UI.Controls.FontComboBox();
            this._fontNameLabel = new System.Windows.Forms.Label();
            this._fontSizeField = new System.Windows.Forms.NumericUpDown();
            this._fontSizeLabel = new System.Windows.Forms.Label();
            this._mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._fontSizeField)).BeginInit();
            this._mainLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _fontField
            // 
            this._fontField.DisplayMember = "Name";
            this._fontField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._fontField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._fontField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fontField.FormattingEnabled = true;
            this._fontField.Location = new System.Drawing.Point(63, 3);
            this._fontField.Name = "_fontField";
            this._fontField.Size = new System.Drawing.Size(183, 27);
            this._fontField.TabIndex = 0;
            this._fontField.SelectedIndexChanged += new System.EventHandler(this.FontField_SelectedIndexChanged);
            // 
            // _fontNameLabel
            // 
            this._fontNameLabel.AutoSize = true;
            this._fontNameLabel.Location = new System.Drawing.Point(3, 0);
            this._fontNameLabel.Name = "_fontNameLabel";
            this._fontNameLabel.Size = new System.Drawing.Size(31, 13);
            this._fontNameLabel.TabIndex = 1;
            this._fontNameLabel.Text = "Font:";
            // 
            // _fontSizeField
            // 
            this._fontSizeField.Location = new System.Drawing.Point(63, 36);
            this._fontSizeField.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this._fontSizeField.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this._fontSizeField.Name = "_fontSizeField";
            this._fontSizeField.Size = new System.Drawing.Size(48, 20);
            this._fontSizeField.TabIndex = 2;
            this._fontSizeField.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this._fontSizeField.ValueChanged += new System.EventHandler(this.FontSizeField_ValueChanged);
            // 
            // _fontSizeLabel
            // 
            this._fontSizeLabel.AutoSize = true;
            this._fontSizeLabel.Location = new System.Drawing.Point(3, 33);
            this._fontSizeLabel.Name = "_fontSizeLabel";
            this._fontSizeLabel.Size = new System.Drawing.Size(54, 13);
            this._fontSizeLabel.TabIndex = 3;
            this._fontSizeLabel.Text = "Font Size:";
            // 
            // _mainLayoutPanel
            // 
            this._mainLayoutPanel.ColumnCount = 2;
            this._mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainLayoutPanel.Controls.Add(this._fontField, 1, 0);
            this._mainLayoutPanel.Controls.Add(this._fontNameLabel, 0, 0);
            this._mainLayoutPanel.Controls.Add(this._fontSizeLabel, 0, 1);
            this._mainLayoutPanel.Controls.Add(this._fontSizeField, 1, 1);
            this._mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._mainLayoutPanel.Name = "_mainLayoutPanel";
            this._mainLayoutPanel.RowCount = 2;
            this._mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainLayoutPanel.Size = new System.Drawing.Size(384, 285);
            this._mainLayoutPanel.TabIndex = 5;
            // 
            // FontSettingsPanel
            // 
            this.Controls.Add(this._mainLayoutPanel);
            this.Name = "FontSettingsPanel";
            this.Size = new System.Drawing.Size(384, 285);
            ((System.ComponentModel.ISupportInitialize)(this._fontSizeField)).EndInit();
            this._mainLayoutPanel.ResumeLayout(false);
            this._mainLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void FontField_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        private void FontSizeField_ValueChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}
