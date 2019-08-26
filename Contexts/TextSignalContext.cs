using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Contexts
{
    public class TextSignalContext
    {
        readonly public string Name;
        readonly public string Description;

        public TextSignalContext(string name, string descr)
        {
            Name = name;
            Description = descr;
        }

        static public TextSignalContext GetDefault()
        {
            return new TextSignalContext("Сигнал", "Нет описания.");
        }
    }
}
