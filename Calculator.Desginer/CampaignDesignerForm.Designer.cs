namespace Calculator.Desginer
{
    partial class CampaignDesignerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CampaignDesignerForm));
            FooterStatusStrip = new StatusStrip();
            MenuToolStrip = new ToolStrip();
            FileToolStripDropDownButton = new ToolStripDropDownButton();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            CampaignSplitContainer = new SplitContainer();
            DesignerSplitContainer = new SplitContainer();
            ObjectControl = new TabControl();
            ToolBoxTabPage = new TabPage();
            ObjectToolBox = new ListView();
            ItemPropertiesTabPage = new TabPage();
            ItemPropertiesGridView = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            DetailsSplitContainer = new SplitContainer();
            CampaignDetails = new ListView();
            SelectedObjectPropertyGrid = new PropertyGrid();
            MainSplitContainer = new SplitContainer();
            CampaignLabel = new Label();
            MenuToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CampaignSplitContainer).BeginInit();
            CampaignSplitContainer.Panel1.SuspendLayout();
            CampaignSplitContainer.Panel2.SuspendLayout();
            CampaignSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DesignerSplitContainer).BeginInit();
            DesignerSplitContainer.Panel1.SuspendLayout();
            DesignerSplitContainer.Panel2.SuspendLayout();
            DesignerSplitContainer.SuspendLayout();
            ObjectControl.SuspendLayout();
            ToolBoxTabPage.SuspendLayout();
            ItemPropertiesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemPropertiesGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DetailsSplitContainer).BeginInit();
            DetailsSplitContainer.Panel2.SuspendLayout();
            DetailsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // FooterStatusStrip
            // 
            FooterStatusStrip.Location = new Point(0, 934);
            FooterStatusStrip.Name = "FooterStatusStrip";
            FooterStatusStrip.Size = new Size(1582, 22);
            FooterStatusStrip.TabIndex = 1;
            FooterStatusStrip.Text = "statusStrip1";
            // 
            // MenuToolStrip
            // 
            MenuToolStrip.Items.AddRange(new ToolStripItem[] { FileToolStripDropDownButton, toolStripButton1, toolStripLabel1 });
            MenuToolStrip.Location = new Point(0, 0);
            MenuToolStrip.Name = "MenuToolStrip";
            MenuToolStrip.RenderMode = ToolStripRenderMode.Professional;
            MenuToolStrip.Size = new Size(1582, 25);
            MenuToolStrip.TabIndex = 2;
            MenuToolStrip.Text = "toolStrip1";
            // 
            // FileToolStripDropDownButton
            // 
            FileToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            FileToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            FileToolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            FileToolStripDropDownButton.Name = "FileToolStripDropDownButton";
            FileToolStripDropDownButton.Size = new Size(38, 22);
            FileToolStripDropDownButton.Text = "File";
            FileToolStripDropDownButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(124, 22);
            fileToolStripMenuItem.Text = "Open File";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(32, 22);
            toolStripLabel1.Text = "View";
            // 
            // CampaignSplitContainer
            // 
            CampaignSplitContainer.Dock = DockStyle.Fill;
            CampaignSplitContainer.Location = new Point(0, 0);
            CampaignSplitContainer.Name = "CampaignSplitContainer";
            // 
            // CampaignSplitContainer.Panel1
            // 
            CampaignSplitContainer.Panel1.Controls.Add(DesignerSplitContainer);
            // 
            // CampaignSplitContainer.Panel2
            // 
            CampaignSplitContainer.Panel2.Controls.Add(SelectedObjectPropertyGrid);
            CampaignSplitContainer.Size = new Size(1582, 849);
            CampaignSplitContainer.SplitterDistance = 1286;
            CampaignSplitContainer.TabIndex = 3;
            // 
            // DesignerSplitContainer
            // 
            DesignerSplitContainer.Dock = DockStyle.Fill;
            DesignerSplitContainer.Location = new Point(0, 0);
            DesignerSplitContainer.Name = "DesignerSplitContainer";
            // 
            // DesignerSplitContainer.Panel1
            // 
            DesignerSplitContainer.Panel1.Controls.Add(ObjectControl);
            // 
            // DesignerSplitContainer.Panel2
            // 
            DesignerSplitContainer.Panel2.Controls.Add(DetailsSplitContainer);
            DesignerSplitContainer.Size = new Size(1286, 849);
            DesignerSplitContainer.SplitterDistance = 329;
            DesignerSplitContainer.TabIndex = 0;
            // 
            // ObjectControl
            // 
            ObjectControl.Controls.Add(ToolBoxTabPage);
            ObjectControl.Controls.Add(ItemPropertiesTabPage);
            ObjectControl.Dock = DockStyle.Fill;
            ObjectControl.Location = new Point(0, 0);
            ObjectControl.Name = "ObjectControl";
            ObjectControl.SelectedIndex = 0;
            ObjectControl.Size = new Size(329, 849);
            ObjectControl.TabIndex = 1;
            // 
            // ToolBoxTabPage
            // 
            ToolBoxTabPage.Controls.Add(ObjectToolBox);
            ToolBoxTabPage.Location = new Point(4, 24);
            ToolBoxTabPage.Name = "ToolBoxTabPage";
            ToolBoxTabPage.Padding = new Padding(3);
            ToolBoxTabPage.Size = new Size(321, 821);
            ToolBoxTabPage.TabIndex = 0;
            ToolBoxTabPage.Text = "Toolbox";
            ToolBoxTabPage.UseVisualStyleBackColor = true;
            // 
            // ObjectToolBox
            // 
            ObjectToolBox.Dock = DockStyle.Fill;
            ObjectToolBox.Location = new Point(3, 3);
            ObjectToolBox.Name = "ObjectToolBox";
            ObjectToolBox.Size = new Size(315, 815);
            ObjectToolBox.TabIndex = 0;
            ObjectToolBox.UseCompatibleStateImageBehavior = false;
            ObjectToolBox.ItemDrag += ObjectToolBox_ItemDrag;
            // 
            // ItemPropertiesTabPage
            // 
            ItemPropertiesTabPage.Controls.Add(ItemPropertiesGridView);
            ItemPropertiesTabPage.Location = new Point(4, 24);
            ItemPropertiesTabPage.Name = "ItemPropertiesTabPage";
            ItemPropertiesTabPage.Padding = new Padding(3);
            ItemPropertiesTabPage.Size = new Size(321, 821);
            ItemPropertiesTabPage.TabIndex = 1;
            ItemPropertiesTabPage.Text = "Item Properties";
            ItemPropertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // ItemPropertiesGridView
            // 
            ItemPropertiesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemPropertiesGridView.Columns.AddRange(new DataGridViewColumn[] { Key, Value });
            ItemPropertiesGridView.Dock = DockStyle.Fill;
            ItemPropertiesGridView.Location = new Point(3, 3);
            ItemPropertiesGridView.Name = "ItemPropertiesGridView";
            ItemPropertiesGridView.RowTemplate.Height = 25;
            ItemPropertiesGridView.Size = new Size(315, 815);
            ItemPropertiesGridView.TabIndex = 0;
            // 
            // Key
            // 
            Key.HeaderText = "Column1";
            Key.Name = "Key";
            // 
            // Value
            // 
            Value.HeaderText = "Column1";
            Value.Name = "Value";
            // 
            // DetailsSplitContainer
            // 
            DetailsSplitContainer.Dock = DockStyle.Fill;
            DetailsSplitContainer.Location = new Point(0, 0);
            DetailsSplitContainer.Name = "DetailsSplitContainer";
            DetailsSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // DetailsSplitContainer.Panel2
            // 
            DetailsSplitContainer.Panel2.Controls.Add(CampaignDetails);
            DetailsSplitContainer.Size = new Size(953, 849);
            DetailsSplitContainer.SplitterDistance = 108;
            DetailsSplitContainer.TabIndex = 0;
            // 
            // CampaignDetails
            // 
            CampaignDetails.AllowDrop = true;
            CampaignDetails.Dock = DockStyle.Fill;
            CampaignDetails.Location = new Point(0, 0);
            CampaignDetails.Name = "CampaignDetails";
            CampaignDetails.Size = new Size(953, 737);
            CampaignDetails.TabIndex = 1;
            CampaignDetails.UseCompatibleStateImageBehavior = false;
            CampaignDetails.SelectedIndexChanged += CampaignDetails_SelectedIndexChanged;
            CampaignDetails.DragDrop += CampaignDetails_DragDrop;
            CampaignDetails.DragOver += CampaignDetails_DragOver;
            // 
            // SelectedObjectPropertyGrid
            // 
            SelectedObjectPropertyGrid.Dock = DockStyle.Fill;
            SelectedObjectPropertyGrid.Location = new Point(0, 0);
            SelectedObjectPropertyGrid.Name = "SelectedObjectPropertyGrid";
            SelectedObjectPropertyGrid.Size = new Size(292, 849);
            SelectedObjectPropertyGrid.TabIndex = 0;
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.Location = new Point(0, 25);
            MainSplitContainer.Name = "MainSplitContainer";
            MainSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(CampaignLabel);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.Controls.Add(CampaignSplitContainer);
            MainSplitContainer.Size = new Size(1582, 909);
            MainSplitContainer.SplitterDistance = 56;
            MainSplitContainer.TabIndex = 4;
            // 
            // CampaignLabel
            // 
            CampaignLabel.AutoSize = true;
            CampaignLabel.Location = new Point(27, 20);
            CampaignLabel.Name = "CampaignLabel";
            CampaignLabel.Size = new Size(112, 15);
            CampaignLabel.TabIndex = 0;
            CampaignLabel.Text = "( Load a campaign )";
            // 
            // CampaignDesignerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 956);
            Controls.Add(MainSplitContainer);
            Controls.Add(MenuToolStrip);
            Controls.Add(FooterStatusStrip);
            Name = "CampaignDesignerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Discoutn Calculator Designer";
            WindowState = FormWindowState.Maximized;
            Load += CampaignDesignerForm_Load;
            MenuToolStrip.ResumeLayout(false);
            MenuToolStrip.PerformLayout();
            CampaignSplitContainer.Panel1.ResumeLayout(false);
            CampaignSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CampaignSplitContainer).EndInit();
            CampaignSplitContainer.ResumeLayout(false);
            DesignerSplitContainer.Panel1.ResumeLayout(false);
            DesignerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DesignerSplitContainer).EndInit();
            DesignerSplitContainer.ResumeLayout(false);
            ObjectControl.ResumeLayout(false);
            ToolBoxTabPage.ResumeLayout(false);
            ItemPropertiesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ItemPropertiesGridView).EndInit();
            DetailsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DetailsSplitContainer).EndInit();
            DetailsSplitContainer.ResumeLayout(false);
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel1.PerformLayout();
            MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip FooterStatusStrip;
        private ToolStrip MenuToolStrip;
        private SplitContainer CampaignSplitContainer;
        private ToolStripDropDownButton FileToolStripDropDownButton;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripLabel toolStripLabel1;
        private SplitContainer DesignerSplitContainer;
        private PropertyGrid SelectedObjectPropertyGrid;
        private SplitContainer MainSplitContainer;
        private TabControl ObjectControl;
        private TabPage ToolBoxTabPage;
        private TabPage ItemPropertiesTabPage;
        private SplitContainer DetailsSplitContainer;
        private Label CampaignLabel;
        private DataGridView ItemPropertiesGridView;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn Value;
        private ListView ObjectToolBox;
        private ListView CampaignDetails;
    }
}
