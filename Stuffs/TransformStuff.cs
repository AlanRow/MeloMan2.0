using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Stuffs
{
    //служит для объединения свойств преобразования
    public class TransformStuff
    {
        public TransformType Type { get; set; }
        private double start;
        private double step;
        private int count;

        public double StartFreq
        {
            get { return start; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Start frequency must be more than 0!");
                start = value;
            }
        }

        public double StepFreq
        {
            get { return step; }
            set
            {
                if (value * count + start <= 0)
                    throw new ArgumentException("Frequency must be more than 0 everytime!");
                step = value;
            }
        }

        public int CountFreq
        {
            get { return count; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Steps count must be more than 0!");
                count = value;
            }
        }

        public double[] GetFreqs()
        {
            var freqs = new double[CountFreq];
            var freq = StartFreq;
            for (var i = 0; i < freqs.Length; i++)
            {
                freqs[i] = freq;
                freq += StepFreq;
            }

            return freqs;
        }

        public TransformStuff()
        {
            Type = TransformType.Fourier;
            start = 0.25;
            step = 0.25;
            count = 50;
        }
    }
}
