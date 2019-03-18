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

            string[] languages = Directory.GetFiles(@"languages/");

            foreach (string language in languages)
            {
                //Get file name withouth path
                var sections = language.Split('/');
                var fileName = sections[sections.Length - 1];
         
                //Create menu item
                var tempLanguage = new ToolStripMenuItem();
                tempLanguage.CheckOnClick = true;
                tempLanguage.Text = fileName;
                
                //Add menu item to dropdown menu
                languagesToolStripMenuItem.DropDownItems.Add(tempLanguage);
            }
        }

        // ######################## Methods #############################

        // Method to add project folder
        public void mthdOpenProjectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ListDirectory(projectTree, fbd.SelectedPath);

            projectTree.ExpandAll();
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
                directoryNode.Nodes.Add(new TreeNode(file.Name) { Tag = file.FullName });

            return directoryNode;
        }

        // Method to save current file
        public void mthdSaveFile()
        {
            SaveFileDialog saveFileDialogFunction = new SaveFileDialog();

            try
            {
                if (saveFileDialogFunction.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialogFunction.FileName))
                    {
                        File.WriteAllText(saveFileDialogFunction.FileName, textArea.Text);
                    }
                    else if (!File.Exists(saveFileDialogFunction.FileName))
                    {
                        using (Stream save = File.Open(saveFileDialogFunction.FileName, FileMode.CreateNew))
                        using (StreamWriter sw = new StreamWriter(save))
                        {
                            sw.Write(textArea.Text);
                        }
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Failed to save file. please try again.");
            }
        }
        
        // Method to open new file
        public void mthdOpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string strFileName = openFileDialog.FileName;
                    string fileText = File.ReadAllText(strFileName);
                    textArea.Text = fileText;
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Can't open file, please try again.");
            }
        }

        // ################################# Code for visual items ########################################
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mthdOpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mthdSaveFile();
        }

        private void addProjectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mthdOpenProjectFolder();
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
            mthdOpenProjectFolder();
        }


        public event TreeNodeMouseClickEventHandler NodeMouseDoubleClick;

        //In the works, pls help if u can. This should work. Check error/warning list.
        void projectTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                // Look for a file extension.
                if (e.Node.Text.Contains("."))
                    System.Diagnostics.Process.Start(@"c:\" + e.Node.Text);
            }
            // If the file is not found, handle the exception and inform the user.
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("File not found.");
            }
        }
    }
}
