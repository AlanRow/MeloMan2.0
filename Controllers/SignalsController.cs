using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    //данный класс отвечает за создание представления сигналов и за взаимодействие их с моделями и другими
    //контроллерами
    public class SignalsController
    {
        //private AppController app;
        //private AppModel model;
        //private SignalsView view;

        //public SignalsController(AppController application, AppModel appModel)
        //{
        //    app = application;
        //    model = appModel;
        //    view = new SignalsView();
        //}

        ////public IPanelView GetViewPanel()
        ////{

        ////}

        //public void Start()
        //{
        //    var signals = model.Transformation.GetSignals()
        //                        .Select(s => GetContext(s))
        //                        .ToArray();
        //    var sum = GetContext(model.Transformation.GetSum());
        //    var norm = GetContext(model.Transformation.GetNorm());

        //    var context = new SignalsViewContext(signals, sum, norm);

        //    view.View(context);
        //}

        //private SignalViewContext GetContext(ISignal s)
        //{
        //    return new SignalViewContext(s,
        //        model.GraphContext.GetContext(s),
        //        model.TextContext.GetContext(s));
        //}
    }
}
