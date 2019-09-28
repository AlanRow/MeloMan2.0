using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Contexts
{
    public class TransformContext : InputFormContext
    {
        public TransformContext(TransformStuff current) : base(new TransformParameters(current)) { }

        public override Param[][] GetParamtersByColumns()
        {
            var param = (InputParameters as TransformParameters);
            return new Param[][] { new Param[] { param.Start, param.Step },
                                   new Param[] { param.Count } };
        }
    }
}
