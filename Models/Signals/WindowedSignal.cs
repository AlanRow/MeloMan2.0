using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models.Signals
{
    public class WindowedSignal : ISignal
    {
        private ISignal origin;
        private int start;
        private int length;

        public WindowedSignal(ISignal signal, int winStart, int winLength)
        {
            origin = signal;
            start = winStart;
            length = winLength;
        }

        public override int GetLength()
        {
            return origin.GetLength();
        }

        public override int GetActualLength()
        {
            return length;
        }

        public override double GetValueAt(int time)
        {
            if (time < start || time >= start + length)
                return 0;
            else if (time < origin.GetLength() && time >= 0)
                return origin.GetValueAt(time);
            else
                return (time < 0) ? -(time % length) : origin.GetLength() - 1 - (time - origin.GetLength()) % length;
        }

        //public override IEnumerable<double> GetValues()
        //{
        //    for (var i = start; i < start + length; i++)
        //    {
        //        yield return origin.GetValueAt(i);
        //    }
        //}
    }
}
