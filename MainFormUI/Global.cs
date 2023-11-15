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
        static public Color leftBackCLR = Color.FromArgb(75, 75, 75);
        static public Color leftForeCLR = Color.FromArgb(0,0,0);
        static public Color subBackCLR = Color.FromArgb(30, 30 ,30);
        static public Color subForeCLR = Color.FromArgb(150, 150, 150);
        static public Color checkedCLR = Color.FromArgb(138, 180, 248);     
        static public Font defaultFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        static public bool BigForm=false;
        static public bool FormFixed=false;
    }
}
