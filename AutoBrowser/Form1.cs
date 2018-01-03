using System;
using System.IO;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;

namespace AutoBrowser
{
    public partial class FormAutoBrowser : Form
    {
        private string[] instructions = null;
        public FormAutoBrowser()
        {
            InitializeComponent();
        }

        private void buttonSelectScript_Click(object sender, EventArgs e)
        {
            // load script
            OpenFileDialog dialog = new OpenFileDialog();
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                instructions = File.ReadAllLines(fileName);

            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            // run script
            if (instructions == null) return;
            var script = new Script(instructions);
            if (script.IsValid) script.ExecuteScript();
        }
    }
}
