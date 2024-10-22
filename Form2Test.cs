using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floating_Desktop
{

    public partial class Form2Test : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASS
        {
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
        }

        // 引入 GetClassInfoEx 函數
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClassInfoEx(IntPtr hinst, string lpszClass, ref WNDCLASS lpwcx);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort RegisterClass(ref WNDCLASS wc);
        // 常數定義
        public const int GCL_STYLE = -26;


        public Form2Test()
        {
            InitializeComponent();
            MouseDown += Form2Test_MouseDown;
            DoubleClick += Form2Test_DoubleClick;
            WNDCLASS wndClass = new WNDCLASS
            {
                style = 8, // 在這裡設定窗口類別的樣式
                lpfnWndProc = IntPtr.Zero,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = IntPtr.Zero,
                hIcon = IntPtr.Zero,
                hCursor = IntPtr.Zero,
                hbrBackground = IntPtr.Zero,
                lpszMenuName = null,
                lpszClassName = "MyWindowClass"
            };

            // 註冊窗口類別
            ushort atom = RegisterClass(ref wndClass);

            if (atom == 0)
            {
                // 註冊失敗，處理錯誤
                int error = Marshal.GetLastWin32Error();
                MessageBox.Show("F");
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void Form2Test_DoubleClick(object? sender, EventArgs e)
        {
            //Capture = false;
            //Message msg = Message.Create(Handle, 163, 2, 0);
            //WndProc(ref msg);
        }

        private void Form2Test_MouseDown(object? sender, MouseEventArgs e)
        {
            //Capture = false;
            //Message msg = Message.Create(Handle, 161, 2, 0);
            //Message msg = Message.Create(Handle, 0x0203, 2, 0);
            //WndProc(ref msg);
        }

        private void Form2Test_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                        _ => 1,
                    };
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
