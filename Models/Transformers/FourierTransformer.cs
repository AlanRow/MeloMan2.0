using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Filters;
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

        public Spectrum Transform(WindowedTransformStuff stuff, ISignal signal, IWindowFilter filter)
        {
            var times = signal.GetLength() / stuff.WinStep;
            var spec = new Spectrum(stuff.CountFreq, times, signal.GetActualLength());

            //var log = new Logger("windowed_transform.log");
            //log.WriteLog(String.Format("Times: {0}", times));
            //log.Flush();

            var c = 0;
            for (var i = 0; i < times; i++)
            {
                var tr = Transform(stuff, filter.GetFiltered(signal, c, stuff.WinSize)).GetFreqsAtTime(0);
                spec.SetAtTime(i, tr);

                c += stuff.WinStep;
            }

            return spec;
        }

        virtual public Spectrum Transform(TransformStuff stuff, ISignal signal)
        {
            var spectrum = new Spectrum(stuff.CountFreq, 1, signal.GetActualLength());
            var freqs = stuff.GetFreqs();
            
            for (var i = 0; i < freqs.Length; i++)
            {
                var fourier = calc.CalcFreq(signal, freqs[i]);
                spectrum.SetPoint(i, 0, new FreqPoint(fourier, freqs[i]));
            }

            var log = new Logger("not_windowed_transform.log");
            log.WriteLog("Hey!");
            log.Flush();

            return spectrum;
        }
    }
}
