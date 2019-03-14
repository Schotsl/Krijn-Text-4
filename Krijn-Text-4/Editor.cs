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
            SaveFileDialog saveFileDialogFunction = new SaveFileDialog();

            if (saveFileDialogFunction.ShowDialog() == DialogResult.OK)
            {
                using (Stream save = File.Open(saveFileDialogFunction.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(save))
                {
                    sw.Write(textArea.Text);
                }
            }
        }



        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = openFileDialog.FileName;
                string fileText = File.ReadAllText(strFileName);
                textArea.Text = fileText;
            }
        }
    }
}
