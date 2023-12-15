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
        public string NickName { get; set; }

        public DI_Json(Point location, string FilePath, string NickName)
        {
            this.location = location;
            this.FilePath = FilePath;
            this.NickName = NickName;
        }
    }
}
