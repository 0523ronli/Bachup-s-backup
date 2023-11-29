using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bachup_s_backup
{
    public partial class DesktopItem : Form
    {
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);

        TransparentPanel Top_panel;
        public string FileName;
        public string FilePath;
        private ContextMenuStrip RightClickMenu;
        private ToolStripMenuItem RCM_Item1;
        private ToolStripMenuItem RCM_item2;
        private void InitializeContextMenu()
        {
            RightClickMenu = new ContextMenuStrip();

            RCM_Item1 = new ToolStripMenuItem("菜单项1");
            RCM_Item1.Click += MenuItem1_Click;
            RightClickMenu.Items.Add(RCM_Item1);

            RCM_item2 = new ToolStripMenuItem("菜单项2");
            RCM_item2.Click += MenuItem2_Click;
            RightClickMenu.Items.Add(RCM_item2);
        }
        private void MenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gay1！");
        }

        private void MenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gay2！");
        }
        public static DesktopItem SaveCreate(string path, Point? locataion = null)
        {
            if (File.Exists(path)||Directory.Exists(path)) return new(path) { Location = locataion ?? new() };
            else return null!;
        }
        private DesktopItem(string path)
        {
            InitializeComponent();

            TopLevel = false;
            FilePath = path;
            FileName = Path.GetFileName(path);
            Top_panel = new();
            Controls.Add(Top_panel);
            Top_panel.BringToFront();
            Visible = true;

            label1.Text = FileName.Length > 15 ? FileName[..14] + "..." : FileName;
            if ((File.GetAttributes(path) & FileAttributes.Directory) != FileAttributes.Directory)
            {
                try
                {
                    pictureBox1.Image = Icon.ExtractAssociatedIcon(FilePath)!.ToBitmap();
                }
                catch (Exception) { }
            }

            Top_panel.MouseDoubleClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{FilePath}\"" } }.Start();
                }
            };

            bool M_dragging = false;
            int clickedX = 0, clickedY = 0;
            int orgiX = 0, orgiY = 0;
            Point orgi_P = Location;
            Top_panel.MouseMove += (s, e) =>
            {
                if (M_dragging)
                {
                    var left = (Parent as Form)!.Location.X;
                    var right = (Parent as Form)!.Location.X + (Parent as Form)!.Width;
                    var top = (Parent as Form)!.Location.Y;
                    var buttom = (Parent as Form)!.Location.Y + (Parent as Form)!.Height;

                    var mousePos = Cursor.Position;
                    (Parent as Form1)!.MakeDrag();
                    M_dragging = false;

                }
            };

            Top_panel.MouseDown += (s, e) =>
            {
                if(e.Button == MouseButtons.Left)
                {
                    M_dragging = true;


                    (Parent as Form1)!.selected.Add(this);
                }

                clickedX = e.X;
                clickedY = e.Y;
                orgiX = Location.X;
                orgiY = Location.Y;
                orgi_P = Location;
                
            };
            
            Top_panel.MouseUp += (s, e) =>
            {
                M_dragging = false;
                if (!GetAsyncKeyState(0x10)) //Shift Button Up
                {
                    (Parent as Form1)!.selected.Clear();
                }
            };
            
        }
    }
}
