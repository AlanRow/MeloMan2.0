using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Contexts
{
    public class SignalsViewContext
    {
        readonly public SignalViewContext[] Signals;
        readonly public SignalViewContext Sum;
        readonly public SignalViewContext Filtered;

        public SignalsViewContext(SignalViewContext[] signals, SignalViewContext sum, SignalViewContext filtered)
        {
            Signals = signals;
            Sum = sum;
            Filtered = filtered;
        }
    }
}
