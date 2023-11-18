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
    public partial class Form1 : Form
    {
        List<DesktopItem> selected = new();
        Config_JSON config_JSON;
        string jsonPath;
        DragDropEffects current_effects = DragDropEffects.Copy;
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            InitHotkey();

            jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";
            if (!File.Exists(jsonPath))
            {
                config_JSON = new Config_JSON();
            }
            else
            {
                config_JSON = JsonSerializer.Deserialize<Config_JSON>(File.ReadAllText(jsonPath))!; ;
            }

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
                //TODO:chage effect
                e.Effect = current_effects;
            };
            DragDrop += (s, e) =>
            {
                if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop)!;
                    foreach (string file in files)
                    {
                        DesktopItem DI = new(file, e.Data);
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
                updateJSON();
            };
        }

        private void UnregistHotkey()
        {
            UnregisterHotKey(this.Handle, HotKeyID.Switch_Visable);
        }

        private void InitHotkey()
        {
            RegisterHotKey(this.Handle, HotKeyID.Switch_Visable, 1,(int)Keys.Space );
        }

        public void updateJSON()
        {
            string s = JsonSerializer.Serialize(config_JSON);
            File.WriteAllText(jsonPath,s);
        }

        private void Form1_Load(object sender, EventArgs e)
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
                    switch (m.WParam)
                    {
                        case HotKeyID.Switch_Visable:
                            Console.Write("Yeci is Gay");
                            Visible = !Visible;
                            break;
                    }
                    break;
                default:
                    Console.Write("Yeci is Gay");
                    base.WndProc(ref m);
                    break;

            }
        }
    }
    
}