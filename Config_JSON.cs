using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bachup_s_backup.Program;

namespace Bachup_s_backup
{
    internal class Config_JSON
    {
        public Point location { get; set; } = new Point(0, 0);
        public Size size { get; set; } = new Size(800, 450);
        public List<DI_Json> DI_list { get; set; }=new List<DI_Json>();

    }
}
