using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Baldi_s_Basics_Plus_Level_Saver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathm = Path.Combine(path, "bbls");
            if (!Directory.Exists(pathm))
            {
                Directory.CreateDirectory(pathm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var notesdiag = new notes();
            notesdiag.Show();
        }

        private void starbtn_Click(object sender, EventArgs e)
        {
            var main = new main();
            main.Show();
            this.Hide();
        }
    }
}
