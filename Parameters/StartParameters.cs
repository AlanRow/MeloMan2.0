using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    public class StartParameters : IInputFormParameters
    {
        public IntParam Size;

        public StartParameters()
        {
            Size = new IntParam("Длительность сигнала", "Длительность", 1024);
        }


        public override Param[] GetParams()
        {
            return new[]{ Size };
        }
    }
}
