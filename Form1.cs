using System.Windows.Forms;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.DragEnter += MyDragEnter;
            textBox1.DragDrop += textBox1_DragDrop;
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
                        MessageBox.Show("name¡G" + Path.GetFileName(file) + "\npath¡G" + file, "info");
                        DesktopItem DI = new(Path.GetFileName(file));
                        DI.Location = new Point(MousePosition.X -Location.X,MousePosition.Y-Location.Y);
                        MessageBox.Show(MousePosition.ToString());
                        //DI.Location = new Point(50, 50);
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
    }
}