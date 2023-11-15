using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UItestv2.Global;
using static UItestv2.MainForm;

namespace UItestv2
{
    public partial class setting : Form
    {
        bool keepdiaplay = true; 
        public setting()
        {
            InitializeComponent();
            TopLevel = false;
            Visible = true;
            Dock = DockStyle.Fill;
        }

        private void objectselector_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void changeCLRbrn_Click(object sender, EventArgs e)
        {
            int r=0, g=0, b=0;
            void changeColor(ref Color c)
            {
                try
                {
                    c = Color.FromArgb(r, g, b);
                    if (keepdiaplay) if(MessageBox.Show("更變成功\n不再顯示此提示?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)keepdiaplay=false;
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("數字轉換為顏色時發生錯誤");
                }
            }
            try
            {
                string[] s = CLRinput.Text.Split(new char[] { ',', ' ' },3, StringSplitOptions.RemoveEmptyEntries);
                r=int.Parse(s[0]);
                g=int.Parse(s[1]);
                b=int.Parse(s[2]);
            }
            catch (Exception)
            {
                MessageBox.Show("輸入格式錯誤(r,g,b)");
            }
            switch (objectselector.SelectedIndex)
            {
                case 0:
                    changeColor(ref leftBackCLR);
                    break;
                case 1:
                    changeColor(ref leftForeCLR);
                    break;
                case 2:
                    changeColor(ref subBackCLR);
                    break;
                case 3:
                    changeColor(ref subForeCLR);
                    break;
                case 4:
                    changeColor(ref checkedCLR);
                    break;
                default:
                    MessageBox.Show("未選擇更變的對象");
                    break;
            }
            Instance.leftrestore();
            foreach(Leftbtn btn in Instance.foldablePanel.Controls)btn.repaint();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Join("\n\n",Instance.foldablePanel.Controls.Cast<Control>().ToList()));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BigForm = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            FormFixed = checkBox2.Checked;
        }

        private void setting_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }
    }
}
