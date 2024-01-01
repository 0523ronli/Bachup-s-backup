using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static Bachup_s_backup.MainDesktop;

namespace Bachup_s_backup
{
    public partial class Form_Temps : Form
    {
        public Form_Temps()
        {
            InitializeComponent();
            checkBox1.Checked = Desktop_Instance.config_JSON.double_buffer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Process() { StartInfo = new ProcessStartInfo() { FileName = "explorer", Arguments = $"\"{Program.TempPath}\"" } }.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Program.TempPath))
                {
                    string[] files = Directory.GetFileSystemEntries(Program.TempPath);
                    int i = 0;
                    foreach (string file in files)
                    {
                        if (Desktop_Instance.Controls.Cast<DesktopItem>().Any(x => x.FilePath == file.FullPath())) continue;
                        if (DesktopItem.SaveCreate(file) is DesktopItem DI)
                        {
                            DI.Location = new Point(DI.Width / 2 + i * (Desktop_Instance.config_JSON.DI_size.Width + 10), DI.Height / 2);
                            Desktop_Instance.Controls.Add(DI);
                            GC.Collect();
                            i++;
                        }
                        else
                        {
                            MessageBox.Show(this, $"Cannot find file at {file}");
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Desktop_Instance.config_JSON.double_buffer = checkBox1.Checked;
        }
    }
}
