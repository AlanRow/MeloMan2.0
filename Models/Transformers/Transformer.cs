using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Filters;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models.Transformers
{
    public interface ITransformer
    {
        Spectrum Transform(TransformStuff stuff, ISignal signal);
        Spectrum Transform(WindowedTransformStuff stuff, ISignal signal, IWindowFilter filter);
    }
}
