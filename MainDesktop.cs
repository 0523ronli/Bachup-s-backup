using System.Runtime.InteropServices;
using static Bachup_s_backup.Program;
using System.Reflection;
using System.Text.Json;
using UItestv2;
using System.Net;

namespace Bachup_s_backup
{
    public partial class MainDesktop : Form
    {
        ContextMenuStrip RightClickMenu = new();

        public static MainDesktop Desktop_Instance;
        string jsonPath = Assembly.GetExecutingAssembly().Location + @"/../config.json";
        public HashSet<DesktopItem> selected = new();
        public  Config_JSON config_JSON = new();  
        public bool autoArrange = true;
        public string Background = "Defult";
        public RainbowGenerator RainbowGenerator;
        public ArrangeMode arrangeMode = ArrangeMode.Row;
        public bool DI_visable = true;
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

        public MainDesktop()
        {
            Desktop_Instance = this;
            TopMost = true;
            KeyPreview = true;
            DoubleBuffered = true;
            RainbowGenerator = new(Opacity, 8f, this);

            InitializeComponent();
            ReadJSON();
            RegistHotkey();
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
            ToolStripMenuItem RCM_rename = new("Rename");
            ToolStripMenuItem RCM_setting = new("Setting");
            ToolStripMenuItem RCM_add_DI = new("Select And Add File");
            ToolStripMenuItem RCM_Close = new("Close Applaction");

            //icon size

            RCM_view.DropDownItems.AddRange(new List<ToolStripMenuItem>()
            {
                new("Small Icon") { CheckOnClick = true, Tag = DI_size_opt.Small },
                new("Medium Icon") { CheckOnClick = true, Tag = DI_size_opt.Medium },
                new("Large Icon") { CheckOnClick = true, Tag = DI_size_opt.Large }
            }.Select(x =>
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
                return x;
            }).ToArray());

            RCM_view.DropDownItems.Add(new ToolStripSeparator());

            //DI visable

            ToolStripMenuItem RCM_DI_visable = new("Item visable");
            RCM_DI_visable.Click += (s, e) =>
            {
                DI_visable = !DI_visable;
                Refresh(); //Update OnPaint()
            };
            RCM_DI_visable.Paint += (s, e) =>
            {
                RCM_DI_visable.Checked = DI_visable;
            };
            RCM_view.DropDownItems.Add(RCM_DI_visable);

            //auto arrange

            ToolStripMenuItem RCM_reArrange = new("Auto Arrange");
            RCM_reArrange.Click += (s, e) =>
            {
                AutoArrange();
            };
            RCM_view.DropDownItems.Add(RCM_reArrange);

            RCM_view.DropDownItems.Add(new ToolStripSeparator());

            //nano is gay

            RCM_view.DropDownItems.AddRange(new List<ToolStripMenuItem>()
            {
                new ("Defult") { CheckOnClick = true, Tag="Defult" },
                new ("Image") { CheckOnClick =  true, Tag="Image" },
                new ("Rainbow mode") {CheckOnClick = true, Tag = "Rainbow"},
            }.Select(x =>
            {
                x.Click += (s, e) =>
                {
                    if (Background == "Image") ChangeBackImage((string)x.Tag, true);
                    else ChangeBackImage((string)x.Tag);
                };
                x.Paint += (s, e) =>
                {
                    x.Checked = (string)x.Tag == Background;
                };
                return x;
            }).ToArray());
            
            //dragmode

            List<ToolStripMenuItem> dragmode_opt =
            [
                new ToolStripMenuItem("Copy From Source") { CheckOnClick = true ,Tag=DragDropEffects.Copy},
                new ToolStripMenuItem("Move Form Source") { CheckOnClick = true ,Tag=DragDropEffects.Move}
            ];
            dragmode_opt.ForEach(x =>
            {
                x.Click += (s, e) => current_effects = (DragDropEffects)x.Tag; ;
                x.Paint += (s, e) => x.Checked = (DragDropEffects)x.Tag == current_effects;
            });
            RCM_dragmode.DropDownItems.AddRange(dragmode_opt.ToArray());

            //setting

            RCM_setting.Click += (s, e) =>
            {
                if (!SettingMainForm.Instance.Visible) SettingMainForm.Instance.ShowDialog();
            };

