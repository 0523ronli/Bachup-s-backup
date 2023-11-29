using System.Runtime.InteropServices;
using static Bachup_s_backup.Program;
using System.Reflection;
using System.Text.Json;
using System.Drawing.Drawing2D;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        string jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";
        public SelectedItem selected = new(Instance);
        public Config_JSON config_JSON = new();
        DragDropEffects current_effects = DragDropEffects.Copy;
        
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            InitializeConfig();
            RegisterHotkey();
            
            Instance = this;
            TopMost = true;
            KeyPreview = true;

            KeyDown += onKeyDown;
            MouseDown += onMouseDown;
            DragEnter += onDragEnter;
            DragDrop += onDragDrop;
            FormClosed += onFormClosed;
        }


        private void onKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (var item in selected.ToList())
                {
                    Controls.Remove(item);
                    selected.Remove(item);
                    item.Dispose();
                }
                GC.Collect();
            }
        }

        private void onMouseDown(object? s, MouseEventArgs e)
        {
            selected.Clear();
            Capture = false;
            //Message msg = Message.Create(Handle, 161, Message.Create(Handle, 0x84, 2, 0).Result, 0);
            Message msg = Message.Create(Handle, 161, 2, 0);
            WndProc(ref msg);
        }

        private void onDragEnter(object? s, DragEventArgs e)
        {
            e.Effect = current_effects;
        }

        private void onDragDrop(object? s, DragEventArgs e)
        {
            //TopMost = false;
            //SendToBack();
            
            try
            {
                int i = 0;
                Point M_Pos = MousePosition;
                if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                {
                    foreach (string file in (string[])e.Data.GetData(DataFormats.FileDrop)!)
                    {
                        DesktopItem DI = DesktopItem.SaveCreate(file);
                        if (DI == null)
                        {
                            MessageBox.Show(this, $"can not find file at {file}");
                            continue;
                        }
                        Controls.Cast<DesktopItem>().Where(x => x.FilePath == file).ToList().ForEach(x =>
                        {
                            Controls.Remove(x); selected.Remove(x);x.Dispose();
                        });
                        DI.Location = new(M_Pos.X - Location.X - DI.Width / 2+i*(DI_size.Width+10), M_Pos.Y - Location.Y - DI.Height / 2);
                        Controls.Add(DI);
                        GC.Collect();
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show(this, e.Data.GetFormats().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messed up when dropping");
            }
            //TopMost = true;
        }

        private void onFormClosed(object? s, FormClosedEventArgs e)
        {
            UnregistHotkey();
            updateJSON();
            Application.Exit();
        }
        private void UnregistHotkey()
        {
            UnregisterHotKey(Handle, HotKeys.Switch_Visable.ID);
            UnregisterHotKey(Handle, HotKeys.Switch_DragMode.ID);
        }

        private void RegisterHotkey()
        {
            RegisterHotKey(Handle, HotKeys.Switch_Visable.ID, 1, HotKeys.Switch_Visable.Key);
            RegisterHotKey(Handle, HotKeys.Switch_Visable.ID, 1, HotKeys.Switch_DragMode.Key);
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
                        _ => 1,
                    };
                    break;
                case 0x0312:
                    if (m.WParam == HotKeys.Switch_Visable.ID)
                    {
                        Visible = !Visible;
                    }
                    if (m.WParam == HotKeys.Delete.ID)
                    {
                        foreach (var item in selected.ToList())
                        {
                            Controls.Remove(item);
                            selected.Remove(item);
                            item.Dispose();
                        }
                        GC.Collect();
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public void InitializeConfig()
        {
            if (File.Exists(jsonPath))
            {
                config_JSON = JsonSerializer.Deserialize<Config_JSON>(File.ReadAllText(jsonPath))!;
                Location = config_JSON.location;
                Size = config_JSON.size;
                var items = config_JSON.DI_List.Select(
                    x => DesktopItem.SaveCreate(x.FilePath, x.location)).Where(x => x != null).ToList();
                Controls.AddRange(items.ToArray());
            }
        }

        public void updateJSON()
        {
            File.Create(jsonPath).Close();
            config_JSON.size = Size;
            config_JSON.location = Location;
            config_JSON.DI_List = Controls.Cast<DesktopItem>().Select(f => new DI_Json(f.Location, f.FilePath)).ToList();
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(config_JSON));
        }

        public void MakeDrag()
        {
            var thing = selected.Select(x => x.FilePath).ToArray();
            DoDragDrop(new DataObject(DataFormats.FileDrop, selected.Select(x => x.FilePath).ToArray()), current_effects);
        }
    }
}