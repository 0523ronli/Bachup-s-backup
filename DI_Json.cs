using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachup_s_backup
{
    public class DI_Json
    {
        public Point location { get; set; }
        public string FilePath { get; set; }
        public Size Size { get; set; }

        public DI_Json(Point location, string FilePath, Size size)
        {
            this.location = location;
            this.FilePath = FilePath;
            Size = size;
        }
    }
}
