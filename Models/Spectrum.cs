using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models
{
    public class Spectrum
    {
        public FreqPoint[][] SpectrumMatrix { get; private set; }
        private int timeFactor;

        public Spectrum(int freqs, int times, int sumTimes)
        {
            SpectrumMatrix = new FreqPoint[times][];

            for (var t = 0; t < times; t++)
                SpectrumMatrix[t] = new FreqPoint[freqs];

            timeFactor = sumTimes;
        }

        public double GetFreqDiff()
        {
            if (SpectrumMatrix.Length <= 0 || SpectrumMatrix[0].Length <= 1)
                return double.NaN;

            return SpectrumMatrix[0][1].Freq - SpectrumMatrix[0][0].Freq;
        }

        public int GetTimeSize()
        {
            return SpectrumMatrix.Length;
        }

        public int GetFreqSize()
        {
            if (SpectrumMatrix.Length == 0 || SpectrumMatrix[0].Length == 0)
                return 0;

            return SpectrumMatrix[0].Length;
        }

        public IEnumerable<double> GetFreqsValues()
        {
            if (SpectrumMatrix.Length == 0 || SpectrumMatrix[0].Length == 0)
                yield break;

            foreach (var freq in GetFreqsAtTime(0))
            {
                yield return freq.Freq;
            }
        }

        public void SetPoint(int freq, int time, FreqPoint value)
        {
            SpectrumMatrix[time][freq] = value;
        }

        public void SetAtTime(int time, FreqPoint[] range)
        {
            SpectrumMatrix[time] = range;
        }

        public FreqPoint[] GetFreqsAtTime(int time)
        {
            return SpectrumMatrix[time];
        }

        public Complex GetMassAtFreqTime(int time, int freq)
        {
            return SpectrumMatrix[time][freq].Coords / timeFactor;
        }

        public IEnumerable<double> GetDensitiesAtTime(int time)
        {
            for (var i = 0; i < GetFreqSize(); i++)
            {
                yield return (SpectrumMatrix[time][i].Coords.Magnitude * SpectrumMatrix[time][i].Coords.Magnitude) / timeFactor;
            }
        }
    }
}
