using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bachup_s_backup.MainDesktop;

namespace Bachup_s_backup.Setting_items
{
    public partial class Form_DI_General : Form
    {
        int current_size = (Application.OpenForms.OfType<DesktopItem>().Any(f => f.Size == new Size(200, 200))) ? 2 : ((Application.OpenForms.OfType<DesktopItem>().Any(f => f.Size == new Size(140, 140))) ? 1 : 0);

        public Form_DI_General()
        {
            InitializeComponent();
            radioButton1.Tag = Program.DI_size_opt.Small;
            radioButton2.Tag = Program.DI_size_opt.Medium;
            radioButton3.Tag = Program.DI_size_opt.Large;
        }

        private void Form_DI_Size_Load(object sender, EventArgs e)
        {

            new List<RadioButton> { radioButton1, radioButton2, radioButton3 }.ForEach(x =>
            {
                x.CheckedChanged += (s, e) =>
                {
                    Desktop_Instance.config_JSON.DI_size = (Size)x.Tag!;
                    Desktop_Instance.Refresh();
                };
                x.Checked = (Size)x.Tag == Desktop_Instance.config_JSON.DI_size;
            });
            
        }
    }
}