            //add_di
            List<ToolStripMenuItem> add_opt =
            [
                new ToolStripMenuItem("File") { CheckOnClick = false, Tag = "File" },
                new ToolStripMenuItem("Folder") { CheckOnClick = false, Tag = "Folder" }
            ];
            add_opt.ForEach(x =>
            {
                x.Click += (s, e) =>
                {
                    if (x.Tag.ToString() == "File")
                    {
                        OpenFileDialog OFD = new() { Multiselect = true };
                        if (OFD.ShowDialog() != DialogResult.OK) return;
                        int i = 0;
                        foreach (string file in OFD.FileNames)
                        {
                            if (DesktopItem.SaveCreate(file) is DesktopItem DI)
                            {
                                Controls.Cast<DesktopItem>().Where(item => item.FilePath == file).ToList().ForEach(item =>
                                {
                                    Controls.Remove(item);
                                    selected.Remove(item);
                                    item.Dispose();
                                });
                                DI.Location = new Point(Rclick_pos.X - DI.Width / 2 + i * (config_JSON.DI_size.Width + 10), Rclick_pos.Y - DI.Height / 2);

                                Controls.Add(DI);
                                selected.Add(DI);
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
                    else if (x.Tag.ToString() == "Folder")
                    {
                        FolderBrowserDialog FBD = new();
                        if (FBD.ShowDialog() != DialogResult.OK) return;
                        string folderPath = FBD.SelectedPath;
                        DesktopItem folderItem = DesktopItem.SaveCreate(folderPath);
                        if (folderItem != null)
                        {
                            folderItem.Location = new Point(Rclick_pos.X - folderItem.Width / 2, Rclick_pos.Y - folderItem.Height / 2);

                            Controls.Add(folderItem);
                            selected.Add(folderItem);
                            GC.Collect();
                        }
                        else
                        {
                            MessageBox.Show(this, $"Cannot create DesktopItem for folder: {folderPath}");
                        }
                    }
                };
            });
            RCM_add_DI.DropDownItems.AddRange(add_opt.ToArray());

            //close
            RCM_Close.ForeColor = Color.Red;
            RCM_Close.Font = new Font(RCM_Close.Font, FontStyle.Bold);
            RCM_Close.Click += (s, e) =>
            {
                Close();
            };

            //add buttons
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

        public void ChangeBackImage(string type, bool? isCheck = null)
        {
            if (type == "Defult")
            {
                if (RainbowGenerator.IsActive) RainbowGenerator.Stop();
                config_JSON.URL = null;
                Background = type;
                BackgroundImage = null;
                BackColor = config_JSON.Defult_Color.Hex2Color();
            }
            else if (type == "Image")
            {
                if (isCheck == true && MessageBox.Show("Are you sure about it?", "Reset Image", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    config_JSON.URL = null;
                }
                if (RainbowGenerator.IsActive) RainbowGenerator.Stop();
                TopMost = false;
                string? URL = config_JSON.Background_URL;
                if (URL == null) URL = Microsoft.VisualBasic.Interaction.InputBox("Enter the image URL:", "Image URL", "");
                TopMost = true;
                if (!string.IsNullOrEmpty(URL))
                {
                    config_JSON.Background_URL = URL;
                    try
                    {
                        using (WebClient w = new())
                        {
                            using (var stream = new MemoryStream(w.DownloadData(URL)))
                            {
                                BackgroundImageLayout = ImageLayout.Stretch;
                                BackgroundImage = Image.FromStream(stream);
                            }
                        }
                        Background = type;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error loading the image: " + e.Message + "\nUsing Defult Background");
                        config_JSON.URL = null;
                        ChangeBackImage("Defult");
                    }
                }
                
            }
            else if(type == "Rainbow")
            {
                Background = type;
                BackgroundImage = null;
                RainbowGenerator.Start();
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
                if (e.Data!.GetDataPresent("DI_set"))
                {
                    foreach (DesktopItem DI in (HashSet<DesktopItem>)e.Data.GetData("DI_set")!)
                    {
                        DI.Location = new(M_Pos.X - Location.X - DI.Width / 2 + i * (config_JSON.DI_size.Width + 10), M_Pos.Y - Location.Y - DI.Height / 2);
                        i++;
                    }
                }
                else if (e.Data!.GetDataPresent(DataFormats.FileDrop))
                {
                    foreach (string file in (string[])e.Data.GetData(DataFormats.FileDrop)!)
                    {
                        Controls.Cast<DesktopItem>().Where(x => x.FilePath == file).ToList().ForEach(x =>
                        {
                            Controls.Remove(x); selected.Remove(x); x.Dispose();
                        });
                        if (DesktopItem.SaveCreate(file) is DesktopItem DI)
                        {
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
        public void UnregistHotkey()
        {
            UnregisterHotKey(Handle, config_JSON.Hotkey.Switch_Visable.ID);
            UnregisterHotKey(Handle, config_JSON.Hotkey.Switch_DragMode.ID);
            UnregisterHotKey(Handle, config_JSON.Hotkey.Setting.ID);
            UnregisterHotKey(Handle, config_JSON.Hotkey.Close.ID);
            UnregisterHotKey(Handle, config_JSON.Hotkey.Switch_DI_Visable.ID);
        }
        public void RegistHotkey()
        {
            RegisterHotKey(Handle, config_JSON.Hotkey.Switch_Visable.ID, 1, (int)config_JSON.Hotkey.Switch_Visable.Key);
            RegisterHotKey(Handle, config_JSON.Hotkey.Switch_DragMode.ID, 1, (int)config_JSON.Hotkey.Switch_DragMode.Key);
            RegisterHotKey(Handle, config_JSON.Hotkey.Delete.ID, 1, (int)config_JSON.Hotkey.Delete.Key);
            RegisterHotKey(Handle, config_JSON.Hotkey.Setting.ID, 1, (int)config_JSON.Hotkey.Setting.Key);
            RegisterHotKey(Handle, config_JSON.Hotkey.Close.ID, 1, (int)config_JSON.Hotkey.Close.Key);
            RegisterHotKey(Handle, config_JSON.Hotkey.Switch_DI_Visable.ID, 1, (int)config_JSON.Hotkey.Switch_DI_Visable.Key);
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
                    if (m.WParam == config_JSON.Hotkey.Switch_Visable.ID)
                    {
                        Visible = !Visible;
                    }
                    if (m.WParam == config_JSON.Hotkey.Delete.ID)
                    {
                        foreach (var item in selected.ToList())
                        {
                            Controls.Remove(item);
                            selected.Remove(item);
                            item.Dispose();
                        }
                        GC.Collect();
                    }
                    if (m.WParam == config_JSON.Hotkey.Setting.ID)
                    {
                        if (!SettingMainForm.Instance.Visible)
                        {
                            SettingMainForm.Instance.ShowDialog();
                        }
                    }
                    if (m.WParam == config_JSON.Hotkey.Close.ID)
                    {
                        Close();
                    }
                    if (m.WParam == config_JSON.Hotkey.Switch_DI_Visable.ID)
                    {
                        DI_visable = !DI_visable;
                        Refresh();
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
                ChangeBackImage(config_JSON.Background);
                current_effects = config_JSON.DragDropEffects;
                if (config_JSON.Background == "Rainbow") RainbowGenerator.Start();
                else RainbowGenerator.Stop();
                Controls.AddRange(config_JSON.DI_List.Select(
                    x => DesktopItem.SaveCreate(x.FilePath, x.location, x.NickName)).ToArray());
            }
        }
        public void ReadJSON(bool _)
        {
            Location = config_JSON.location;
            Size = config_JSON.size;
            Opacity = config_JSON.Opacity;
            current_effects = config_JSON.DragDropEffects;
            if (config_JSON.Background == "Rainbow") RainbowGenerator.Start();
            else RainbowGenerator.Stop();
            AutoArrange();
            Refresh();
        }

        public void WriteJSON()
        {
            File.Create(jsonPath).Close();
            config_JSON.location = Location;
            config_JSON.size = Size;
            config_JSON.Opacity = Opacity;
            config_JSON.Background = Background;
            config_JSON.DragDropEffects = current_effects;
            //config_JSON.RainbowMode = RainbowGenerator.IsActive;
            config_JSON.DI_List = Controls.Cast<DesktopItem>().Select(f => new DI_Json(f.Location, f.FilePath, f.NickName)).ToList();
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(config_JSON));
        }

        public void MakeDrag()
        {
            TopMost = false;
            DoDragDrop(new DI_Drag_Bundle(selected), current_effects);
            if (current_effects == DragDropEffects.Move)
            {
                selected.ToList().ForEach(x => x.Dispose());
                selected.Clear();
            }
            TopMost = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (DesktopItem item in Controls)
            {
                item.OnRender();
            }
            if (RainbowGenerator.IsActive)
            {

            }
            else
            {
                BackColor = config_JSON.Defult_Color.Hex2Color();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TransparencyKey = Color.Aqua;
        }
    }
}