using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bachup_s_backup
{
    public partial class DI_Info : Form
    {
        public DI_Info(DesktopItem desktopItem)
        {
            InitializeComponent();
            textBox1.Text= desktopItem.FileName;
            textBox2.Text = desktopItem.FilePath;
            textBox3.Text = desktopItem.NickName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
            Form1.Form1_Instance.TopMost = true;
        }
    }
}
