using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;
using SpectrumVisor.Parameters;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    public class AddSignalController : IInputFormController
    {
        private AppModel model;
        private InputFormView view;

        public AddSignalController(AppModel appModel)
        {
            model = appModel;
            view = new InputFormView(this, new AddSignalContext());
        }

        public void AddSignal()
        {
            view.View();
        }

        public void Send(IInputFormParameters parameters)
        {
            if (!(parameters is SignalParameters))
                throw new FormatException("Parameters aren't signal parameters!");

            var par = parameters as SignalParameters;

            var signal = model.Transformation.AddSignal(new SignalStuff(par.Start.GetValue(), par.Duration.GetValue(), 
                                                           par.Freq.GetValue(), par.Mult.GetValue(),
                                                           par.Const.GetValue())).Item1;
            model.TextContext.SetContext(signal, new TextSignalContext(par.Name.GetStrValue(),
                                                                       par.Description.GetStrValue()));
            model.GraphContext.SetContext(signal, new GraphicsSignalContext((par.LineColor as EnumParam<Color>).GetValue()));
        }
    }
}
