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
        public List<DI_Json> DI_List { get; set; } = new();

    }
}
