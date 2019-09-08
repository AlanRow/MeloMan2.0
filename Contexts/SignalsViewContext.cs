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
        //readonly public SignalViewContext Norm;

        public SignalsViewContext(SignalViewContext[] signals, SignalViewContext sum)
        {
            Signals = signals;
            Sum = sum;
            //Norm = norm;
        }
    }
}
