using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Models
{
    abstract public class Generator : IModel
    {
        virtual public IModel Generate(Dictionary<string, Param> parameters)
        {
            foreach (var column in GetParameters())
                foreach (var param in column)
                    if (parameters[param.ID] == null)
                        throw new ArgumentNullException(String.Format("Parameter {0} isn't iniyialized!"));

            return null;
        }

        public abstract Param[][] GetParameters();
    }
}
