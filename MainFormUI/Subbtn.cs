using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UItestv2.Global;
using static UItestv2.MainForm;

namespace UItestv2
{
    public partial class Subbtn : flatbtn
    {
        static int ID;
        private void initialize()
        {
            Dock = System.Windows.Forms.DockStyle.Top;
            FlatAppearance.BorderSize = 0;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Margin = new System.Windows.Forms.Padding(10);
            Size = new System.Drawing.Size(200, 30);
            Text = "subbutton"+ID.ToString();
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Font = Global.defaultFont;
            ForeColor = System.Drawing.Color.Gray;
        }
        public Subbtn()
        {
            initialize();
            BackColor = subBackCLR;
            ID++;
            
            //event
            Click += new System.EventHandler(Subbtnclick);
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
        public void Subbtnclick(object sender, EventArgs e)
        {
            Subbtn subbutton = (Subbtn)sender;
            Instance.centerPenal.Controls.Clear();
            if (subbutton.Linkform != null)
            {
                if (subbutton.Linkform.Text != "")
                {
                    if (FormFixed) subbutton.Linkform.FormBorderStyle = FormBorderStyle.None;
                    if (BigForm) subbutton.Linkform.Dock = DockStyle.Fill;
                    subbutton.Linkform.TopLevel = false;
                    Instance.centerPenal.Controls.Add(subbutton.Linkform);
                    subbutton.Linkform.Show();
                }
                else
                {
                    if (MessageBox.Show("連結的表單已遺失\n嘗試重新建立?", "錯誤", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        subbutton.Linkform.Dispose();
                        subbutton.Linkform = (Form)Activator.CreateInstance(subbutton.Linkform.GetType());
                        if (FormFixed) subbutton.Linkform.FormBorderStyle = FormBorderStyle.None;
                        if (BigForm) subbutton.Linkform.Dock = DockStyle.Fill;
                        subbutton.Linkform.TopLevel = false;
                        Instance.centerPenal.Controls.Add(subbutton.Linkform);
                        subbutton.Linkform.Show();
                    }
                }
            }
            if(ToRun is not null)
            {
                ToRun();
            }
        }
        public override void repaint()
        {
            if (this != Instance.checkedbtn as Subbtn)
            {
                BackColor = subBackCLR;
            }
            else BackColor = checkedCLR;
            ForeColor = subForeCLR;
            Text = Linkform?.Text ?? Text;
        }
    }
}
