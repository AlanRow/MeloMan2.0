using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models.Signals
{
    public class FilteredSignal : ISignal
    {
        private ISignal origin;
        private Func<int, double> filter;

        public FilteredSignal(ISignal signal, Func<int, double> filterFunction)
        {
            origin = signal;
            filter = filterFunction;
        }

        public override int GetLength()
        {
            return origin.GetLength();
        }

        public override int GetActualLength()
        {
            return origin.GetActualLength();
        }

        public override double GetValueAt(int time)
        {
            return origin.GetValueAt(time) * filter(time);
        }
    }
}
