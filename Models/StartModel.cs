using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Models
{
    public class StartModel : Generator
    {
        public static StartParameters GetDefaultParameters()
        {
            return null;
            //return new StartParameters.GetDefault();
        }

        public override IModel Generate(Dictionary<string, Param> parameters)
        {
            base.Generate(parameters);
            return new AppModel(parameters["size"]);
        }

        public override Param[][] GetParameters()
        {
            var signalSize = new Param("size", "Длительность сигнала", "1024");
            return new [] { new[] { signalSize } };
        }
    }
}
