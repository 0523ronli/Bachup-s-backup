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
    public partial class Global : Form
    {
        public Global()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DI_BackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var DI in Application.OpenForms.OfType<DesktopItem>())
                {
                    DI.BackColor = colorDialog1.Color;
                }
            }
        }
    }
}
