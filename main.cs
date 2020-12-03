using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Baldi_s_Basics_Plus_Level_Saver
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathd = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathe = Path.Combine(pathd, "bbls");
            string gamepatht1 = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            string gamepatht2 = Path.Combine(gamepatht1, "appdata");
            string gamepatht3 = Path.Combine(gamepatht2, "LocalLow");
            string gamepatht4 = Path.Combine(gamepatht3, "Basically Games");
            string gamepatht5 = Path.Combine(gamepatht4, "Baldi's Basics Plus");
            string name = bbname.Text;
            string s3venametmp1 = "PlayerFile_" + name;
            string s3venametmp2 = s3venametmp1;
            string s3venametmp3 = s3venametmp2 + ".dat";
            string gamepath = gamepatht5 + @"\";
            string s3vename = Path.Combine(gamepath, s3venametmp3);
            string saavename = Path.Combine(pathe, s3venametmp3);
            if (!File.Exists(s3vename))
            {
                MessageBox.Show("No save file with this name exists on your game. Please make sure you have saved in BB+ before trying to save here.", "Error");
            }
            else
            {
                File.Copy(s3vename, saavename, true);
                MessageBox.Show("The save file has been saved into the program's data. You can now load this save whenver you want");
            }
        }

        private void loadbtn_Click(object sender, EventArgs e)
        {
            string pathd = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathe = Path.Combine(pathd, "bbls");
            string name = bbname.Text;
            string savenametmp1 = "PlayerFile_" + name;
            string savenametmp2 = savenametmp1;
            string savenametmp3 = savenametmp2 + ".dat";
            string savename = Path.Combine(pathe, savenametmp3);
            string gamepatht1 = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            string gamepatht2 = Path.Combine(gamepatht1, "appdata");
            string gamepatht3 = Path.Combine(gamepatht2, "LocalLow");
            string gamepatht4 = Path.Combine(gamepatht3, "Basically Games");
            string gamepatht5 = Path.Combine(gamepatht4, "Baldi's Basics Plus");
            string gamepath = gamepatht5 + @"\";
            string gamefilepath = Path.Combine(gamepath, savenametmp3);
            if (!File.Exists(savename))
            {
                MessageBox.Show("No save file with this name has been saved. Please make sure you have saved before trying to load.", "Error");
            }
            else
            {
                File.Copy(savename, gamefilepath, true);
                MessageBox.Show("The save file has been saved loaded into your game. You may now launch Baldi's Basics +");
            }
        }


        private void main_Load(object sender, EventArgs e)
        {
            string pathd = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathe = Path.Combine(pathd, "bbls");
            if (!Directory.Exists(pathe))
            {
                Directory.CreateDirectory(pathe);
            }
        }
    }
}
