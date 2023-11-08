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
        Point offset;
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
            var name = Path.GetFileName(path);
            label1.Text = name.Length > 10 ? name.Substring(0, 9) + "..." : name;
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
                BackColor = Color.Black,
            };
            Controls.Add(Top_panel);
            Top_panel.BringToFront();

            bool drag = false;
            Top_panel.MouseDoubleClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    using Process fileopener = new Process();
                    fileopener.StartInfo.FileName = "explorer";
                    fileopener.StartInfo.Arguments = "\"" + path + "\"";
                    fileopener.Start();
                }
            };

            Top_panel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    drag = true;
                    offset = e.Location;
                }
            };

            Top_panel.MouseMove += (s, e) =>
            {
                if (drag) Location = new Point(Location.X + e.X - offset.X, Location.Y + e.Y - offset.Y);
            };

            Top_panel.MouseUp += (s, e) => drag = false;
        }
    }
}
