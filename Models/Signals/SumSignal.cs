using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //возвращает сумму сигналов менеджера
    public class SumSignal : ISignal
    {
        private readonly SignalsModel manager;

        public SumSignal(SignalsModel main)
        {
            manager = main;
        }

        override public int GetLength()
        {
            return manager.Size;
        }

        public override double GetValueAt(int time)
        {
            var d = 0d;
            foreach (var signal in manager.Signals)
                d += signal.GetValueAt(time);

            return d;
        }
    }
}
