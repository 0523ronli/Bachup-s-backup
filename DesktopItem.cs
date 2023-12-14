using Bachup_s_backup;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Bachup_s_backup.Form1;

namespace Bachup_s_backup
{
    public partial class DesktopItem : Form
    {
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);

        public DesktopItem Instance;
        TransparentPanel Top_panel;
        public string FileName;
        public string FilePath;
        private bool M_toDrag = false;
        ContextMenuStrip RightClickMenu = new();
        ToolStripMenuItem RCM_open = new("Open");
        ToolStripMenuItem RCM_delete = new("Delete");
        ToolStripMenuItem open_explorer = new("Open in explorer");
        ToolStripMenuItem RCM_rename = new("Rename");

        public DesktopItem(string path)
        {
            Instance = this;
            FilePath = path;
            FileName = Path.GetFileName(path);
            InitializeComponent();
            InitVarieties();
            InitializeContextMenu();
            InitPictureBox();
            

            Top_panel!.MouseDoubleClick += onMouseDoubleClick;
            Top_panel.MouseMove += onMouseMove;
            Top_panel.MouseDown += onMouseDown;
            Top_panel.MouseUp += onMouseUp;
        }

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
            RCM_delete.Click += (s, e) =>
            {
                (Parent as Form1)!.selected.DeleteAll();
            };
            RightClickMenu.Items.Add(RCM_delete);

            open_explorer.Click += (s, e) =>
            {
                foreach (var item in (Parent as Form1)!.selected)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{item.FilePath}\\..\"" } }.Start();
                }
            };
            RightClickMenu.Items.Add(open_explorer);
            RCM_rename.Click += (s, e) =>
            {
                Form f = new();
                
            };
            RightClickMenu.Items.Add(RCM_rename);
        }
        public static DesktopItem SaveCreate(string path, Point? locataion = null)
        {
            if (File.Exists(path) || Directory.Exists(path))
            {
                return new(path)
                {
                    Location = locataion ?? new(),
                };
            }
            else return null!;
        }

        private void onMouseUp(object? sender, MouseEventArgs e)
        {
            M_toDrag = false;
            //if (e.Button == MouseButtons.Left)
            //{
            //    if (!GetAsyncKeyState(0x10)) //Shift Button Up
            //    {
            //        (Parent as Form1)!.selected.Clear();
            //    }
            //    (Parent as Form1)!.selected.Add(this);
            //}
        }

        private void onMouseDown(object? sender, MouseEventArgs e)
        {
            (Parent as Form1)!.selected.Clear();
            (Parent as Form1)!.selected.Add(this);
            if (e.Button == MouseButtons.Left)
            {
                M_toDrag = true;
            }
            else
            {
                RightClickMenu.Show(this, e.Location);
            }
        }
        private void onMouseMove(object? sender, MouseEventArgs e)
        {
            if (M_toDrag)
            {
                var mousePos = Cursor.Position;
                (Parent as Form1)!.MakeDrag();
                M_toDrag = false;
            }
        }
        private void onMouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{FilePath}\"" } }.Start();
            }
        }

        private void InitVarieties()
        {
            TopLevel = false;
            Top_panel = new();
            Controls.Add(Top_panel);
            Top_panel.BringToFront();
            Visible = true;
            label1.Text = FileName.Length > 15 ? FileName[..14] + "..." : FileName;
        }

        private void InitPictureBox()
        {
            if ((File.GetAttributes(FilePath) & FileAttributes.Directory) != FileAttributes.Directory)
            {
                try
                {
                    pictureBox1.Image = Icon.ExtractAssociatedIcon(FilePath)!.ToBitmap();
                }
                catch (Exception) { }
            }
        }
        protected override void OnPaint(PaintEventArgs e=null!)
        {
            base.OnPaint(e);
            Visible = Form1_Instance.DI_visable;
            label1.ForeColor = Form1_Instance.config_JSON.DI_ForeColor.Hex2Coler();
            BackColor = Form1_Instance.config_JSON.DI_BackColor.Hex2Coler();
            Size = Form1_Instance.config_JSON.DI_size;
        }

        public void OnRender()
        {
            OnPaint();
        }
        
    }
}
