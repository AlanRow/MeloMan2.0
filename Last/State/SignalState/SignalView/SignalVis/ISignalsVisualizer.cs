using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    public interface ISignalsVisualizer
    {
        List<SignalViewOptions> GetViewOptions();

        void AddSignal(SinSignal signal);
    }
}
