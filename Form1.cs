using System.Runtime.InteropServices;
using static Bachup_s_backup.Program;
using System.Reflection;
using System.Text.Json;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        string jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";
        public HashSet<DesktopItem> selected = new();
        public Config_JSON config_JSON = new();
        DragDropEffects current_effects = DragDropEffects.Copy;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            loadEvent();

            MouseDown += onMouseDown;
            DragEnter += onDragEnter;
            DragDrop += onDragDrop;
            FormClosed += onFormClosed;
        }

        private void loadEvent()
        {
            InitializeComponent();
            InitHotkey();
            loadJson();
        }

        private void onMouseDown(object? s, MouseEventArgs e)
        {
            Capture = false;
            Message msg = Message.Create(Handle, 161, 2, 0);
            WndProc(ref msg);
        }

        private void onDragEnter(object? s, DragEventArgs e)
        {
            e.Effect = current_effects;
        }

        private void onDragDrop(object? s, DragEventArgs e)
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
        }

        private void onFormClosed(object? s, FormClosedEventArgs e)
        {
            UnregistHotkey();
            updateJSON();
            Application.Exit();
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

        public void loadJson()
        {
            if (File.Exists(jsonPath))
            {
                config_JSON = JsonSerializer.Deserialize<Config_JSON>(File.ReadAllText(jsonPath))!;
                Location = config_JSON.location;
                Size = config_JSON.size;
                var items = config_JSON.DI_List.Select(nano => new DesktopItem (nano.FilePath)
                {
                    Location = nano.location,
                    FilePath = nano.FilePath
                }).ToList();
                selected.UnionWith(items.Cast<DesktopItem>());
            }
        }

        public void updateJSON()
        {
            File.Delete(jsonPath);
            File.Create(jsonPath).Close();
            config_JSON.size = Size;
            config_JSON.location = Location;
            config_JSON.DI_List = Controls.Cast<DesktopItem>().Select(f => new DI_Json()
            {
                location = f.Location,
                FilePath=f.FilePath
            }).ToList();
            File.WriteAllText(jsonPath, JsonSerializer.Serialize<Config_JSON>(config_JSON));
        }
    }
}