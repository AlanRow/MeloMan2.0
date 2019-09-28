using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Filters;

namespace SpectrumVisor.Models
{
    class FourierCalculator : IFreqCalculator
    {
        public Complex CalcFreq(ISignal signal, double w)
        {
            var mc = Complex.Zero;
            var i = 0;
            foreach (var val in signal.GetValues())
            {
                mc += Complex.FromPolarCoordinates(val, - i * w * 2 * Math.PI / signal.GetLength());
                i++;
                //Logger.DEFLOG.WriteLog(String.Format("val: {0};", val));
            }
            //Logger.DEFLOG.Flush();

            return mc;
        }
    }
}
