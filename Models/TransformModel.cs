using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Filters;
using SpectrumVisor.Models.Transformers;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models
{
    public class TransformModel
    {
        //возможно стоит сделать это методом и обернуть в lock
        public Spectrum Spectrum { get; private set; }
        //public WindowedTransformStuff CurrentWindowed { get; private set; }
        private WindowsSetModel windows;
        private ITransformer transformer;

        public TransformStuff Current { get; set; }
        public WindowType WindowType { get; set; }

        public TransformModel(WindowsSetModel set)
        {
            windows = set;
            Current = new TransformStuff();
            //CurrentWindowed = null;
            transformer = new FourierTransformer();
        }

        //public Spectrum Transform(WindowedTransformStuff stuff, ISignal signal, TransformType window)
        //{
        //    Spectrum = transformer.Transform(stuff, signal, windows.GetTransformer(window));
        //    return Spectrum;
        //}

        //public Spectrum Transform(WindowedTransformStuff stuff, ISignal signal)
        //{
        //    Spectrum = transformer.Transform(stuff, signal, windows.GetTransformer(CurrentWindow));
        //    return Spectrum;
        //}

        public Spectrum Transform(TransformStuff stuff, ISignal signal)
        {
            if (WindowType == WindowType.NoWin)
                Spectrum = transformer.Transform(stuff, signal);
            else if (stuff is WindowedTransformStuff)
                Spectrum = transformer.Transform((stuff as WindowedTransformStuff), signal, GetWindow());
            else
                Spectrum = transformer.Transform(new WindowedTransformStuff(stuff), signal, GetWindow());

            return Spectrum;
        }

        public Spectrum Transform(ISignal signal)
        {
            //if (CurrentWindowed != null)
            //    return Transform(CurrentWindowed, signal);
            
            return Transform(Current, signal);
        }

        public IWindowFilter GetWindow()
        {
            return windows.GetTransformer(WindowType);
        }
    }
}