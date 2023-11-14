using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bachup_s_backup
{
    public partial class DesktopItem : Form
    {
        TransparentPanel Top_panel;
        object D_data;
        public DesktopItem(string path,object D_data)
        {
            this.D_data = D_data;
            InitializeComponent();
            TopLevel = false;
            var name = Path.GetFileName(path);
            label1.Text = name.Length > 10 ? name.Substring(0, 9) + "..." : name;
            if ((File.GetAttributes(path) & FileAttributes.Directory) != FileAttributes.Directory)
            {
                try
                {
                    pictureBox1.Image = Icon.ExtractAssociatedIcon(path)!.ToBitmap();
                }catch (Exception ex) { }
           
            }
            Top_panel = new()
            {
                Location = new Point(0, 0),
                Size = this.Size,
                BackColor = Color.Black,
            };
            Controls.Add(Top_panel);
            Top_panel.BringToFront();
            bool doubleClicking = false;

            Top_panel.MouseDoubleClick += (s, e) =>
            {
                bool doubleClicking = true;
                if (e.Button == MouseButtons.Left)
                {
                    using Process fileopener = new Process();
                    fileopener.StartInfo.FileName = "explorer";
                    fileopener.StartInfo.Arguments = "\"" + path + "\"";
                    fileopener.Start();
                }
            };


            bool dragging = false;
            int clickedX = 0, clickedY = 0;
            int orgiX = 0, orgiY = 0;
            Point orgi_P=Location;
            Top_panel.MouseMove += (s, e) =>
            {
                if (dragging)
                {
                    var left = (Parent as Form).Location.X;
                    var right = (Parent as Form).Location.X + (Parent as Form).Width;
                    var top = (Parent as Form).Location.Y;
                    var buttom = (Parent as Form).Location.Y + (Parent as Form).Height;

                    var mousePos = Cursor.Position;

                    if (mousePos.X >= left && mousePos.X <= right && mousePos.Y >= top && mousePos.Y <= buttom)
                    {
                        mousePos.Offset(-left - clickedX, -top - clickedY);
                        Location = mousePos;
                    }
                    else
                    {
                        DoDragDrop(D_data, DragDropEffects.Move);
                        dragging = false;
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
                dragging = true;
            };
            Top_panel.MouseUp += (s, e) => { 
                dragging = false;
            };

        }
    }
}
