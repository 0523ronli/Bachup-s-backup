using Bachup_s_backup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UItestv2.Global;


namespace UItestv2
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public Button checkedbtn = new();
        public bool leftfold;
        public List<Leftbtn> originalleftbtn = new();
        public void Checkedrefersh(Button button)
        {
            if (checkedbtn != null)
            {
                if (checkedbtn.GetType() == typeof(Leftbtn)) checkedbtn.BackColor = leftBackCLR;
                else checkedbtn.BackColor = subBackCLR;
            }
            checkedbtn = button;
            checkedbtn.BackColor = checkedCLR;
        }
        public void Floating(Control c)
        {
            Size s = c.Size;
            c.Dock = DockStyle.None;
            c.Size = s;
            c.BringToFront();
        }
        
        public void leftrestore()
        {
            foldablePanel.Controls.Clear();
            foreach (Leftbtn button in originalleftbtn.Reverse<Leftbtn>())
            {
                button.repaint();
                foldablePanel.Controls.Add(button);
            }

        }
        public async void Expand(Leftbtn leftbtn)
        {
            if (foldablePanel.Contains(leftbtn.expandPanel) || leftbtn.expandPanel.Controls.Count == 0) return;
            leftrestore();
            int index = foldablePanel.Controls.IndexOf(leftbtn);
            List<Control> controlList = new();
            controlList.AddRange(foldablePanel.Controls.OfType<Control>());
            controlList.Insert(index, leftbtn.expandPanel);
            foldablePanel.Controls.Clear();
            foreach (Control control in controlList)
            {
                foldablePanel.Controls.Add(control);
            }
            leftbtn.expandPanel.Size = new Size(0, 0);
            foreach (int i in Enumerable.Range(0, leftbtn.expandPanel.Controls.Count * 5 + 1))
            {
                leftbtn.expandPanel.Size = new Size(0, i * 6);
                await Task.Delay(1);
            }

        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            originalleftbtn.Add(new Leftbtn()
            {
                Text = "Gay",
                subbtnList = new List<Subbtn>
                {
                    //new Subbtn() {Text="Nano",Linkform=new Form1() }
                }
            });
            leftrestore();
        }
    }
}