using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Models
{
    class ApplicationGenerator : Generator
    {
        public override IModel Generate(Dictionary<string, Param> parameters)
        {
            base.Generate(parameters);
            return new AppModel(int.Parse(parameters["size"].Value));
        }

        public override Param[][] GetParameters()
        {
            throw new NotImplementedException();
        }
    }
}
