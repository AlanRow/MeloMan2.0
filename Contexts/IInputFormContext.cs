using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Contexts
{
    public class InputFormContext
    {
        public readonly IInputFormParameters InputParameters;

        public InputFormContext(IInputFormParameters parameters)
        {
            InputParameters = parameters;
        }

        virtual public Param[][] GetParamtersByColumns()
        {
            return new[] { InputParameters.GetParams()};
        }
    }
}
