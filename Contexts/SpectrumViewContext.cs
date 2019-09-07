using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models;
using SpectrumVisor.Contexts.SpectrumGraphics;

namespace SpectrumVisor.Contexts
{
    public class SpectrumViewContext
    {
        readonly public Spectrum Transformed;
        readonly public ISignal Origin;
        readonly public GraphicsRoundContext RoundGraphics;
        readonly public GraphicsLinearContext LinearGraphics;

        public SpectrumViewContext(Spectrum spectrum, ISignal signal, GraphicsRoundContext round, GraphicsLinearContext linear)
        {
            Transformed = spectrum;
            Origin = signal;
            RoundGraphics = round;
            LinearGraphics = linear;
        }
    }
}
