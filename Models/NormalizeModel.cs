using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Signals;

namespace SpectrumVisor.Models
{
    public class NormalizeModel
    {
        public NormalizedSignal GetNorm(ISignal signal)
        {
            return new RelativeNormalizedSignal(signal);
        }
    }
}
