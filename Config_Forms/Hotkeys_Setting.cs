using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bachup_s_backup.MainDesktop;
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
                Refresh();
            };
            groupBox1.MouseDown += (s, e) =>
            {
                capturing = false;
                Refresh();
            };
            KeyDown += (s, e) =>
            {
                if (capturing)
                {
                    captureTarget!.Key = e.KeyCode;
                    capturing = false;
                    Desktop_Instance.UnregistHotkey();
                    Desktop_Instance.RegistHotkey();
                    Refresh();
                }
            };
            
            new List<Label> { HKSetter_Visable, HKSetter_Dragmode, HKSetter_Setting, HKSetter_Close, HKSetter_DI_Visible }.ForEach(x =>
            {
                x.MouseDown += (s, e) =>
                {
                    capturing = true;
                    captureTarget = (Hotkey)x.Tag;
                    Refresh();
                    x.Text="...";
                    Focus();
                };
                x.Paint += (s, e) =>
                {
                    if(!capturing||captureTarget!=x.Tag)
                    {
                        x.Text = $"{(x.Tag as Hotkey).Key}";
                    }
                    
                };
            }
            );
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            HKSetter_Visable.Tag = Desktop_Instance.config_JSON.Hotkey.Switch_Visable;
            HKSetter_Dragmode.Tag = Desktop_Instance.config_JSON.Hotkey.Switch_DragMode;
            HKSetter_Setting.Tag = Desktop_Instance.config_JSON.Hotkey.Setting;
            HKSetter_Close.Tag = Desktop_Instance.config_JSON.Hotkey.Close;
            HKSetter_DI_Visible.Tag = Desktop_Instance.config_JSON.Hotkey.Switch_DI_Visable;
        }
    }
}
