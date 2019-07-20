using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Contexts
{
    class StartContext : InputFormContext
    {
        public StartContext() : base(new StartParameters()) { }
    }
}
