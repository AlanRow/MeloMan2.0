using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models.Filters
{
    public interface IWindowFilter
    {
        ISignal GetFiltered(ISignal signal, int center, int winSize);
        ISignal GetFiltered(ISignal signal);
        void SetWinSize(int size);
        void SetWinCenter(int center);
    }
}
