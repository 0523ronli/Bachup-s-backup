using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UItestv2
{
    public static class Global
    {
        public static Color leftBackCLR = Color.FromArgb(75, 75, 75);
        public static Color leftForeCLR = Color.FromArgb(0, 0, 0);
        public static Color subBackCLR = Color.FromArgb(30, 30, 30);
        public static Color subForeCLR = Color.FromArgb(150, 150, 150);
        public static Color checkedCLR = Color.FromArgb(138, 180, 248);
        public static Font defaultFont = new ("微軟正黑體", 12F, FontStyle.Bold, GraphicsUnit.Point);
    }
}
