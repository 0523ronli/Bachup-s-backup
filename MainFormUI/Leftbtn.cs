using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static UItestv2.Global;
using static UItestv2.MainForm;

namespace UItestv2
{
    public partial class Leftbtn : flatbtn
    {
        public List<Subbtn> subbtnList { get; set; }
        static int id;
        private void initialize()
        {
            BackColor = leftBackCLR;
            Dock = System.Windows.Forms.DockStyle.Top;
            FlatAppearance.BorderSize = 0;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Margin = new System.Windows.Forms.Padding(10);
            Size = new System.Drawing.Size(200, 50);
            Text = "leftbutton" + id.ToString();
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Font = Global.defaultFont;
            id++;

            expandPanel.Dock = System.Windows.Forms.DockStyle.Top;
            expandPanel.Margin = new System.Windows.Forms.Padding(10);
            expandPanel.Size = new System.Drawing.Size(200, 0);
            expandPanel.Font = Global.defaultFont;
            expandPanel.ForeColor = System.Drawing.Color.Gray;
        }
        public Leftbtn()
        {
            initialize();
            //event
            Click += new System.EventHandler(Leftbtnclick);
            MouseEnter += (s, e) =>
            {
                ((Button)s).BackColor = checkedCLR;
            };
            MouseLeave += (s, e) => {
                if (s != Instance.checkedbtn)
                {
                    if (s.GetType() == typeof(Leftbtn)) (s as Button).BackColor = leftBackCLR;
                    else (s as Button).BackColor = subBackCLR;
                }
            };
        }
        public static void Leftbtnclick(object sender, EventArgs e)
        {
            Leftbtn LB = (Leftbtn)sender;
            Instance.Checkedrefersh(LB);
            Instance.leftrestore();
            if (LB.Linkform != null)
            {
                Instance.centerPenal.Controls.Clear();
                if (LB.Linkform.Text != "")
                {
                    if (FormFixed) LB.Linkform.FormBorderStyle = FormBorderStyle.None;
                    if (BigForm) LB.Linkform.Dock = DockStyle.Fill;
                    LB.Linkform.TopLevel = false;
                    Instance.centerPenal.Controls.Add(LB.Linkform);
                    LB.Linkform.Show();
                }
                else
                {

                    if (MessageBox.Show("連結的表單已遺失\n嘗試重新建立?", "錯誤", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        LB.Dispose();
                        LB.Linkform = (Form)Activator.CreateInstance(LB.Linkform.GetType());
                        if (FormFixed) LB.Linkform.FormBorderStyle = FormBorderStyle.None;
                        if (BigForm) LB.Linkform.Dock = DockStyle.Fill;
                        LB.Linkform.TopLevel = false;
                        Instance.centerPenal.Controls.Add(LB.Linkform);
                        LB.Linkform.Show();
                    }
                }
            }
            Instance.Expand(sender as Leftbtn);
        }
        public override void repaint()
        {
            expandPanel.Controls.Clear();

            if (subbtnList != null) expandPanel.Controls.AddRange(subbtnList.Reverse<Subbtn>().ToArray<Subbtn>());

            if (this != Instance.checkedbtn)
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
