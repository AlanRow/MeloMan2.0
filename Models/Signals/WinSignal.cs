using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models.Signals
{
    public class WinSignal : ISignal
    {
        private ISignal signal;
        public int Start { get; set; }
        public int Duration { get; set; }

        public WinSignal(ISignal origin)
        {
            signal = origin;
        }

        public override IEnumerable<double> GetValues()
        {
            var skipSignal = signal.GetValues().Skip(Start % signal.GetLength());

            for (var rest = Duration; rest > 0; rest--)
            {
                yield return skipSignal.First();
                skipSignal = (skipSignal.Any()) ? skipSignal.Skip(1) : signal.GetValues();
            }
            
        }
    }
}
