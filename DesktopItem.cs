using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Input;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Bachup_s_backup
{
    public partial class DesktopItem : Form
    {
        public HashSet<DesktopItem> selected = new();
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);
        TransparentPanel Top_panel;
        public String FileName;
        public String FilePath;
        public DesktopItem(string path)
        {
            InitializeComponent();

            TopLevel = false;
            FilePath = path;
            FileName = Path.GetFileName(path);
            Top_panel = new();
            Controls.Add(Top_panel);
            Top_panel.BringToFront();

            label1.Text = FileName.Length > 15 ? FileName[..14] + "..." : FileName;
            if ((File.GetAttributes(path) & FileAttributes.Directory) != FileAttributes.Directory)
            {
                try
                {
                    pictureBox1.Image = Icon.ExtractAssociatedIcon(FilePath)!.ToBitmap();
                }catch (Exception)
                {

                }
            }

            Top_panel.MouseDoubleClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{FilePath}\"" } }.Start();
                }
            };


            bool moveing = false;
            int clickedX = 0, clickedY = 0;
            int orgiX = 0, orgiY = 0;
            Point orgi_P = Location;
            Top_panel.MouseMove += (s, e) =>
            {
                if (moveing)
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
                        //Form1.Instance.createDrag();
                        DoDragDrop(new DataObject(DataFormats.FileDrop,new string[] { FilePath }), DragDropEffects.Copy);
                        moveing = false;
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
                moveing = true;
                if(!GetAsyncKeyState((int)Keys.Shift))Form1.Instance.selected.Clear();
                Form1.Instance.selected.Add(this);
            };
            Top_panel.MouseUp += (s, e) =>
            {
                moveing = false;
            };
        }
        //public DesktopItem(object data)
        //{
        //    this.D_data = D_data;
        //    InitializeComponent();

        //    TopLevel = false;
        //    var name = Path.GetFileName(path);
        //    label1.Text = name.Length > 15 ? name.Substring(0, 14) + "..." : name;
        //    //label1.Text = name;
        //    if ((File.GetAttributes(path) & FileAttributes.Directory) != FileAttributes.Directory)
        //    {
        //        pictureBox1.Image = Icon.ExtractAssociatedIcon(path)!.ToBitmap();
        //    }


        //    Top_panel = new()
        //    {
        //        Dock = DockStyle.Fill,
        //    };
        //    Controls.Add(Top_panel);
        //    Top_panel.BringToFront();
        //    Top_panel.MouseDoubleClick += (s, e) =>
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{path}\"" } }.Start();
        //        }
        //    };


        //    bool dragging = false;
        //    int clickedX = 0, clickedY = 0;
        //    int orgiX = 0, orgiY = 0;
        //    Point orgi_P = Location;
        //    Top_panel.MouseMove += (s, e) =>
        //    {
        //        if (dragging)
        //        {
        //            var left = (Parent as Form)!.Location.X;
        //            var right = (Parent as Form)!.Location.X + (Parent as Form)!.Width;
        //            var top = (Parent as Form)!.Location.Y;
        //            var buttom = (Parent as Form)!.Location.Y + (Parent as Form)!.Height;

        //            var mousePos = Cursor.Position;

        //            if (mousePos.X >= left && mousePos.X <= right && mousePos.Y >= top && mousePos.Y <= buttom)
        //            {
        //                mousePos.Offset(-left - clickedX, -top - clickedY);
        //                Location = mousePos;
        //            }
        //            else
        //            {
        //                DoDragDrop(D_data, DragDropEffects.Copy);
        //                dragging = false;
        //                Location = orgi_P;
        //            }
        //        }
        //    };

        //    Top_panel.MouseDown += (s, e) =>
        //    {
        //        clickedX = e.X;
        //        clickedY = e.Y;
        //        orgiX = Location.X;
        //        orgiY = Location.Y;
        //        orgi_P = Location;
        //        dragging = true;

        //    };
        //    Top_panel.MouseUp += (s, e) =>
        //    {
        //        dragging = false;
        //    };

        //}
    }
}
