using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //позволяет при изменениях в сигнале асинхронно вычислить и закэшировать преобразование
    class CachTransformer : ITransformer
    {
        private ISpecGenerator generator;
        private FreqPoint[][] spectrum;

        public delegate void Changed();
        public event Changed TransformChanged;

        public CachTransformer(ISpecGenerator gener, SignallController controller)
        {
            spectrum = new FreqPoint[0][];
            generator = gener;
            CalcSpectrum();

            controller.SignChanged += () =>
            {
                CalcSpectrum();
            };

            TransformChanged = () => { };
        }

        public IEnumerable<double> GetFreqs()
        {
            throw new NotImplementedException();
        }

        public void SwitchOptions(TransformOptions newOptions)
        {
            generator.SwitchOptions(newOptions);
        }

        FreqPoint[][] ITransformer.GetSpectrum()
        {
            var logger = new Logger("GetSpectrum1.txt");
            //синхронизация, чтобы не возникло проблем при пересчете спектра
            lock (spectrum)
            {
                //log start
                foreach (var freq in spectrum[0])
                    logger.WriteLogFreq(freq);
                logger.Flush();
                //log end

                return spectrum;
            }
        }

        virtual public async void CalcSpectrum()
        {
            var spec = new FreqPoint[0][];
            await Task.Run(() =>
            {
                spec = generator.GetSpectrum();
                //синхронизация, чтобы не возникло проблем при пересчете спектра
                lock (spectrum)
                {
                    spectrum = spec;
                }
                TransformChanged();
            });
        }

    }
}
