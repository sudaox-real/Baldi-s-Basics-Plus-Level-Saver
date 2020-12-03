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
using System.Runtime.InteropServices;

namespace Baldi_s_Basics_Plus_Level_Saver
{
    public partial class main : Form
    {
        #region DWM stuff
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }
        #endregion

        public main()
        {
            m_aeroEnabled = false;
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
                MessageBox.Show("No save file with this name exists on your game. Please make sure you have saved in BB+ before trying to save here.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(s3vename, saavename, true);
                MessageBox.Show("The save file has been saved into the program's data. You can now load this save whenever you want", name, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No save file with this name has been saved. Please make sure you have saved before trying to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(savename, gamefilepath, true);
                MessageBox.Show("The save file has been saved loaded into your game. You may now launch Baldi's Basics +", name, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(32,32,32);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(64,64,64);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(64,64,64);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(32,32,32);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                panel1.Capture = false; //select control

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
    }
}
