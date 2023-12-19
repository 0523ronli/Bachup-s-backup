using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bachup_s_backup.MainDesktop;

namespace Bachup_s_backup.Setting_items.form1
{
    public partial class Form_Desktop_General : Form
    {
        double ori = MainDesktop.Desktop_Instance.Opacity;

        public Form_Desktop_General()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            double opac = (double)hScrollBar1.Value / 100;
            label1.Text = $"{opac *100}%";
            if (opac != 0.0f) Desktop_Instance.Opacity = opac;
        }

        private void Form_Desktop_General_Load(object sender, EventArgs e)
        {
            hScrollBar1.Value = (int)(ori * 100);
            label1.Text = $"{ori}%";
            label4.BackColor = Desktop_Instance.config_JSON.Defult_Color.Hex2Color();
            label4.ForeColor = label2.BackColor.GetContrastColor();
        }
            
        private void label4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.BackColor = colorDialog1.Color;
                label4.ForeColor = label2.BackColor.GetContrastColor();
                Desktop_Instance.config_JSON.Defult_Color = colorDialog1.Color.Color2Hex();
                Desktop_Instance.ChangeBackImage("Defult");
            }
        }
    }
}
