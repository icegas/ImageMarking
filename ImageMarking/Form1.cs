using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMarking
{
    public partial class FileOpen : Form
    {
        public FileOpen()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Custom Description";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Path.Text = fbd.SelectedPath;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main = new Main(Path.Text);
            main.Closed += (s, args) => this.Close();
            main.Show();
        }
    }
}
