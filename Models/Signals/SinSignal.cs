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

        public override double GetValueAt(int i)
        {
            return (i < Options.Start || i >= Options.Start + Options.Duration) ? 0 :
                    Math.Sin((i + Options.PhaseOffset) / Options.Freq * 2 * Math.PI) * Options.Mult;
        }
    }
}
