using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Contexts
{
    public class TransformTypeContext : InputFormContext
    {
        public TransformTypeContext(WindowType type) : base(new TransformTypeParameters(type)) { }
    }
}
