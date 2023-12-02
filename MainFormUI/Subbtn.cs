using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UItestv2.UIv2Global;

namespace UItestv2
{
    public partial class Subbtn : Flatbtn
    {
        private void initialize()
        {
            
            Dock = DockStyle.Top;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Margin = new Padding(10);
            Size = new Size(200, 30);
            Text = "Subbutton";
            TextAlign = ContentAlignment.MiddleLeft;
            Font = defaultFont;
            ForeColor = Color.Gray;
        }
        public Subbtn()
        {
            initialize();
            BackColor = subBackColor;
            
            //event
            Click += Flatbtnclick!;
            MouseEnter += (s, e) =>
            {
                BackColor = checkedColor;
            };
            MouseLeave += (s, e) => {
                if (this != SettingMainForm.Instance.checkedbtn)
                {
                    BackColor = subBackColor;
                }
            };
        }
        public override void repaint(bool _=false)
        {
            BackColor = this == SettingMainForm.Instance.checkedbtn ? checkedColor : subBackColor;
            ForeColor = subForeColor;
        }
    }
}
