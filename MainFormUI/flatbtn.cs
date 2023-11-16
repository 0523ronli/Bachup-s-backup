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
    public abstract class flatbtn : Button
    {
        public Form? Linkform { get; set; }
        public Panel expandPanel = new Panel();
        public Action? ToRun { get; set; }
        public abstract void repaint();
        public void OpenUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
                try { if (MessageBox.Show($"開啟以下網址:{url}", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK) Process.Start("explorer", url); } catch { MessageBox.Show("連結開啟失敗"); }
        }
    }
}
