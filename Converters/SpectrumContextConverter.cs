using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;

namespace SpectrumVisor.Converters
{
    class SpectrumContextConverter
    {
        static public SpectrumViewContext GetSpectrumContext(AppModel model)
        {
            return new SpectrumViewContext(model.Transformation.GetTransform(), model.Transformation.GetNorm(), 
                                           model.GraphContext.RoundView);
        }
    }
}
