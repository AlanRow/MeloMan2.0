using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models
{
    public class Spectrum
    {
        private FreqPoint[][] spectrum;

        public Spectrum(int freqs, int times)
        {
            spectrum = new FreqPoint[times][];

            for (var t = 0; t < times; t++)
                spectrum[t] = new FreqPoint[freqs];
        }

        public double GetFreqDiff()
        {
            if (spectrum.Length <= 0 || spectrum[0].Length <= 1)
                return double.NaN;

            return spectrum[0][1].Freq - spectrum[0][0].Freq;
        }

        public int GetTimeSize()
        {
            return spectrum.Length;
        }

        public int GetFreqSize()
        {
            if (spectrum.Length == 0 || spectrum[0].Length == 0)
                return 0;

            return spectrum[0].Length;
        }

        public IEnumerable<double> GetFreqsValues()
        {
            if (spectrum.Length == 0 || spectrum[0].Length == 0)
                yield break;

            foreach (var freq in GetFreqsAtTime(0))
            {
                yield return freq.Freq;
            }
        }

        public void SetPoint(int freq, int time, FreqPoint value)
        {
            spectrum[time][freq] = value;
        }

        public void SetAtTime(int time, FreqPoint[] range)
        {
            spectrum[time] = range;
        }

        public FreqPoint[] GetFreqsAtTime(int time)
        {
            return spectrum[time];
        }
    }
}
