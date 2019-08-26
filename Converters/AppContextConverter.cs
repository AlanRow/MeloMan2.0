using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;

namespace SpectrumVisor.Converters
{
    public static class AppContextConverter
    {
        static public AppViewContext GetContext(AppModel model)
        {
            return new AppViewContext(SignalContextConverter.GetSignalsContext(model), 
                                      SpectrumContextConverter.GetSpectrumContext(model));
        }
    }
}
