using System.Windows.Forms;
using System.Windows;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Net.WebRequestMethods;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Windows;
using System.Drawing.Design;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        List<DesktopItem> selected = new();
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, 1, 2 | 1, (int)Keys.F1);
            TopMost = true;
            //this.MinimizeBox = false;
            //FormBorderStyle = FormBorderStyle.Sizable;
            FormBorderStyle = FormBorderStyle.None;
            textBox1.DragEnter += MyDragEnter;
            textBox1.DragDrop += textBox1_DragDrop;
            MouseDown += (s, e) =>
            {
                Capture = false;
                Message msg = Message.Create(Handle, 161, new IntPtr(2), IntPtr.Zero);
                WndProc(ref msg);

            };
            DragEnter += (s, e) =>
            {
                e.Effect = DragDropEffects.Copy;
            };
            DragDrop += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string file in files)
                    {
                        DesktopItem DI = new(file, e.Data);
                        DI.Location = new Point(MousePosition.X - Location.X - DI.Width / 2, MousePosition.Y - Location.Y - DI.Height / 2);
                        DI.Visible = true;
                        Controls.Add(DI);
                    }
                }
                else
                {
                    MessageBox.Show(e.Data.GetFormats().ToString());
                }
            };
            FormClosed +=(s,e)=>{
                UnregisterHotKey(this.Handle, 1);
            };
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    m.Result = Cursor.Position switch
                    {
                        var p when p.X < Location.X + 20 && p.Y < Location.Y + 20 => 13,
                        var p when p.X > Location.X + Width - 20 && p.Y < Location.Y + 20 => 14,
                        var p when p.X < Location.X + 20 && p.Y > Location.Y + Height - 20 => 16,
                        var p when p.X > Location.X + Width - 20 && p.Y > Location.Y + Height - 20 => 17,
                        var p when p.X < Location.X + 20 => 10,
                        var p when p.X > Location.X + Width - 20 => 11,
                        var p when p.Y < Location.Y + 20 => 12,
                        var p when p.Y > Location.Y + Height - 20 => 15,
                        _ => 2,
                    };
                    break;
                case 0x0312:
                    if (m.WParam.ToInt32() == 1)
                    {
                        Visible = !Visible;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void MyDragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;

            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
            textBox1.Text = string.Join("\n", e.Data.GetFormats());

        }
        private void textBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //textBox1.Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        { 
            label1.Capture = false;
            var p = new Point(0, 0);
            Message msg = Message.Create(Handle, 0x112 /*WM_SYSCOMMAND*/, 0xF008 /*SC_SIZE + WMSZ_BOTTOMRIGHT*/, 0);
            WndProc(ref msg);
        }

    }
}