using System.Runtime.InteropServices;
using static Bachup_s_backup.Program;
using System.Reflection;
using System.Text.Json;
using System.Drawing.Drawing2D;
using UItestv2;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        ContextMenuStrip RightClickMenu = new();
        
        string Icon_size="Medium icon";
        public static Form1 Instance;
        string jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";  
        public SelectedItem selected;
        public Config_JSON config_JSON = new();
        
        DragDropEffects current_effects = DragDropEffects.Copy;
        
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            selected = new(this);
            InitializeComponent();
            InitializeConfig();
            RegisterHotkey();
            InitRCM();
            
            Instance = this;
            TopMost = true;
            KeyPreview = true;

            KeyDown += onKeyDown;
            MouseDown += onMouseDown;
            DragEnter += onDragEnter;
            DragDrop += onDragDrop;
            FormClosed += onFormClosed;
        }

        private void InitRCM()
        {
            ToolStripMenuItem RCM_view = new("View");
            ToolStripMenuItem RCM_dragmode = new("Drag Mode");
            ToolStripMenuItem RCM_setting = new("Setting");
            //icon size
            List<ToolStripMenuItem> iconsize_opt = new()
            {
                new ToolStripMenuItem("Small Icon") { CheckOnClick = true },
                new ToolStripMenuItem("Medium Icon") { CheckOnClick = true },
                new ToolStripMenuItem("Large Icon") { CheckOnClick = true }
            };
            iconsize_opt.ForEach(x => x.Click += (s, e) =>
            {
                iconsize_opt.ForEach(y =>
                {
                    if (x != y) y.Checked = false;
                });
                Icon_size = x.Text;
                reArrange();
            });
            RCM_view.DropDownItems.AddRange(iconsize_opt.ToArray());
            RCM_view.DropDownItems.Add(new ToolStripSeparator());
            //auto arrange
            ToolStripMenuItem RCM_reArrange = new("Auto Arrange");
            RCM_reArrange.Click += (s, e) =>
            {
                reArrange();
            };
            RCM_view.DropDownItems.Add(RCM_reArrange);
            //dragmode
            List<ToolStripMenuItem> dragmode_opt = new()
            {
                new ToolStripMenuItem("Copy From Source") { CheckOnClick = true ,Tag=DragDropEffects.Copy},
                new ToolStripMenuItem("Move Form Source") { CheckOnClick = true ,Tag=DragDropEffects.Move}
            };
            dragmode_opt.ForEach(x =>
            {
                dragmode_opt.ForEach(y =>
                {
                    if (x != y) y.Checked = false;
                });
                current_effects = (DragDropEffects)x.Tag;
            });
            RCM_dragmode.DropDownItems.AddRange(dragmode_opt.ToArray());
            //setting
            RCM_setting.Click += (s, e) =>
            {
                if (!SettingMainForm.Instance.Visible) SettingMainForm.Instance.ShowDialog();
            };
            RightClickMenu.Items.Add(RCM_view);
            RightClickMenu.Items.Add(RCM_dragmode);
            RightClickMenu.Items.Add(RCM_setting);
        }

        private void reArrange()
        {
            //TODO reArrange
            MessageBox.Show("TO DOOOOOOOOOOOO");
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
            if (e.Button == MouseButtons.Left)
            {
                selected.Clear();
                Capture = false;
                Message msg = Message.Create(Handle, 161, 2, 0);
                WndProc(ref msg);
            }
            else
            {
                RightClickMenu.Show(this,e.Location);
            }
        }

        private void onDragEnter(object? s, DragEventArgs e)
        {
            //e.Effect = current_effects;
        }

        private void onDragDrop(object? s, DragEventArgs e)
        {
            
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
            UnregisterHotKey(Handle, HotKeys.Setting.ID);
            UnregisterHotKey(Handle, HotKeys.Close.ID);
        }

        private void RegisterHotkey()
        {
            RegisterHotKey(Handle, HotKeys.Switch_Visable.ID, 1, HotKeys.Switch_Visable.Key);
            RegisterHotKey(Handle, HotKeys.Switch_Visable.ID, 1, HotKeys.Switch_DragMode.Key);
            RegisterHotKey(Handle, HotKeys.Setting.ID, 1, HotKeys.Setting.Key);
            RegisterHotKey(Handle, HotKeys.Close.ID, 1, HotKeys.Close.Key);
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
                    if (m.WParam == HotKeys.Setting.ID)
                    {
                        if(!SettingMainForm.Instance.Visible) SettingMainForm.Instance.ShowDialog();
                    }
                    if (m.WParam == HotKeys.Close.ID)
                    {
                        Close();
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
                //TODO sync property
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