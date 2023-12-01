using UItestv2;

namespace Bachup_s_backup
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            SettingMainForm _ = new();
            Application.Run(new Form1());
            //Application.Run(new SettingMainForm());
            //Application.Run(new Form2Test());
        }
        public static class HotKeys
        {
            public static Hotkey Switch_Visable = new()
            {
                ID = 1,
                Key = (int)Keys.V
            };
            public static Hotkey Switch_DragMode = new()
            {
                ID = 2,
                Key = (int)Keys.E
            };
            public static Hotkey Delete = new()
            {
                ID = 3,
                Key = (int)Keys.Delete
            };
            public static Hotkey Setting = new()
            {
                ID = 4,
                Key = (int)Keys.S
            };
            public static Hotkey Close = new()
            {
                ID = 5,
                Key = (int)Keys.C
            };
        }
        public struct Hotkey
        {
            public int ID;
            public int Key;
        }
        private static void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Something not expected went wrong: \n " + e.Exception.Message, "O_o", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MessageForm(string s, Control? parent = null)
        {
            Form F = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                Visible = true,
                StartPosition = FormStartPosition.Manual
            };
            F.Controls.Add(new Label() { Location = new(0, 0), Text = s });
            //new Task(async () => { await Task.Delay(1000); F.Close(); }).Start();

            System.Windows.Forms.Timer T = new()
            {
                Interval = 1000,
            };
            T.Tick += (s, e) => F.Close();
            T.Start();

            F.AutoSize = true;
            F.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            F.MouseClick += (s, e) => F.Close();
            Rectangle workingArea = Screen.GetWorkingArea(F);
            F.Location = new Point(workingArea.Right - F.Size.Width,
                                      workingArea.Bottom - F.Size.Height);
        }
        public static Color DI_default = SystemColors.ActiveBorder;
        public static Color DI_selected = Color.LightBlue;
        public static Color DI_backColor = SystemColors.ActiveBorder;
        public static Size DI_size = new Size(140, 140);
        public static double DI_opacity = .100;
    }
}