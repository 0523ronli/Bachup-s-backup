using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bachup_s_backup.MainFormUI
{
    public partial class Form_All_DI : Form
    {
        public Form_All_DI()
        {
            InitializeComponent();
            dataGridView1.CellEndEdit += (s, e) =>
            {
                MessageBox.Show("Test");
            };
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            dataGridView1.Rows.Clear();
            Form1.Instance.Controls.Cast<DesktopItem>().ToList().ForEach(x =>
            {
                dataGridView1.Rows.Add(new object[]
                {
                    x.FileName,
                    x.FilePath,
                    x.Location.X,
                    x.Location.Y,
                    x
                });
            });

            base.OnPaint(e);
        }
    }

}
