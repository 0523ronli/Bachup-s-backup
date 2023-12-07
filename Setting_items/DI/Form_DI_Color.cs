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
    public partial class Form_DI_Color : Form
    {
        public Form_DI_Color()
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

        private void DI_BackColor_onDoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var DI in Application.OpenForms.OfType<DesktopItem>())
                {
                    DI.BackColor = colorDialog1.Color;
                }
                Form1.Instance.config_JSON.DI_BackColor = ColorToHex(colorDialog1.Color);
            }
        }

        private void DI_ForeColor_onDoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var DI in Application.OpenForms.OfType<DesktopItem>())
                {
                    DI.ForeColor = colorDialog1.Color;
                }
                Form1.Instance.config_JSON.DI_ForeColor = ColorToHex(colorDialog1.Color);
            }
        }

        private string ColorToHex(Color c)
        {
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
        }
    }
}
