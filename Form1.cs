using System.Runtime.InteropServices;
using static Bachup_s_backup.Program;
using System.Reflection;
using System.Text.Json;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        string jsonPath;
        public Config_JSON config_JSON = new Config_JSON();
        public HashSet<DesktopItem> selected = new();
        DragDropEffects current_effects = DragDropEffects.Copy;
        bool shift_pressed = false;
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            InitHotkey();

            jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";
            if (File.Exists(jsonPath))
            {
                config_JSON = JsonSerializer.Deserialize<Config_JSON>(File.ReadAllText(jsonPath))!; ;
            }
            
            Instance = this;

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
                e.Effect = current_effects;
            };
            DragDrop += (s, e) =>
            {
                if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                {
                    var thing = e.Data.GetData(DataFormats.FileDrop);
                    if (thing == null)
                    {
                        MessageBox.Show("drop null");
                        return;
                    }
                    string[] files = (string[])thing;
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
            //KeyDown += (s, e) =>
            //{
            //    if(e.KeyCode==Keys.Shift)shift_pressed = true;
            //};
            //KeyUp += (s, e) =>
            //{
            //    if (e.KeyCode == Keys.Shift) shift_pressed = false;
            //};

            FormClosed += (s, e) =>
            {
                UnregistHotkey();
                updateJSON();
                Application.Exit();
            };
        }

        public void createDrag()
        {
            DoDragDrop(new DataObject(DataFormats.FileDrop, selected.Select(x => x.FilePath)), current_effects);
        }

        private void UnregistHotkey()
        {
            UnregisterHotKey(this.Handle, HotKeys.Switch_Visable.ID);
            UnregisterHotKey(this.Handle, HotKeys.Switch_DragMode.ID);
        }

        private void InitHotkey()
        {
            RegisterHotKey(this.Handle, HotKeys.Switch_Visable.ID, 1, HotKeys.Switch_Visable.Key);
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
                    if (m.WParam == HotKeys.Switch_Visable.ID)
                    {
                        Visible = !Visible;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        public void updateJSON()
        {
            if (!File.Exists(jsonPath))
            {
                File.Create(jsonPath);
            }
            config_JSON.size = Size;
            config_JSON.location = Location;
            config_JSON.DI_List = Controls.Cast<DesktopItem>().Select(f => new DI_Json()
            {
                location = f.Location,
                FilePath=f.FilePath
            }).ToList();
            string s = JsonSerializer.Serialize<Config_JSON>(config_JSON);
            File.WriteAllText(jsonPath, s);
        }
    }
}