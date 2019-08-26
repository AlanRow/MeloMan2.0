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

        public SpectrumViewContext(Spectrum spectrum, ISignal signal, GraphicsRoundContext grContext)
        {
            Transformed = spectrum;
            Origin = signal;
            RoundGraphics = grContext;
        }
    }
}
