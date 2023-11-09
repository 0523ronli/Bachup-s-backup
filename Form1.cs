//using System.Windows.Forms;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        List<DesktopItem> selected = new();
        public Form1()
        {
            InitializeComponent();
            TopMost = true;
            this.MinimizeBox = false;
            textBox1.DragEnter += MyDragEnter;
            textBox1.DragDrop += textBox1_DragDrop;
            MouseDown += (s, e) =>
            {
                Capture=false;
                Message msg = Message.Create(Handle, 0xA1, 0x2, 0x0);
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
    }
}