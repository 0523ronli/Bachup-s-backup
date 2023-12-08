using System.Runtime.InteropServices;
using static Bachup_s_backup.Program;
using System.Reflection;
using System.Text.Json;
using UItestv2;

namespace Bachup_s_backup
{
    public partial class Form1 : Form
    {
        ContextMenuStrip RightClickMenu = new();

        public static Form1 Form1_Instance;
        string jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";
        public SelectedItem selected;
        public Config_JSON config_JSON = new();
        public bool autoArrange = true;
        public ArrangeMode arrangeMode = ArrangeMode.Row;
        Point Rclick_pos;

        public enum ArrangeMode
        {
            Row,
            Column,
        }

        DragDropEffects current_effects = DragDropEffects.Copy;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            selected = new(this);
            Form1_Instance = this;
            TopMost = true;
            KeyPreview = true;

            InitializeComponent();
            ReadJSON();
            RegisterHotkey();
            InitRCM();

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
            ToolStripMenuItem RCM_add_DI = new("Add And Select File");
            ToolStripMenuItem RCM_Close = new("Close Applaction");
            //icon size
            List<ToolStripMenuItem> iconsize_opt = new()
            {
                new ToolStripMenuItem("Small Icon") { CheckOnClick = true ,Tag=DI_size_opt.Small},
                new ToolStripMenuItem("Medium Icon") { CheckOnClick = true ,Tag=DI_size_opt.Medium},
                new ToolStripMenuItem("Large Icon") { CheckOnClick = true,Tag=DI_size_opt.Large }
            };
            iconsize_opt.ForEach(x =>
            {
                x.Click += (s, e) =>
                {
                    config_JSON.DI_size = (Size)x.Tag;
                    Refresh();
                };
                x.Paint += (s, e) =>
                {
                    x.Checked = (Size)x.Tag == config_JSON.DI_size;
                };
            });
            RCM_view.DropDownItems.AddRange(iconsize_opt.ToArray());
            RCM_view.DropDownItems.Add(new ToolStripSeparator());
            //auto arrange
            ToolStripMenuItem RCM_reArrange = new("Auto Arrange");
            RCM_reArrange.Click += (s, e) =>
            {
                AutoArrange();
            };
            RCM_view.DropDownItems.Add(RCM_reArrange);
            //dragmode
            List<ToolStripMenuItem> dragmode_opt = new()
            {
                new ToolStripMenuItem("Copy From Source") { CheckOnClick = true ,Tag=DragDropEffects.Copy},
                new ToolStripMenuItem("Move Form Source") { CheckOnClick = true ,Tag=DragDropEffects.Move}
            };
            dragmode_opt.Select(x =>
            {
                x.Click += (s, e) =>
                {
                    current_effects = (DragDropEffects)x.Tag;
                };
                x.Paint += (s, e) =>
                {
                    x.Checked = (DragDropEffects)x.Tag == current_effects;
                };
                return x;
            });
            List<object> lst = new();
            lst.AddRange([1, 2]);
            RCM_dragmode.DropDownItems.AddRange(
                 new List<ToolStripMenuItem>()
            {
                new ToolStripMenuItem("Copy From Source") { CheckOnClick = true ,Tag=DragDropEffects.Copy},
                new ToolStripMenuItem("Move Form Source") { CheckOnClick = true ,Tag=DragDropEffects.Move}
            }.ToArray()
                );
            //setting
            RCM_setting.Click += (s, e) =>
            {
                if (!SettingMainForm.Instance.Visible) SettingMainForm.Instance.ShowDialog();
            };
            //add_di
            RCM_add_DI.Click += (s, e) =>
            {
                OpenFileDialog OFD = new()
                {
                    Multiselect = true
                };
                if (OFD.ShowDialog() != DialogResult.OK) return;
                int i = 0;
                foreach (string file in OFD.FileNames)
                {
                    if (DesktopItem.SaveCreate(file) is DesktopItem DI)
                    {
                        Controls.Cast<DesktopItem>().Where(x => x.FilePath == file).ToList().ForEach(x =>
                        {
                            Controls.Remove(x); selected.Remove(x); x.Dispose();
                        });
                        DI.Location = new(Rclick_pos.X - DI.Width / 2 + i * (config_JSON.DI_size.Width + 10), Rclick_pos.Y - DI.Height / 2);

                        Controls.Add(DI);
                        selected.Add(DI);
                        GC.Collect();
                        i++;
                    }
                    else
                    {
                        MessageBox.Show(this, $"Can not find file at {file}");
                        continue;
                    }
                }
            };
            //close
            RCM_Close.Click += (s, e) =>
            {
                Close();
            };
            RightClickMenu.Items.Add(RCM_view);
            RightClickMenu.Items.Add(RCM_add_DI);
            RightClickMenu.Items.Add(RCM_dragmode);
            RightClickMenu.Items.Add(RCM_setting);
            RightClickMenu.Items.Add(RCM_Close);
        }

