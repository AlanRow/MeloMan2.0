using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Contexts
{
    public class WindowTransformContext : InputFormContext
    {
        public WindowTransformContext(WindowedTransformStuff current) : base(new WindowTransformParameters(current)) { }

        public override Param[][] GetParamtersByColumns()
        {
            var param = (InputParameters as WindowTransformParameters);
            return new Param[][] { new Param[] { param.Start, param.Step },
                                   new Param[] { param.Count },
                                   new Param[] { param.WinSize, param.WinStep } };
        }
    }
}
