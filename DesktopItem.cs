using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Bachup_s_backup
{
    public partial class DesktopItem : Form
    {
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);

        TransparentPanel Top_panel;
        public String FileName;
        public String FilePath;
        public static DesktopItem SaveCreate(string path, Point? locataion = null)
        {
            if (File.Exists(path)) return new(path) { Location = locataion ?? new() };
            else return null;
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

            if (!File.Exists(FilePath))
            {

            }
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

                    if (mousePos.X >= left && mousePos.X <= right && mousePos.Y >= top && mousePos.Y <= buttom)
                    {
                        mousePos.Offset(-left - clickedX, -top - clickedY);
                        Location = mousePos;
                    }
                    else
                    {
                        DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] { FilePath }), DragDropEffects.Copy);
                        M_dragging = false;
                        Location = orgi_P;
                    }
                }
            };

            Top_panel.MouseDown += (s, e) =>
            {
                clickedX = e.X;
                clickedY = e.Y;
                orgiX = Location.X;
                orgiY = Location.Y;
                orgi_P = Location;
                M_dragging = true;
                if (!GetAsyncKeyState(0x10))
                {
                    Form1.Instance.selected.Clear();
                }
                Form1.Instance.selected.Add(this);
                foreach (DesktopItem DI in Parent!.Controls)
                {
                    DI.BackColor = Form1.Instance.selected.Contains(DI) ? Color.LightBlue : SystemColors.ActiveBorder;
                }
            };
            Top_panel.MouseUp += (s, e) =>
            {
                M_dragging = false;
            };
        }
    }
}
