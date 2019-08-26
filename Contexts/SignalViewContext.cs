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
        readonly public int SignalID;
        readonly public ISignal Signal;
        readonly public Color LineColor;
        readonly public string Name;
        readonly public string Description;

        static public Color DEFAULT_COLOR = Color.Black;
        static public string DEFAULT_NAME = "no_name";

        public SignalViewContext(int id, ISignal signal, Color color, string name, string descr)
        {
            SignalID = id;
            Signal = signal;
            LineColor = color;
            Name = name;
            Description = descr;
        }

        public SignalViewContext(int id, ISignal signal, GraphicsSignalContext graph, TextSignalContext text)
        {
            SignalID = id;
            Signal = signal;
            LineColor = graph.LineColor;
            Name = text.Name;
            Description = text.Description;
        }

        public SignalViewContext(int id, ISignal signal) : this(id, signal, DEFAULT_COLOR, DEFAULT_NAME, "") { }
    }
}