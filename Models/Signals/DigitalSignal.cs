using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.State.Signal
{
    class DigitalSignal : ISignal
    {
        private double[] signal;

        public DigitalSignal(double[] values)
        {
            signal = values;
        }

        override public int GetLength()
        {
            return signal.Length;
        }

        override public IEnumerable<double> GetValues()
        {
            return signal;
        }

        public override double GetValueAt(int time)
        {
            return signal[time];
        }
    }
}
