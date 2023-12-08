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
    public partial class Form_All_DI : Form
    {
        public Form_All_DI()
        {
            InitializeComponent();
            Grid1.CellEndEdit += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (Grid1.Rows[e.RowIndex].Cells[4].Value is DesktopItem src &&
                        int.TryParse(Grid1.Rows[e.RowIndex].Cells[2].Value.ToString(), out int x) &&
                        int.TryParse(Grid1.Rows[e.RowIndex].Cells[3].Value.ToString(), out int y))
                    {
                        src.Location = new(x, y);
                    }
                }
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Grid1.Rows.Clear();
            Form1.Form1_Instance.Controls.Cast<DesktopItem>().ToList().ForEach(x =>
            {
                Grid1.Rows.Add(new object[]
                {
                    x.FileName,
                    x.FilePath,
                    x.Location.X,
                    x.Location.Y,
                    x
                });
            });
            //Grid1.DataSource= Form1.Instance.Controls.Cast<DesktopItem>().ToList().Select(x =>
            //new object[]
            //    {
            //        x.FileName,
            //        x.FilePath,
            //        x.Location.X,
            //        x.Location.Y,
            //        x
            //    });
            base.OnPaint(e);
        }
    }

}
