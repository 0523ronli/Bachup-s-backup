using System.Windows.Forms;
using UItestv2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
            //Application.Run(new Form2Test());
            //Application.Run(new SettingMainForm());
        }
        public static string TempPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\..\local\Floating Desktop".FullPath();
        
        public class DI_size_opt
        {
            public static Size Small = new(80, 80);
            public static Size Medium = new(120,120);
            public static Size Large = new(160, 160);
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
        
    }
    public class Hotkey
    {
        public int ID { get; set; }
        public Keys Key { get; set; }
    }
    public class HotKeys
    {
        public Hotkey Switch_Visable { get; set; } = new()
        {
            ID = 1,
            Key = Keys.V
        };
        public Hotkey Switch_DragMode { get; set; }= new()
        {
            ID = 2,
            Key = Keys.E
        };
        public Hotkey Delete { get; set; }= new()
        {
            ID = 3,
            Key = Keys.Delete
        };
        public Hotkey Setting { get; set; } = new()
        {
            ID = 4,
            Key = Keys.S
        };
        public Hotkey Close { get; set; } = new()
        {
            ID = 5,
            Key = Keys.C
        };
        public Hotkey Switch_DI_Visable { get; set; } = new()
        {
            ID = 6,
            Key = Keys.F
        };
    }
    public static class ext
    {
        public static Color Hex2Coler(this string hexString) => ColorTranslator.FromHtml(hexString);
        public static string Color2Hex(this Color color) => $"#{color.R:2x}{color.G:2x}{color.B:2x}";
        public static string GetKeyName(this Keys keyCode) => Enum.GetName(typeof(Keys), keyCode)??"gay";
        public static string FullPath(this string path)=> Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    }
}