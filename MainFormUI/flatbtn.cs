using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
//using static UItestv2.Global;

namespace UItestv2
{
    public abstract class Flatbtn : Button
    {
        public Form? Linkform;
        public Panel expandPanel = new();
        public Action? ToRun;
        public abstract void repaint(bool restruct=false);
        public void Flatbtnclick(object sender, EventArgs e)
        {
            SettingMainForm.Instance.checkedbtn = this;
            SettingMainForm.Instance.ReFreshColor();
            SettingMainForm.Instance.centerPenal.Controls.Clear();
            if (Linkform != null)
            {
                Linkform.FormBorderStyle = FormBorderStyle.None;
                Linkform.Dock = DockStyle.Fill;
                Linkform.TopLevel = false;
                SettingMainForm.Instance.centerPenal.Controls.Add(Linkform);
                Linkform.Show();
            }
            ToRun?.Invoke();
            if (this is Leftbtn)
            {
                SettingMainForm.Instance.ExpandAsync(this as Leftbtn);
            }
        }
    }
}
