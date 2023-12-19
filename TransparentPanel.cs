using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bachup_s_backup
{
    internal class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.Empty;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0b00100000; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
    }
}
