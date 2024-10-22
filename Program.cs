using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Windows.Forms;
using UItestv2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Floating_Desktop
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
            Application.Run(new MainDesktop());
            //Application.Run(new Form2Test());
        }
        public static string TempPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\..\local\Floating Desktop".FullPath();

        public static Image GIFToImage(string gifFilePath)
        {
            Image gifImage = Image.FromFile(gifFilePath);
            FrameDimension dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            int frameCount = gifImage.GetFrameCount(dimension);
            Image firstFrame = null;
            if (frameCount > 0)
            {
                gifImage.SelectActiveFrame(dimension, 0);
                firstFrame = (Image)gifImage.Clone();
            }
            gifImage.Dispose();
            return firstFrame;
        }

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
        public Hotkey Switch_Full_Screen { get; set; } = new()
        {
            ID = 7,
            Key = Keys.F11
        };
    }
    public static class ext
    {
        public static Color Hex2Color(this string hexString) => ColorTranslator.FromHtml(hexString);
        public static string Color2Hex(this Color color) => $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        public static string GetKeyName(this Keys keyCode) => Enum.GetName(typeof(Keys), keyCode)??"gay";
        public static string FullPath(this string path)=> Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        public static Color GetContrastColor(this Color backgroundColor) => ((0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255) > 0.5 ? Color.Black : Color.White;
    }

    public class RainbowGenerator
    {
        double opacity; float speed; Form form;
        public RainbowGenerator(double opacity, float speed, Form form)
        {
            this.opacity = opacity;
            this.speed = speed;
            this.form = form;
            timer.Tick += (s, e) => form.BackColor = GetRainbowColor(opacity, speed);
        }
        System.Windows.Forms.Timer timer = new()
        {
            Interval = 1,
        };
        public void Start()=>timer.Start();
        public void Stop() => timer.Stop();
        public bool IsActive => timer.Enabled;

        public static Color GetRainbowColor(double opacity, float delay)
        {
            int currentMillis = Environment.TickCount;
            double rainbowState = Math.Ceiling((currentMillis + delay) / 20.0);
            rainbowState %= 360.0f;
            Color color = HSBtoRGB((float)(rainbowState / 360.0f), .6f, (float)opacity);
            return color;
        }
        public static Color HSBtoRGB(float hue, float saturation, float brightness)
        {
            int r = 0, g = 0, b = 0;
            if (saturation == 0)
            {
                r = g = b = (int)(brightness * 255.0f + 0.5f);
            }
            else
            {
                float h = (hue - (float)Math.Floor(hue)) * 6.0f;
                float f = h - (float)Math.Floor(h);
                float p = brightness * (1.0f - saturation);
                float q = brightness * (1.0f - saturation * f);
                float t = brightness * (1.0f - (saturation * (1.0f - f)));
                switch ((int)h)
                {
                    case 0:
                        r = (int)(brightness * 255.0f + 0.5f);
                        g = (int)(t * 255.0f + 0.5f);
                        b = (int)(p * 255.0f + 0.5f);
                        break;
                    case 1:
                        r = (int)(q * 255.0f + 0.5f);
                        g = (int)(brightness * 255.0f + 0.5f);
                        b = (int)(p * 255.0f + 0.5f);
                        break;
                    case 2:
                        r = (int)(p * 255.0f + 0.5f);
                        g = (int)(brightness * 255.0f + 0.5f);
                        b = (int)(t * 255.0f + 0.5f);
                        break;
                    case 3:
                        r = (int)(p * 255.0f + 0.5f);
                        g = (int)(q * 255.0f + 0.5f);
                        b = (int)(brightness * 255.0f + 0.5f);
                        break;
                    case 4:
                        r = (int)(t * 255.0f + 0.5f);
                        g = (int)(p * 255.0f + 0.5f);
                        b = (int)(brightness * 255.0f + 0.5f);
                        break;
                    case 5:
                        r = (int)(brightness * 255.0f + 0.5f);
                        g = (int)(p * 255.0f + 0.5f);
                        b = (int)(q * 255.0f + 0.5f);
                        break;
                }
            }
            return Color.FromArgb(r, g, b);
        }
    }
}