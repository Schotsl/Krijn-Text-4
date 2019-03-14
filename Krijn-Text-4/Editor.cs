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
            File.WriteAllText("text.txt", this.textArea.Text);
        }

        private void text_change(object sender, EventArgs e)
        {
 
        }
    }
}
