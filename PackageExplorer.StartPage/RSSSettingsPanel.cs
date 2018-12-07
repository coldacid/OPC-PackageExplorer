using System;
using System.Windows.Forms;
using PackageExplorer.UI.Dialogs;
using PackageExplorer.Services;
using PackageExplorer.Core.Services;
using System.Collections.Generic;

namespace PackageExplorer.StartPage
{
    class RSSSettingsPanel
        : PropertyPanel
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Label _rssFeedsLabel;
        private ListBox _feedList;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button _removeFeedsButton;
        private Button _addFeedButton;
        private CheckBox _queryRSSAtStartupField;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label _nrOfMessagesLabel;
        private NumericUpDown _nrOfMessagesField;
        RSSSettings _rssSettings = null;

        public RSSSettingsPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            ISettingsService service = ServiceManager.GetService<ISettingsService>();
            _rssSettings = service.GetSettings<RSSSettings>();
            foreach (string feed in _rssSettings.RSSFeeds)
            {
                _feedList.Items.Add(feed);
            }
            _queryRSSAtStartupField.Checked = _rssSettings.QueryRSSAtStartup;
            _nrOfMessagesField.Value = _rssSettings.MaxNrMessagesPerFeed;
            base.OnLoad(e);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._rssFeedsLabel = new System.Windows.Forms.Label();
            this._feedList = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._removeFeedsButton = new System.Windows.Forms.Button();
            this._addFeedButton = new System.Windows.Forms.Button();
            this._queryRSSAtStartupField = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this._nrOfMessagesLabel = new System.Windows.Forms.Label();
            this._nrOfMessagesField = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nrOfMessagesField)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._rssFeedsLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._feedList, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this._queryRSSAtStartupField, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 276);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _rssFeedsLabel
            // 
            this._rssFeedsLabel.AutoSize = true;
            this._rssFeedsLabel.Location = new System.Drawing.Point(0, 52);
            this._rssFeedsLabel.Margin = new System.Windows.Forms.Padding(0, 9, 0, 3);
            this._rssFeedsLabel.Name = "_rssFeedsLabel";
            this._rssFeedsLabel.Size = new System.Drawing.Size(272, 13);
            this._rssFeedsLabel.TabIndex = 0;
            this._rssFeedsLabel.Text = "The following RSS feeds are displayed on the startpage.";
            // 
            // _feedList
            // 
            this._feedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._feedList.FormattingEnabled = true;
            this._feedList.Location = new System.Drawing.Point(0, 68);
            this._feedList.Margin = new System.Windows.Forms.Padding(0);
            this._feedList.Name = "_feedList";
            this._feedList.Size = new System.Drawing.Size(389, 173);
            this._feedList.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this._removeFeedsButton);
            this.flowLayoutPanel1.Controls.Add(this._addFeedButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 244);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(383, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // _removeFeedsButton
            // 
            this._removeFeedsButton.Location = new System.Drawing.Point(305, 3);
            this._removeFeedsButton.Name = "_removeFeedsButton";
            this._removeFeedsButton.Size = new System.Drawing.Size(75, 23);
            this._removeFeedsButton.TabIndex = 0;
            this._removeFeedsButton.Text = "Remove selected";
            this._removeFeedsButton.UseVisualStyleBackColor = true;
            this._removeFeedsButton.Click += new System.EventHandler(this.RemoveFeedsButton_Click);
            // 
            // _addFeedButton
            // 
            this._addFeedButton.Location = new System.Drawing.Point(224, 3);
            this._addFeedButton.Name = "_addFeedButton";
            this._addFeedButton.Size = new System.Drawing.Size(75, 23);
            this._addFeedButton.TabIndex = 1;
            this._addFeedButton.Text = "Add feed...";
            this._addFeedButton.UseVisualStyleBackColor = true;
            this._addFeedButton.Click += new System.EventHandler(this.AddFeedButton_Click);
            // 
            // _queryRSSAtStartupField
            // 
            this._queryRSSAtStartupField.AutoSize = true;
            this._queryRSSAtStartupField.Location = new System.Drawing.Point(0, 3);
            this._queryRSSAtStartupField.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._queryRSSAtStartupField.Name = "_queryRSSAtStartupField";
            this._queryRSSAtStartupField.Size = new System.Drawing.Size(197, 17);
            this._queryRSSAtStartupField.TabIndex = 3;
            this._queryRSSAtStartupField.Text = "Display RSS feeds on the start page";
            this._queryRSSAtStartupField.UseVisualStyleBackColor = true;
            this._queryRSSAtStartupField.CheckedChanged += new System.EventHandler(this.QueryRSSAtStartupField_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this._nrOfMessagesLabel);
            this.flowLayoutPanel2.Controls.Add(this._nrOfMessagesField);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 23);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(389, 20);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // _nrOfMessagesLabel
            // 
            this._nrOfMessagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._nrOfMessagesLabel.AutoSize = true;
            this._nrOfMessagesLabel.Location = new System.Drawing.Point(0, 0);
            this._nrOfMessagesLabel.Margin = new System.Windows.Forms.Padding(0);
            this._nrOfMessagesLabel.Name = "_nrOfMessagesLabel";
            this._nrOfMessagesLabel.Size = new System.Drawing.Size(246, 20);
            this._nrOfMessagesLabel.TabIndex = 1;
            this._nrOfMessagesLabel.Text = "Maximum number of messages to display per feed: ";
            this._nrOfMessagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _nrOfMessagesField
            // 
            this._nrOfMessagesField.Location = new System.Drawing.Point(246, 0);
            this._nrOfMessagesField.Margin = new System.Windows.Forms.Padding(0);
            this._nrOfMessagesField.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._nrOfMessagesField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nrOfMessagesField.Name = "_nrOfMessagesField";
            this._nrOfMessagesField.Size = new System.Drawing.Size(36, 20);
            this._nrOfMessagesField.TabIndex = 0;
            this._nrOfMessagesField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nrOfMessagesField.ValueChanged += new System.EventHandler(this.NrOfMessagesField_ValueChanged);
            // 
            // RSSSettingsPanel
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RSSSettingsPanel";
            this.Size = new System.Drawing.Size(389, 276);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nrOfMessagesField)).EndInit();
            this.ResumeLayout(false);

        }

        public override bool ApplyChanges()
        {
            _rssSettings.RSSFeeds.Clear();
            foreach (string feed in _feedList.Items)
            {
                _rssSettings.RSSFeeds.Add(feed);
            }
            _rssSettings.QueryRSSAtStartup = _queryRSSAtStartupField.Checked;
            _rssSettings.MaxNrMessagesPerFeed = Convert.ToInt32(_nrOfMessagesField.Value);
            return true;
        }

        private void AddFeedButton_Click(object sender, EventArgs e)
        {
            using (AddFeedDialog dialog = new AddFeedDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _feedList.Items.Add(dialog.Url);
                }
            }
            IsDirty = true;
        }

        private void RemoveFeedsButton_Click(object sender, EventArgs e)
        {
            List<int> items = new List<int>();
            foreach (int index in _feedList.SelectedIndices)
            {
                items.Add(index);
            }
            items.Sort(
                delegate(int a, int b)
                {
                    return a - b;
                });
            foreach (int index in items)
            {
                _feedList.Items.RemoveAt(index);
            }
            IsDirty = true;
        }

        private void QueryRSSAtStartupField_CheckedChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        private void NrOfMessagesField_ValueChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}
