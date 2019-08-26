using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models.Signals
{
    public abstract class NormalizedSignal : ISignal
    {
        //override public IEnumerable<double> GetValues()
        //{
        //    return this.GetValues(0, GetLength());
        //}

        abstract public IEnumerable<double> GetValues(int start, int duration);
    }
}
