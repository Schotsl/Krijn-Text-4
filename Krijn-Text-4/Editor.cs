using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krijn_Text_4
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void save_click(object sender, EventArgs e)
        {
            string textArea = this.textArea.Text;
            File.WriteAllText(name.Text, this.textArea.Text);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = openFileDialog1.FileName;
                string fileText = File.ReadAllText(strFileName);
                textArea.Text = fileText;
            }
        }
    }
}
