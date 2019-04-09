namespace Krijn_Text_4
{
    partial class Editor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.textArea = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProjectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectTree = new System.Windows.Forms.TreeView();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openProjectFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.treeContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textArea
            // 
            this.textArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textArea.BackColor = System.Drawing.SystemColors.Window;
            this.textArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textArea.Location = new System.Drawing.Point(2, 2);
            this.textArea.Margin = new System.Windows.Forms.Padding(2);
            this.textArea.MaximumSize = new System.Drawing.Size(15360, 4320);
            this.textArea.MinimumSize = new System.Drawing.Size(153, 43);
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(662, 415);
            this.textArea.TabIndex = 0;
            this.textArea.Text = "";
            this.textArea.TextChanged += new System.EventHandler(this.textArea_TextChanged);
            this.textArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textArea_keyPressed);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(847, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectFolderToolStripMenuItem});
            this.projectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // addProjectFolderToolStripMenuItem
            // 
            this.addProjectFolderToolStripMenuItem.Name = "addProjectFolderToolStripMenuItem";
            this.addProjectFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.addProjectFolderToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.addProjectFolderToolStripMenuItem.Text = "Add Project Folder";
            this.addProjectFolderToolStripMenuItem.Click += new System.EventHandler(this.addProjectFolderToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languagesToolStripMenuItem.Text = "Languages";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.changeThemeToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click_1);
            // 
            // changeThemeToolStripMenuItem
            // 
            this.changeThemeToolStripMenuItem.Name = "changeThemeToolStripMenuItem";
            this.changeThemeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.changeThemeToolStripMenuItem.Text = "Change Theme";
            this.changeThemeToolStripMenuItem.Click += new System.EventHandler(this.changeThemeToolStripMenuItem_Click);
            // 
            // projectTree
            // 
            this.projectTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.projectTree.ContextMenuStrip = this.treeContextMenu;
            this.projectTree.Location = new System.Drawing.Point(12, 27);
            this.projectTree.Name = "projectTree";
            this.projectTree.Size = new System.Drawing.Size(149, 395);
            this.projectTree.TabIndex = 5;
            this.projectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.projectTree_AfterSelect);
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectFolderToolStripMenuItem1});
            this.treeContextMenu.Name = "contextMenuStrip1";
            this.treeContextMenu.Size = new System.Drawing.Size(255, 26);
            // 
            // openProjectFolderToolStripMenuItem1
            // 
            this.openProjectFolderToolStripMenuItem1.Name = "openProjectFolderToolStripMenuItem1";
            this.openProjectFolderToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openProjectFolderToolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            this.openProjectFolderToolStripMenuItem1.Text = "Open Project Folder";
            this.openProjectFolderToolStripMenuItem1.Click += new System.EventHandler(this.openProjectFolderToolStripMenuItem1_Click);
            // 
            // openProjectFolderToolStripMenuItem
            // 
            this.openProjectFolderToolStripMenuItem.Name = "openProjectFolderToolStripMenuItem";
            this.openProjectFolderToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.openProjectFolderToolStripMenuItem.Text = "Open Project Folder";
            this.openProjectFolderToolStripMenuItem.Click += new System.EventHandler(this.openProjectFolderToolStripMenuItem_Click);
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Location = new System.Drawing.Point(12, 428);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(149, 20);
            this.textBox4.TabIndex = 9;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textArea);
            this.panel1.Location = new System.Drawing.Point(167, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 421);
            this.panel1.TabIndex = 10;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(847, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.projectTree);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Editor";
            this.Text = "Krijn";
            this.TransparencyKey = System.Drawing.Color.LightGreen;
            this.Load += new System.EventHandler(this.Editor_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.treeContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textArea;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProjectFolderToolStripMenuItem;
        private System.Windows.Forms.TreeView projectTree;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ToolStripMenuItem openProjectFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeThemeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openProjectFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}

