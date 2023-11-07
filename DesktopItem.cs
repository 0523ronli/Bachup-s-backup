using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bachup_s_backup
{
    public partial class DesktopItem : Form
    {
        TransparentPanel Top_panel;
        public DesktopItem(string s, Image? img = null)
        {
            InitializeComponent();
            TopLevel = false;
            label1.Text = s;
            pictureBox1.Image = img;
        }
        public DesktopItem(string path)
        {
            InitializeComponent();
            TopLevel = false;
            label1.Text = Path.GetFileName(path);
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {

            }
            else
            {
                pictureBox1.Image = Icon.ExtractAssociatedIcon(path).ToBitmap();
            }
            Top_panel = new()
            {
                Location = new Point(0, 0),
                Size = this.Size,
                BackColor = Color.Transparent,
            };
            Controls.Add(Top_panel);
            Top_panel.BringToFront();
            Top_panel.MouseDoubleClick += (s, e) =>
            {
                using Process fileopener = new Process();
                fileopener.StartInfo.FileName = "explorer";
                fileopener.StartInfo.Arguments = "\"" + path + "\"";
                fileopener.Start();
            };
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            static extern bool ReleaseCapture();
            Top_panel.MouseDown += (s, e) =>
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            };
        }
    }
}
