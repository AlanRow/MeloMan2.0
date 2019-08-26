using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models
{
    public class TransformModel
    {
        //возможно стоит сделать это методом и обернуть в lock
        public Spectrum Spectrum { get; private set; }
        public TransformStuff Current { get; private set; }
        private TransformersSetModel transformers;

        public TransformModel(TransformersSetModel set)
        {
            transformers = set;
            Current = new TransformStuff();
        }

        public Spectrum Transform(TransformStuff stuff, ISignal signal)
        {
            Spectrum = transformers.GetTransformer(stuff.Type).Transform(stuff, signal);
            return Spectrum;
        }

        public Spectrum Transform(ISignal signal)
        {
            return Transform(Current, signal);
        }
    }
}