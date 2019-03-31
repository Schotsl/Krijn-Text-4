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
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;

namespace Krijn_Text_4
{
    public partial class Editor : MetroFramework.Forms.MetroForm, 
    {
        public static int predirectMatch;
        public static int predirectTyped;
        public static string predirectString = String.Empty;

        public static List<string> loadedLanguage = new List<string>();

        public Editor()
        {
            InitializeComponent();
            textArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            if (Directory.Exists("languages/"))
            {
                string[] languages = Directory.GetFiles(@"languages/");

                foreach (string filePath in languages)
                {
                    //Get file name withouth path
                    var sections = filePath.Split('/');
                    var fileName = sections[sections.Length - 1];

                    //Create menu item
                    var tempLanguage = new ToolStripMenuItem();
                    tempLanguage.CheckedChanged += new System.EventHandler(this.languagesToolStripMenuItem_CheckedChanged);
                    tempLanguage.CheckOnClick = true;
                    tempLanguage.Name = filePath;
                    tempLanguage.Text = fileName;

                    //Add menu item to dropdown menu
                    languagesToolStripMenuItem.DropDownItems.Add(tempLanguage);
                }
            }
        }



        // ###################### #############################

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

        public void mthdFilePath()
        {

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
                    foreach (string predictionString in loadedLanguage)
                    {
                        if (singleWord.Length > 0)
                        {
                            if (predictionString.Contains(singleWord))
                            {
                                int predictionMatch = 0;

                                //Count how many characters match
                                for (int i = 0; i < singleWord.Length; i ++)
                                {
                                    if (singleWord[i] == predictionString[i]) predictionMatch++;
                                    else return;
                                }

                                if (predictionMatch > 3)
                                {
                                    textBox4.Text = predictionString;                     
                                    predirectTyped = singleWord.Length;

                                    predirectMatch = predictionMatch;
                                    predirectString = predictionString;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void textArea_keyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (predirectMatch > 3)
                {
                    //Get soon to be location of caret
                    var caretString = predirectString.IndexOf('*');

                    //Remove caret locater from string
                    predirectString = predirectString.Replace("*", "");

                    //Add predicted string to textarea
                    string allText = textArea.Text;
                    string remainingText = allText.Remove(allText.Length - predirectTyped - 1);

                    textArea.Text = remainingText + predirectString;

                    //Move caret to right position
                    var caretLocation = textArea.SelectionStart;
                    textArea.SelectionStart = caretLocation + caretString;
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

        private void btnOpenTreeFile_Click(object sender, EventArgs e)
        {
        }
        
        private void languagesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //Empty loaded languages
            loadedLanguage =  new List<string>();

            //Add requested languages
            foreach (ToolStripMenuItem toolItem in languagesToolStripMenuItem.DropDownItems)
            {
                if (toolItem.Checked)
                {
                    var filePath = toolItem.Name;
                    var fileContent = File.ReadLines(filePath).ToArray();

                    foreach(string fileRow in fileContent)
                    {
                        loadedLanguage.Add(fileRow);
                    }
                }
            }
        }
        private void checkForUpdatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
