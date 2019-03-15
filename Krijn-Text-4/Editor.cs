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
    public partial class Editor : MetroFramework.Forms.MetroForm
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = openFileDialog.FileName;
                string fileText = File.ReadAllText(strFileName);
                textArea.Text = fileText;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void addProjectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ListDirectory(projectTree, fbd.SelectedPath);
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);

            treeView.Nodes.Add(projectDirectory(rootDirectoryInfo));
        }

        private static TreeNode projectDirectory(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(projectDirectory(directory));

            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));

            return directoryNode;
        }

        private void textArea_TextChanged(object sender, EventArgs e)
        {
            var caretLocation = textArea.SelectionStart;
            var stringLength = 0;

            foreach (var singleWord in textArea.Text.Split(' '))
            {
                int startWord = stringLength;

                stringLength ++;
                stringLength += singleWord.Length;

                textBox4.Text = startWord.ToString() + " " + stringLength.ToString() + caretLocation.ToString();
                if (stringLength > caretLocation && caretLocation <= stringLength)
                {
                    textBox4.Text = singleWord;
                }
            }
        }
    }
}
