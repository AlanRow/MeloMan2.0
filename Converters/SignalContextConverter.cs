using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;

namespace SpectrumVisor.Converters
{
    static class SignalContextConverter
    {
        static public SignalsViewContext GetSignalsContext(AppModel model)
        {
            var signals = model.Transformation.GetSignals()
                                .Select(s => GetSignalContext(s, model))
                                .ToArray();
            var sum = GetAbstractSignalContext(model.Transformation.GetSum(), model);
            var norm = GetAbstractSignalContext(model.Transformation.GetNorm(), model);

            return new SignalsViewContext(signals, sum, norm);
        }

        static public SignalViewContext GetSignalContext(ISignal s, AppModel model)
        {
            return new SignalViewContext(model.Transformation.ManageModel.GetID(s), s,
                model.GraphContext.GetContext(s), model.TextContext.GetContext(s));
        }

        static public SignalViewContext GetAbstractSignalContext(ISignal s, AppModel model)
        {
            return new SignalViewContext(-1, s, model.GraphContext.GetContext(s),
                                         model.TextContext.GetContext(s));
        }
    }
}