        private void AutoArrange()
        {
            int spacing = 10;
            int currentX = spacing;
            int currentY = spacing;

            foreach (var item in Controls.OfType<DesktopItem>())
            {
                item.Location = new Point(currentX, currentY);

                if (arrangeMode == ArrangeMode.Column)
                {
                    currentX += item.Width + spacing;

                    if (currentX + item.Width > ClientSize.Width)
                    {
                        currentX = spacing;
                        currentY += item.Height + spacing;
                    }
                }
                else
                {
                    currentY += item.Height + spacing;

                    if (currentY + item.Height > ClientSize.Height)
                    {
                        currentY = spacing;
                        currentX += item.Width + spacing;
                    }
                }
            }
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
                RightClickMenu.Show(this, e.Location);
                Rclick_pos = e.Location;
            }
        }

        private void onDragEnter(object? s, DragEventArgs e)
        {
            e.Effect = current_effects;
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
                        if (DesktopItem.SaveCreate(file) is DesktopItem DI)
                        {
                            Controls.Cast<DesktopItem>().Where(x => x.FilePath == file).ToList().ForEach(x =>
                            {
                                Controls.Remove(x); selected.Remove(x); x.Dispose();
                            });
                            DI.Location = new(M_Pos.X - Location.X - DI.Width / 2 + i * (config_JSON.DI_size.Width + 10), M_Pos.Y - Location.Y - DI.Height / 2);
                            Controls.Add(DI);
                            GC.Collect();
                            i++;
                        }
                        else
                        {
                            MessageBox.Show(this, $"Can not find file at {file}");
                            continue;
                        }
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
            WriteJSON();
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
                        if (!SettingMainForm.Instance.Visible)
                        {
                            SettingMainForm.Instance.ShowDialog();
                        }
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

        public void ReadJSON()
        {
            if (File.Exists(jsonPath))
            {
                config_JSON = JsonSerializer.Deserialize<Config_JSON>(File.ReadAllText(jsonPath))!;
                Location = config_JSON.location;
                Size = config_JSON.size;
                Opacity = config_JSON.Opacity;

                //TODO sync property
                var items = config_JSON.DI_List.Select(
                    x => DesktopItem.SaveCreate(x.FilePath, x.location)).Where(x => x != null).ToList();
                Controls.AddRange(items.ToArray());
            }
        }

        public void WriteJSON()
        {
            File.Create(jsonPath).Close();
            config_JSON.location = Location;
            config_JSON.size = Size;
            config_JSON.DI_List = Controls.Cast<DesktopItem>().Select(f => new DI_Json(f.Location, f.FilePath)).ToList();
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(config_JSON));
        }

        public void MakeDrag()
        {
            TopMost = false;
            var thing = selected.Select(x => x.FilePath).ToArray();
            DoDragDrop(new DataObject(DataFormats.FileDrop, selected.Select(x => x.FilePath).ToArray()), current_effects);
            TopMost = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (Control item in Controls)
            {
                item.Refresh();
            }
        }
    }
}