using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //класс, отвечающий за динамическую генерацию сигнала
    public class SinSignal : ISignal
    {
        public readonly SignalStuff Options;

        public SinSignal(SignalStuff options)
        {
            Options = options;
        }

        override public int GetLength()
        {
            return Options.Duration;
        }

        public double GetValueAt(int i)
        {
            return (i < Options.Start || i >= Options.Start + Options.Duration) ? 0 :
                    Math.Sin((i + Options.PhaseOffset) / Options.Freq * Math.PI) * Options.Mult + Options.Const;
        }

        override public IEnumerable<double> GetValues()
        {
            for (var i = Options.Start; i < Options.Start + Options.Duration; i++)
            {
                yield return GetValueAt(i);
            }
        }
    }
}
