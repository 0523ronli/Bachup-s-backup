//using System.Windows.Forms;

using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        List<DesktopItem> selected = new();
        public Form1()
        {
            InitializeComponent();

            TopMost = true;
            //this.MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            textBox1.DragEnter += MyDragEnter;
            textBox1.DragDrop += textBox1_DragDrop;
            MouseDown += (s, e) =>
            {
                Capture = false;
                var p = new Point(0, 0);
                Message msg = Message.Create(Handle, 161, 0x2, ((p.Y << 16) | p.X));
                msg = Message.Create(Handle, 0x112 /*WM_SYSCOMMAND*/, 0xF008 /*SC_SIZE + WMSZ_BOTTOMRIGHT*/, 0);
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
                        //MessageBox.Show("Name¡G" + Path.GetFileName(file) + "\nPath¡G" + file, "info");
                        DesktopItem DI = new(file, e.Data);
                        DI.Location = new Point(MousePosition.X - Location.X, MousePosition.Y - Location.Y);
                        //MessageBox.Show(DI.Location.ToString());
                        DI.Visible = true;
                        Controls.Add(DI);
                    }
                }
                else
                {
                    MessageBox.Show(e.Data.GetFormats().ToString());

                }
            };
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
        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
        }
        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            //Point lParam = Cursor.Position;
            //lParam = PointToClient(lParam);
            //Message msg = Message.Create(Handle, 0x84 /*WM_NCHITTEST*/, IntPtr.Zero, (IntPtr)((lParam.Y << 16) | lParam.X));
            //if ((int)msg.Result == 0x0 /*HTCLIENT*/)
            //{
            //    msg = Message.Create(Handle, 0x112 /*WM_SYSCOMMAND*/, (IntPtr)0xF008 /*SC_SIZE + WMSZ_BOTTOMRIGHT*/, IntPtr.Zero);
            //}
            label1.Capture = false;
            var p = new Point(0, 0);
            Message msg = Message.Create(Handle, 0x112 /*WM_SYSCOMMAND*/, 0xF008 /*SC_SIZE + WMSZ_BOTTOMRIGHT*/, 0);
            WndProc(ref msg);
        }
    }
}