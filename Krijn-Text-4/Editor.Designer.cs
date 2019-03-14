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
            this.textArea = new System.Windows.Forms.RichTextBox();
            this.save = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // textArea
            // 
            this.textArea.BackColor = System.Drawing.SystemColors.Window;
            this.textArea.Location = new System.Drawing.Point(12, 41);
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(776, 397);
            this.textArea.TabIndex = 0;
            this.textArea.Text = "";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(713, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(12, 13);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(695, 22);
            this.name.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.name);
            this.Controls.Add(this.save);
            this.Controls.Add(this.textArea);
            this.Name = "Editor";
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textArea;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

