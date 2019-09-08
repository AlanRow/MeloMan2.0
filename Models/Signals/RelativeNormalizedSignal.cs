using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models.Signals
{
    //class RelativeNormalizedSignal : ISignal
    //{
    //    private ISignal signal;

    //    public RelativeNormalizedSignal(ISignal original)
    //    {
    //        signal = original;
    //    }

    //    public override IEnumerable<double> GetValues(int start, int duration)
    //    {
    //        var values = signal.GetValues().ToArray();
    //        var norm = new double[values.Length];
    //        var av = values.Average();

    //        var avDev = 0d;//среднее отклонение от среднего
    //        for (var i = 0; i < values.Length; i++)
    //        {
    //            var dev = Math.Abs(av - values[i]);
    //            avDev *= i / (i + 1);
    //            avDev += dev / (i + 1);
    //        }

    //        var rising = -av + avDev;//смещение сигнала по высоте

    //        var avRis = 0d;//сумма со смещением

    //        for (var i = 0; i < values.Length; i++)
    //        {
    //            avRis *= i / (i + 1);
    //            avRis += (values[i] + rising) / (i + 1);
    //        }

    //        //если сигнал настолько мал, то не имеет смысла его умножать
    //        if (avRis == 0)
    //            return values;

    //        var normFactor = -1 / (avRis * values.Length * values.Length);//множитель нормирования
    //        //теперь нормализуем сигнал
    //        for (var i = 0; i < values.Length; i++)
    //        {
    //            norm[i] = (values[i] + avRis) * normFactor;
    //        }

    //        return norm;
    //    }

    //    public override IEnumerable<double> GetValues()
    //    {
    //        return GetValues(0, signal.GetLength());
    //    }
    //}
}
