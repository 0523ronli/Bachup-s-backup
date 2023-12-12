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
            item.BackColor = ColorTranslator.FromHtml(Form1.Form1_Instance.config_JSON.DI_selectedColor);

            base.Add(item);
        }
        public new void Remove(DesktopItem item)
        {
            item.BackColor = ColorTranslator.FromHtml(Form1.Form1_Instance.config_JSON.DI_BackColor);
            base.Remove(item);
        }
        public new void Clear()
        {
            foreach (var item in this)
            {
                item.BackColor = ColorTranslator.FromHtml(Form1.Form1_Instance.config_JSON.DI_BackColor);
            }
            base.Clear();
            GC.Collect();
        }
        public void DeleteAll()
        {
            foreach(var item in this)
            {
                Form.Controls.Remove(item);
            }
            base.Clear();
            GC.Collect();
        }
    }
}
