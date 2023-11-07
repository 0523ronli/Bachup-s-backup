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
    public partial class DesktopItem : Form
    {
        public DesktopItem(string s)
        {
            InitializeComponent();
            TopLevel = false;
            label1.Text = s;
        }
    }
}
