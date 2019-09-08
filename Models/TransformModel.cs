using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Filters;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models
{
    public class TransformModel
    {
        //возможно стоит сделать это методом и обернуть в lock
        public Spectrum Spectrum { get; private set; }
        public TransformStuff Current { get; private set; }
        public WindowedTransformStuff CurrentWindowed { get; private set; }
        private TransformersSetModel transformers;

        public TransformModel(TransformersSetModel set)
        {
            transformers = set;
            Current = new TransformStuff();
            CurrentWindowed = new WindowedTransformStuff();
        }

        public Spectrum Transform(WindowedTransformStuff stuff, ISignal signal, IWindowFilter window)
        {
            var log = new Logger("windowed_transform.log");
            log.WriteLog("In model!");
            log.Flush();
            Spectrum = transformers.GetTransformer(stuff.Type).Transform(stuff, signal, window);
            return Spectrum;
        }

        public Spectrum Transform(TransformStuff stuff, ISignal signal)
        {
            Spectrum = transformers.GetTransformer(stuff.Type).Transform(stuff, signal);
            return Spectrum;
        }

        public Spectrum Transform(ISignal signal)
        {
            if (CurrentWindowed != null)
                return Transform(CurrentWindowed, signal);
            
            return Transform(Current, signal);
        }
    }
}