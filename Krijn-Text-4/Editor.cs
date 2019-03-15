﻿using System;
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
        private static string filePath;

        public Editor()
        {
            InitializeComponent();

           filePath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            filePath = Path.GetDirectoryName(filePath);
            filePath = filePath.Substring(6);
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
                if (File.Exists(saveFileDialogFunction.FileName))
                {
                    File.Delete(saveFileDialogFunction.FileName);
                }
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

                if (stringLength > caretLocation && caretLocation <= stringLength)
                {
                    //Should be moved to an external file
                    string[] predictionArray = new string[4];
                    predictionArray[0] = "html";
                    predictionArray[1] = "body";
                    predictionArray[2] = "head";
                    predictionArray[3] = "div";

                    foreach (string predictionString in predictionArray)
                    {
                        if (singleWord.Length > 0)
                        {
                            if (predictionString.Contains(singleWord))
                            {
                                textBox4.Text = predictionString;
                            }
                        }
                    }
                }
            }
        }

        private void openProjectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ListDirectory(projectTree, fbd.SelectedPath);
        }

        private void btnOpenSelectedFile_Click(object sender, EventArgs e)
        {
            string TreeNodeName = projectTree.SelectedNode.ToString().Replace("TreeNode: ", String.Empty);
            MessageBox.Show(filePath + "\\" + TreeNodeName);
            textArea.Text = filePath + "\\" + TreeNodeName;
        }
    }
}
