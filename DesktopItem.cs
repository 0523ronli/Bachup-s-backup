﻿using Bachup_s_backup;
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
        public bool Intemp=false;

        ToolStripMenuItem RCM_open = new("Open");
        ToolStripMenuItem RCM_delete = new("Delete");
        ToolStripMenuItem RCM_temp = new("Move Into Temp");
        ToolStripMenuItem RCM_open_explorer = new("Open in explorer");

        public DesktopItem(string path)
        {
            Instance = this;
            FilePath = path.FullPath();
            FileName = Path.GetFileName(path);
            InitializeComponent();
            InitVarieties();
            InitRCM();
            InitPictureBox();
            

            Top_panel!.MouseDoubleClick += onMouseDoubleClick;
            Top_panel.MouseMove += onMouseMove;
            Top_panel.MouseDown += onMouseDown;
            Top_panel.MouseUp += onMouseUp;
        }

        private void InitRCM()
        {
            
            RCM_open.Click += (s, e) =>
            {
                foreach (var item in (Parent as Form1)!.selected)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{item.FilePath}\"" } }.Start();
                }
            };
            RightClickMenu.Items.Add(RCM_open);
            

            RCM_open_explorer.Click += (s, e) =>
            {
                foreach (var item in (Parent as Form1)!.selected)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{item.FilePath}\\..\"" } }.Start();
                }
            };
            RightClickMenu.Items.Add(RCM_open_explorer);
            RCM_temp.Click += (s, e) => {
                string NewPath = @$"{Program.TempPath}\{FileName}".FullPath();
                if (!Directory.Exists(Program.TempPath))
                {
                    Directory.CreateDirectory(Program.TempPath);
                }
                if (File.Exists(FilePath))
                {
                    File.Move(FilePath,NewPath);
                }else if (Directory.Exists(FilePath))
                {
                    Directory.Move(FilePath,NewPath);
                }
                FilePath = NewPath;
                Intemp = true;
                RCM_temp.Enabled = false;
                label_folder.Visible = true;
            };
            RightClickMenu.Items.Add(RCM_temp);

            RCM_delete.ForeColor = Color.Red;
            RCM_delete.Font = new Font(RCM_delete.Font, FontStyle.Bold);
            RCM_delete.Click += (s, e) =>
            {
                
                Form1_Instance.selected.DeleteAll();
            };
            RightClickMenu.Items.Add(RCM_delete);
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
            Form1_Instance.selected.Clear();
            Form1_Instance.selected.Add(this);
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
            if (FilePath.FullPath().StartsWith(Program.TempPath))
            {
                Intemp = true;
            }
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
            label_folder.Visible = Intemp;
            RCM_temp.Enabled = !Intemp;
            pictureBox1.SendToBack();
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
