using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models.Filters
{
    public class NoFilter : IWindowFilter
    {
        public ISignal GetFiltered(ISignal signal)
        {
            return signal;
        }

        public ISignal GetFiltered(ISignal signal, int center, int winSize)
        {
            return signal;
        }

        public void SetWinCenter(int center)
        {
        }

        public void SetWinSize(int size)
        {
        }
    }
}
