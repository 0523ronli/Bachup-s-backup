using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static UItestv2.Global;

namespace UItestv2
{
    public partial class Leftbtn : flatbtn
    {
        public List<Subbtn> subbtnList { get; set; }
        static int id;
        private void initialize()
        {
            BackColor = leftBackCLR;
            Dock = DockStyle.Top;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            Margin = new Padding(10);
            Size = new Size(200, 50);
            Text = "leftbutton" + id.ToString();
            TextAlign = ContentAlignment.MiddleLeft;
            Font = defaultFont;
            id++;

            expandPanel.Dock = DockStyle.Top;
            expandPanel.Margin = new Padding(10);
            expandPanel.Size = new Size(200, 0);
            expandPanel.Font = defaultFont;
            expandPanel.ForeColor = Color.Gray;
        }
        public Leftbtn()
        {
            initialize();
            //event
            Click += Leftbtnclick!;
            MouseEnter += (s, e) =>
            {
                (s as Button)!.BackColor = checkedCLR;
            };
            MouseLeave += (s, e) => {
                if (s != SettingMainForm.Instance.checkedbtn)
                {
                    if (s.GetType() == typeof(Leftbtn)) (s as Button).BackColor = leftBackCLR;
                    else (s as Button)!.BackColor = subBackCLR;
                }
            };
        }
        public static void Leftbtnclick(object sender, EventArgs e)
        {
            Leftbtn LB = (Leftbtn)sender;
            SettingMainForm.Instance.Checkedrefersh(LB);
            SettingMainForm.Instance.leftrestore();
            if (LB.Linkform != null)
            {
                SettingMainForm.Instance.centerPenal.Controls.Clear();
                if (LB.Linkform.Text != "")
                {
                    LB.Linkform.FormBorderStyle = FormBorderStyle.None;
                    LB.Linkform.Dock = DockStyle.Fill;
                    LB.Linkform.TopLevel = false;
                    SettingMainForm.Instance.centerPenal.Controls.Add(LB.Linkform);
                    LB.Linkform.Show();
                }
                else
                {
                    if (MessageBox.Show("連結的表單已遺失\n嘗試重新建立?", "錯誤", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        LB.Dispose();
                        LB.Linkform = (Form)Activator.CreateInstance(LB.Linkform.GetType());
                        LB.Linkform.FormBorderStyle = FormBorderStyle.None;
                        LB.Linkform.Dock = DockStyle.Fill;
                        LB.Linkform.TopLevel = false;
                        SettingMainForm.Instance.centerPenal.Controls.Add(LB.Linkform);
                        LB.Linkform.Show();
                    }
                }
            }
            SettingMainForm.Instance.Expand(sender as Leftbtn);
        }
        public override void repaint()
        {
            expandPanel.Controls.Clear();

            if (subbtnList != null) expandPanel.Controls.AddRange(subbtnList.Reverse<Subbtn>().ToArray<Subbtn>());

            if (this != SettingMainForm.Instance.checkedbtn)
            {
                BackColor = leftBackCLR;
            }
            else BackColor = checkedCLR;
            ForeColor = leftForeCLR;
            if (subbtnList != null) foreach (Subbtn sb in subbtnList) sb.repaint();

        }
        public override string ToString()
        {
            return "Leftbtn:" + Text;
        }
    }
}
