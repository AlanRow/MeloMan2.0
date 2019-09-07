using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Contexts.SpectrumGraphics;

namespace SpectrumVisor.Models
{
    public class GraphicsContextModel
    {
        private Dictionary<ISignal, GraphicsSignalContext> contexts;

        public GraphicsRoundContext RoundView { get; private set; }
        public GraphicsLinearContext LinearView { get; private set; }

        public GraphicsContextModel()
        {
            contexts = new Dictionary<ISignal, GraphicsSignalContext>();

            RoundView = new GraphicsRoundContext();
            LinearView = new GraphicsLinearContext();
        }

        public void SetContext(ISignal signal, GraphicsSignalContext context)
        {
            contexts[signal] = context;
        }

        public GraphicsSignalContext GetContext(ISignal signal)
        {
            if (contexts.ContainsKey(signal))
                return contexts[signal];

            return GraphicsSignalContext.GetDefault();
        }
    }
}
