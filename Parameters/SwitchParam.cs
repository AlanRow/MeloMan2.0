using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    public abstract class SwitchParam : Param
    {
        public abstract IEnumerable<string> GetValidValues();
    }
}
