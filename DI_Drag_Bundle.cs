using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachup_s_backup
{
    internal class DI_Drag_Bundle : IDataObject
    {
        HashSet<DesktopItem> DI_content;

        public DI_Drag_Bundle(HashSet<DesktopItem> dI_content) => DI_content = dI_content;

        object? IDataObject.GetData(string format, bool autoConvert)
        {
            if (format == DataFormats.FileDrop)
            {
                return DI_content.Select(x => x.FilePath).ToArray();
            }
            else if (format == "DI_set")
            {
                return DI_content;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        object? IDataObject.GetData(string format)
        {
            if (format == DataFormats.FileDrop)
            {
                return DI_content.Select(x => x.FilePath).ToArray();
            }
            else if (format == "DI_set")
            {
                return DI_content;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        object? IDataObject.GetData(Type format)
        {
            throw new NotImplementedException();
        }

        bool IDataObject.GetDataPresent(string format, bool autoConvert)
        {
            return format == DataFormats.FileDrop || format == "DI_set";
        }

        bool IDataObject.GetDataPresent(string format)
        {
            return format == DataFormats.FileDrop || format == "DI_set";
        }

        bool IDataObject.GetDataPresent(Type format)
        {
            return false;
        }

        string[] IDataObject.GetFormats()
        {
            return [DataFormats.FileDrop];
        }
        string[] IDataObject.GetFormats(bool autoConvert)
        {
            return [DataFormats.FileDrop];
        }

        void IDataObject.SetData(string format, bool autoConvert, object? data)
        {
            throw new NotImplementedException();
        }

        void IDataObject.SetData(string format, object? data)
        {
            throw new NotImplementedException();
        }

        void IDataObject.SetData(Type format, object? data)
        {
            throw new NotImplementedException();
        }

        void IDataObject.SetData(object? data)
        {
            throw new NotImplementedException();
        }
    }
}
