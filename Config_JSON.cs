using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bachup_s_backup.Program;

namespace Bachup_s_backup
{
    public class Config_JSON
    {
        public Point location { get; set; } = new(0, 0);
        public Size size { get; set; } = new(200, 450);
        public double Opacity { get; set; } = .700;
        public HotKeys Hotkey { get; set; }
        public string DI_selectedColor { get; set; } = "#ADD8E6";
        public string DI_BackColor { get; set; } = "#B4B4B4";
        public string DI_ForeColor { get; set; } = "#000000";
        public Size DI_size { get; set; } = DI_size_opt.Medium;
        public List<DI_Json> DI_List { get; set; } = new();
    }
}
