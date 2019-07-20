using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    abstract public class SwitchingParam : Param
    {
        abstract public IEnumerable<string> GetValues();
    }
}
