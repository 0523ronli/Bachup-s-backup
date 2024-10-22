using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Floating_Desktop.Program;

namespace Floating_Desktop.JSON_stuff
{
    public class Config_JSON
    {
        public Point location { get; set; } = new(0, 0);
        public Size size { get; set; } = new(800, 450);
        public double Opacity { get; set; } = .700;
        public string Background { get; set; } = "Defult";
        public string Defult_Color { get; set; } = SystemColors.Control.Color2Hex();
        public string? URL { get; set; } = null;
        public DragDropEffects DragDropEffects { get; set; } = DragDropEffects.Copy;
        public HotKeys Hotkey { get; set; } = new();
        public string DI_selectedColor { get; set; } = "#ADD8E6";
        public string DI_BackColor { get; set; } = "#B4B4B4";
        public string DI_ForeColor { get; set; } = "#000000";
        public bool DI_Transparent { get; set; } = false;
        public Size DI_size { get; set; } = DI_size_opt.Medium;
        public bool double_buffer { get; set; } = true;
        public List<DI_Json> DI_List { get; set; } = new();
    }
}
