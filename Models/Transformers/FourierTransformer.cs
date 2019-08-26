using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models.Transformers
{
    class FourierTransformer : ITransformer
    {
        private FourierCalculator calc;

        public FourierTransformer()
        {
            calc = new FourierCalculator();
        }

        virtual public Spectrum Transform(TransformStuff stuff, ISignal signal)
        {
            var spectrum = new Spectrum(stuff.CountFreq, 1);
            var freqs = stuff.GetFreqs();

            for (var i = 0; i < freqs.Length; i++)
            {
                spectrum.SetPoint(i, 0, new FreqPoint(calc.CalcFreq(signal, freqs[i]), freqs[i]));
            }

            return spectrum;
        }
    }
}
