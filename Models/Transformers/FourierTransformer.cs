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
                var fourier = calc.CalcFreq(signal, freqs[i]);
                spectrum.SetPoint(i, 0, new FreqPoint(fourier, freqs[i]));
                Logger.DEFLOG.WriteLog(String.Format("w: {0}; real: {1}; im: {2}; magnitude: {3}", freqs[i], fourier.Real, fourier.Imaginary, fourier.Magnitude));
            }

            Logger.DEFLOG.Flush();
            return spectrum;
        }
    }
}
