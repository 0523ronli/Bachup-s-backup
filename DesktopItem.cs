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
        ContextMenuStrip RightClickMenu = new ContextMenuStrip();
        ToolStripMenuItem RCM_open = new ToolStripMenuItem("Open");
        ToolStripMenuItem RCM_delete = new ToolStripMenuItem("Delete");
        ToolStripMenuItem open_explorer = new ToolStripMenuItem("Open in explorer");
        private void InitializeContextMenu()
        {
            RCM_open.Click += (s, e) =>
            {
                foreach (var item in (Parent as Form1)!.selected)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{item.FilePath}\"" } }.Start();
                }
            };
            RightClickMenu.Items.Add(RCM_open);
            RCM_delete.Click += (s,e)=> {
                (Parent as Form1)!.selected.DeleteAll();
            };
            RightClickMenu.Items.Add(RCM_delete);

            open_explorer.Click += (s, e) => {
                foreach (var item in (Parent as Form1)!.selected)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{item.FilePath}\\..\"" } }.Start();
                }
            };
            RightClickMenu.Items.Add(open_explorer);
        }
        public static DesktopItem SaveCreate(string path, Point? locataion = null)
        {
            if (File.Exists(path)||Directory.Exists(path)) return new(path) { Location = locataion ?? new() };
            else return null!;
        }
        private DesktopItem(string path)
        {
            InitializeComponent();
            InitializeContextMenu();

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

            bool M_toDrag = false;
            Top_panel.MouseMove += (s, e) =>
            {
                if (M_toDrag)
                {
                    var mousePos = Cursor.Position;
                    (Parent as Form1)!.MakeDrag();
                    M_toDrag = false;
                }
            };

            Top_panel.MouseDown += (s, e) =>
            {
                
                if (e.Button == MouseButtons.Left)
                {
                    M_toDrag = true;
                    (Parent as Form1)!.selected.Add(this);
                }
                else
                {
                    RightClickMenu.Show(this, e.Location);
                    if (!GetAsyncKeyState(0x10)) //Shift Button Up
                    {
                        (Parent as Form1)!.selected.Clear();
                    }
                    (Parent as Form1)!.selected.Add(this);
                }
            };
            
            Top_panel.MouseUp += (s, e) =>
            {
                M_toDrag = false;
                if(e.Button== MouseButtons.Left)
                {
                    if (!GetAsyncKeyState(0x10)) //Shift Button Up
                    {
                        (Parent as Form1)!.selected.Clear();
                    }
                    (Parent as Form1)!.selected.Add(this);
                }
                
            };
            
        }
    }
}
