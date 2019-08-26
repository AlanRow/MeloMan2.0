using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Signals;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models.Transformers
{
    class WindowedFourierTransformer : FourierTransformer
    {
        public WindowedFourierTransformer() : base() { }

        public Spectrum Transform(WindowedTransformStuff stuff, ISignal signal)
        {
            var length = signal.GetLength();
            var winCount = (int)Math.Ceiling(((double)length) / ((double)stuff.WinStep));
            var spectrum = new Spectrum(stuff.CountFreq, winCount);

            var freqs = stuff.GetFreqs();
            var winSignal = new WinSignal(signal);

            for (var i = 0; i < winCount; i++)
            {
                var center = stuff.WinStep * i;
                winSignal.Start = (center - stuff.LeftWinSize) % length;
                winSignal.Duration = stuff.WinSize;

                spectrum.SetAtTime(i, base.Transform(stuff, winSignal).GetFreqsAtTime(0));
            }

            return spectrum;
        }
    }
}
