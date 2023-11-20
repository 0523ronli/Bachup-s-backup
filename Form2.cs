using System.Windows.Forms;
using System.Windows;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Net.WebRequestMethods;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Drawing.Design;
using static Bachup_s_backup.Program;
using System.Reflection;
using File = System.IO.File;
using System.Text.Json;

namespace Bachup_s_backup
{
    public partial class Form2 : Form
    {
        public static Form2 Instance;
        public HashSet<DesktopItem> selected = new();
        Config_JSON config_JSON = new();
        string jsonPath;
        DragDropEffects current_effects = DragDropEffects.Copy;
        //[DllImport("user32.dll")]
        //public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        //[DllImport("user32.dll")]
        //public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form2()
        {
            
            Instance = this;
            InitializeComponent();
            // InitHotkey();

            jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";
            //if (File.Exists(jsonPath))
            //{
            //    try
            //    {
            //        config_JSON = JsonSerializer.Deserialize<Config_JSON>(File.ReadAllText(jsonPath))!;
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show(File.ReadAllText(jsonPath), "parse error");
            //    }
            //}
            //InitByJson();

            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;

            MouseDown += (s, e) =>
            {
                Capture = false;
                Message msg = Message.Create(Handle, 161, 2, 0);
                WndProc(ref msg);

            };
            DragEnter += (s, e) =>
            {
                //e.Effect = current_effects;
            };
            DragDrop += (s, e) =>
            {
                if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop)!;
                    foreach (string file in files)
                    {
                        DesktopItem DI = new(file);
                        DI.Location = new(MousePosition.X - Location.X - DI.Width / 2, MousePosition.Y - Location.Y - DI.Height / 2);
                        DI.Visible = true;
                        Controls.Add(DI);
                    }
                }
                else
                {
                    MessageBox.Show(e.Data.GetFormats().ToString());
                }
            };

            FormClosed += (s, e) =>
            {
                UnregistHotkey();
                UpdateJSON();
            };
        }
        public void createDrag()
        {
            DoDragDrop(new DataObject(DataFormats.FileDrop, selected.Select(x => x.FilePath)), current_effects);
        }

        private void UnregistHotkey()
        {
            //UnregisterHotKey(this.Handle, HotKeys.Switch_Visable.ID);
            //UnregisterHotKey(this.Handle, HotKeys.Switch_DragMode.ID);
        }

        private void InitHotkey()
        {
           ///RegisterHotKey(this.Handle, HotKeys.Switch_Visable.ID, 1, (int)Keys.V);
            //RegisterHotKey(this.Handle, HotKeys.Switch_DragMode.ID, 1, (int)Keys.E);
        }

        private void InitByJson()
        {
            Location = config_JSON.location;
            Size = config_JSON.size;
            Controls.AddRange(config_JSON.DI_list.Select(x => new DesktopItem(x.path!)).ToArray());
        }

        public void UpdateJSON()
        {
            string s = JsonSerializer.Serialize(config_JSON);
            File.Create(jsonPath).Dispose();
            File.WriteAllText(jsonPath, s);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    m.Result = Cursor.Position switch
                    {
                        var p when p.X < Location.X + 20 && p.Y < Location.Y + 20 => 13,
                        var p when p.X > Location.X + Width - 20 && p.Y < Location.Y + 20 => 14,
                        var p when p.X < Location.X + 20 && p.Y > Location.Y + Height - 20 => 16,
                        var p when p.X > Location.X + Width - 20 && p.Y > Location.Y + Height - 20 => 17,
                        var p when p.X < Location.X + 20 => 10,
                        var p when p.X > Location.X + Width - 20 => 11,
                        var p when p.Y < Location.Y + 20 => 12,
                        var p when p.Y > Location.Y + Height - 20 => 15,
                        _ => 2,
                    };
                    break;
                case 0x0312:
                    if (m.WParam == HotKeys.Switch_Visable.ID)
                    {
                        Visible = !Visible;
                    }
                    if (m.WParam == HotKeys.Switch_DragMode.ID)
                    {
                        current_effects = current_effects == DragDropEffects.Copy ? DragDropEffects.Move : DragDropEffects.Copy;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    break;
            }
        }

        
    }

}