using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Contexts
{
    public class SignalViewContext
    {
        readonly public ISignal Signal;
        readonly public Color LineColor;
        readonly public string Name;
        readonly public string Description;

        static public Color DEFAULT_COLOR = Color.Black;
        static public string DEFAULT_NAME = "no_name";

        public SignalViewContext(ISignal signal, Color color, string name, string descr)
        {
            Signal = signal;
            LineColor = color;
            Name = name;
            Description = descr;
        }

        public SignalViewContext(ISignal signal) : this(signal, DEFAULT_COLOR, DEFAULT_NAME, "") { }
    }
}