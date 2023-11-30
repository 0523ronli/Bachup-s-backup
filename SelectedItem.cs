using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachup_s_backup
{
    public class SelectedItem:HashSet<DesktopItem>
    {
        private Form1 Form;

        public SelectedItem(Form1 Form)
        {
            this.Form = Form;
        }

        public new void Add(DesktopItem item)
        {
            item.BackColor = Program.DI_selected;

            base.Add(item);
        }
        public new void Remove(DesktopItem item)
        {
            item.BackColor=Program.DI_default;
            base.Remove(item);
        }
        public new void Clear()
        {
            foreach (var item in this)
            {
                item.BackColor = Program.DI_default;
            }
            base.Clear();
        }
        public void DeleteAll()
        {
            foreach(var item in this)
            {
                Form.Controls.Remove(item);
            }
            base.Clear();
        }
    }
}
