using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Contexts
{
    public class AddSignalContext : InputFormContext
    {
        public AddSignalContext() : base(new SignalParameters()) {}

        public override Param[][] GetParamtersByColumns()
        {
            var param = (InputParameters as SignalParameters);
            return new Param[][] { new Param[] { param.Start, param.Duration },
                                   new Param[] { param.Freq, param.Mult },
                                   new Param[] { param.Name} };
        }
    }
}
