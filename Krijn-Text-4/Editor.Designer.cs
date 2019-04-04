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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProjectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectTree = new System.Windows.Forms.TreeView();
            this.projectTreeContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.openProjectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.projectTreeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // textArea
            // 
            this.textArea.BackColor = System.Drawing.SystemColors.Window;
            this.textArea.Location = new System.Drawing.Point(221, 117);
            this.textArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textArea.MaximumSize = new System.Drawing.Size(1332, 1230);
            this.textArea.MinimumSize = new System.Drawing.Size(880, 434);
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(880, 434);
            this.textArea.TabIndex = 0;
            this.textArea.Text = "";
            this.textArea.TextChanged += new System.EventHandler(this.textArea_TextChanged);
            this.textArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textArea_keyPressed);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(27, 74);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1075, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectFolderToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // addProjectFolderToolStripMenuItem
            // 
            this.addProjectFolderToolStripMenuItem.Name = "addProjectFolderToolStripMenuItem";
            this.addProjectFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.addProjectFolderToolStripMenuItem.Size = new System.Drawing.Size(301, 26);
            this.addProjectFolderToolStripMenuItem.Text = "Add Project Folder";
            this.addProjectFolderToolStripMenuItem.Click += new System.EventHandler(this.addProjectFolderToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.languagesToolStripMenuItem.Text = "Languages";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // projectTree
            // 
            this.projectTree.ContextMenuStrip = this.projectTreeContextMenu;
            this.projectTree.Location = new System.Drawing.Point(27, 117);
            this.projectTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.projectTree.Name = "projectTree";
            this.projectTree.Size = new System.Drawing.Size(187, 400);
            this.projectTree.TabIndex = 5;
            this.projectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.projectTree_AfterSelect);
            // 
            // projectTreeContextMenu
            // 
            this.projectTreeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.projectTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectFolderToolStripMenuItem});
            this.projectTreeContextMenu.Name = "projectTreeContextMenu";
            this.projectTreeContextMenu.Size = new System.Drawing.Size(211, 28);
            // 
            // openProjectFolderToolStripMenuItem
            // 
            this.openProjectFolderToolStripMenuItem.Name = "openProjectFolderToolStripMenuItem";
            this.openProjectFolderToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.openProjectFolderToolStripMenuItem.Text = "Open Project Folder";
            this.openProjectFolderToolStripMenuItem.Click += new System.EventHandler(this.openProjectFolderToolStripMenuItem_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(27, 526);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(187, 22);
            this.textBox4.TabIndex = 9;
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.checkForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click_1);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 566);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.projectTree);
            this.Controls.Add(this.textArea);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Editor";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Krijn";
            this.TransparencyKey = System.Drawing.Color.LightGreen;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.projectTreeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textArea;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProjectFolderToolStripMenuItem;
        private System.Windows.Forms.TreeView projectTree;
        private System.Windows.Forms.TextBox textBox4;
        private MetroFramework.Controls.MetroContextMenu projectTreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openProjectFolderToolStripMenuItem;
        private MetroFramework.Controls.MetroButton btnOpenSelectedFile;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
    }
}

