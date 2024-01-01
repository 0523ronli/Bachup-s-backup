using Bachup_s_backup;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Bachup_s_backup.MainDesktop;
using Timer = System.Windows.Forms.Timer;

namespace Bachup_s_backup
{
    public partial class DesktopItem : Form
    {
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);

        public DesktopItem Instance;
        TransparentPanel Top_panel=new();
        public string FileName;
        public string FilePath;
        public string NickName="";
        private bool M_toDrag = false;
        ContextMenuStrip RightClickMenu = new();
        public bool Intemp=false;
        ToolStripMenuItem RCM_open = new("Open");
        ToolStripMenuItem RCM_rename = new("Info and Rename");
        ToolStripMenuItem RCM_temp = new("Move Into Temp");
        ToolStripMenuItem RCM_open_explorer = new("Open in explorer");
        ToolStripMenuItem RCM_delete = new("Delete");

        public DesktopItem(string path)
        {
            Instance = this;
            FilePath = path.FullPath();
            FileName = Path.GetFileName(path);
            TopLevel = false;

            InitializeComponent();

            Controls.Add(Top_panel);
            Top_panel.BringToFront();
            Visible = true;
            if (FilePath.FullPath().StartsWith(Program.TempPath))
            {
                Intemp = true;
            }

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
                foreach (var item in (Parent as MainDesktop)!.selected)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{item.FilePath}\"" } }.Start();
                }
            };
            RightClickMenu.Items.Add(RCM_open);
            
            //open in explorer
            RCM_open_explorer.Click += (s, e) =>
            {
                foreach (var item in (Parent as MainDesktop)!.selected)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"/select,\"{item.FilePath}\"" } }.Start();
                }
            };
            RightClickMenu.Items.Add(RCM_open_explorer);

            //temp
            RCM_temp.Click += (s, e) => {
                string NewPath = @$"{Program.TempPath}\{FileName}".FullPath();
                if (!Directory.Exists(Program.TempPath))
                {
                    Directory.CreateDirectory(Program.TempPath);
                }
                if (File.Exists(FilePath))
                {
                    File.Move(FilePath,NewPath,true);
                }else if (Directory.Exists(FilePath))
                {
                    if(Directory.Exists(NewPath))Directory.Delete(NewPath,true);
                    Directory.Move(FilePath,NewPath);
                }
                FilePath = NewPath;
                Intemp = true;
                RCM_temp.Enabled = false;
                label_folder.Visible = true;
            };
            RightClickMenu.Items.Add(RCM_temp);

            //rename
            RCM_rename.Click += (s, e) =>
            {
                Desktop_Instance.TopMost = false;
                var f = new DI_Info(this);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    NickName = f.textBox3.Text;
                }
                Refresh();
                ;
                Desktop_Instance.TopMost = true;
            };
            RightClickMenu.Items.Add(RCM_rename);

            //delete
            RCM_delete.ForeColor = Color.Red;
            RCM_delete.Font = new Font(RCM_delete.Font, FontStyle.Bold);
            RCM_delete.Click += (s, e) =>
            {
                
                Desktop_Instance.selected.ToList().ForEach(x =>
                {
                    if (x.Intemp)
                    {
                        if (File.Exists(x.FilePath)) File.Delete(x.FilePath);
                        else if (Directory.Exists(x.FilePath)) Directory.Delete(x.FilePath, true);
                    }
                    x.Dispose();
                });
                Desktop_Instance.selected.Clear();
                GC.Collect();
            };
            RightClickMenu.Items.Add(RCM_delete);
        }
        public static DesktopItem SaveCreate(string path, Point? locataion = null, string NickName = "")
        {
            if (File.Exists(path) || Directory.Exists(path))
            {
                return new(path)
                {
                    Location = locataion ?? new(),
                    NickName = NickName
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
            Desktop_Instance.selected.Clear();
            Desktop_Instance.selected.Add(this);
            if (e.Button == MouseButtons.Left)
            {
                M_toDrag = true;
            }
            else
            {
                RightClickMenu.Show(this, e.Location);
            }
            Desktop_Instance.Refresh();
        }
        private void onMouseMove(object? sender, MouseEventArgs e)
        {
            if (M_toDrag)
            {
                var mousePos = Cursor.Position;
                (Parent as MainDesktop)!.MakeDrag();
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

        private void InitPictureBox()
        {
            try
            {
                try
                {
                    using (FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                    {
                        try
                        {
                            Image image = Image.FromStream(stream); ;
                            if (ImageAnimator.CanAnimate(image))
                            {
                                pictureBox1.Image = Program.GIFToImage(FilePath);
                            }
                            else
                            {
                                pictureBox1.Image = Image.FromStream(stream); ;
                            }
                        }
                        catch (Exception)
                        {
                            pictureBox1.Image = Icon.ExtractAssociatedIcon(FilePath)?.ToBitmap();
                        }
                    }
                }
                catch (Exception)
                {
                    pictureBox1.Image = Icon.ExtractAssociatedIcon(FilePath)?.ToBitmap();
                }
            }
            catch (Exception)
            {

            }
            
        }
        protected override void OnPaint(PaintEventArgs e=null!)
        {
            base.OnPaint(e);
            label_folder.Visible = Intemp;
            RCM_temp.Enabled = !Intemp;
            pictureBox1.SendToBack();
            Visible = Desktop_Instance.DI_visable;
            Label_Name.Text = NickName == "" ? FileName : NickName;
            Label_Name.ForeColor = Desktop_Instance.config_JSON.DI_ForeColor.Hex2Color();
            BackColor = Desktop_Instance.selected.Contains(this) ?
                Desktop_Instance.config_JSON.DI_selectedColor.Hex2Color() :
                Desktop_Instance.config_JSON.DI_BackColor.Hex2Color();
            //if (Desktop_Instance.config_JSON.DI_Transparent) BackColor = Color.Transparent;
            //if (Desktop_Instance.config_JSON.DI_Transparent) TransparencyKey = BackColor;
            //else TransparencyKey = Color.Empty;
            Size = Desktop_Instance.config_JSON.DI_size;
        }

        public void OnRender()
        {
            OnPaint();
        }
        
    }
}
