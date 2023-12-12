using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bachup_s_backup.Form1;
using static Bachup_s_backup.Program;

namespace Bachup_s_backup
{
    public partial class Hotkeys_Setting : Form
    {
        bool capturing = false;
        Hotkey captureTarget;
        public Hotkeys_Setting()
        {
            InitializeComponent();
            MouseDown += (s, e) =>
            {
                capturing = false;
            };
            KeyDown += (s, e) =>
            {
                if (capturing)
                {
                    captureTarget!.Key = e.KeyCode;
                    capturing = false;
                    Form1_Instance.UnregistHotkey();
                    Form1_Instance.RegistHotkey();
                    Refresh();
                }
            };
            HKSetter_Visable.Tag = HotKeys.Switch_Visable;
            HKSetter_Dragmode.Tag = HotKeys.Switch_DragMode;
            HKSetter_Setting.Tag = HotKeys.Setting;
            HKSetter_Close.Tag = HotKeys.Close;
            HKSetter_DI_Visible.Tag = HotKeys.Switch_DI_Visable;
            new List<Label> { HKSetter_Visable, HKSetter_Dragmode, HKSetter_Setting, HKSetter_Close, HKSetter_DI_Visible }.ForEach(x =>
            {
                x.MouseDown += (s, e) =>
                {
                    capturing = true;
                    captureTarget = (Hotkey)x.Tag;
                    Focus();
                };
                x.Paint += (s, e) =>
                {
                    x.Text = $"ALT+{(x.Tag as Hotkey).Key}";
                };
            }
            );
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
    }
}
