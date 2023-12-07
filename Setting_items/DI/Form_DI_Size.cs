using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bachup_s_backup.Setting_items
{
    public partial class Form_DI_Size : Form
    {
        int current_size = (Application.OpenForms.OfType<DesktopItem>().Any(f => f.Size == new Size(200, 200))) ? 2 : ((Application.OpenForms.OfType<DesktopItem>().Any(f => f.Size == new Size(140, 140))) ? 1 : 0);
        
        public Form_DI_Size()
        {
            InitializeComponent();
        }

        public void onSubmit(object sender, EventArgs args)
        {
            int[] sizes = [80, 140, 200];
            int size = sizes[comboBox1.SelectedIndex];
            foreach (var DI in Application.OpenForms.OfType<DesktopItem>())
            {
                DI.Size = new Size(size, size);
            }
            current_size = size;
            Form1.Instance.config_JSON.DI_size = new Size(size, size);
        }

        private void Form_DI_Size_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = current_size;
        }
    }
}
