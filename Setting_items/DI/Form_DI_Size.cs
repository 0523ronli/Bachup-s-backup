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
        int current_size = (Application.OpenForms.OfType<DesktopItem>().Any(f => f.Size == new Size(200, 200))) ? 0 : ((Application.OpenForms.OfType<DesktopItem>().Any(f => f.Size == new Size(140, 140))) ? 1 : 2);
        
        public Form_DI_Size()
        {
            InitializeComponent();
        }

        public void onSubmit(object sender, EventArgs args)
        {
            int[] size = [200, 140, 100];
            foreach (var DI in Application.OpenForms.OfType<DesktopItem>())
            {
                DI.Size = new Size(size[comboBox1.SelectedIndex], size[comboBox1.SelectedIndex]);
            }
            current_size = size[comboBox1.SelectedIndex];
        }

        private void Form_DI_Size_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = current_size;
        }
    }
}
