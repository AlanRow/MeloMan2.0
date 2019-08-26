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

        override public IEnumerable<double> GetValues()
        {
            for (var i = 0; i < manager.Size; i++)
            {
                var d = 0d;
                foreach (var signal in manager.Signals)
                    d += signal.GetValueAt(i);

                yield return d;
            }
        }
    }
}
