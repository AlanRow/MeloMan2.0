using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Models;
using SpectrumVisor.State.Signal;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    public class AppController
    {
        private AppView view;
        private AppModel model;

        //private SignalModel signalModel;
        //private TransformsModel transformsModel;

        //AppController - входная точка для конкретного приложения инициализирует основные контроллеры и форму
        public AppController(AppModel appModel)
        {
            model = appModel;
            view = new AppView();
            var signals = new SignalsController(this, model);
            var transform = new TransformController(this, model);

            //    signalModel = new SignalModel(model);
            //    transformsModel = new TransformsModel(signalModel);

            //    var signal = new SignalController(signalModel);
            //    var transforms = new TransformsController(transformsModel);

            //    var view = new AppView(signal.GetView(), transforms.GetView());
            //    view.View();
        }

        public void Start()
        {
            view.View();
        }

        public void SetSignalsView(SignalsView signalsView)
        {
            view.ViewSignal(signalsView.View());
        }

        public void SetTransformView(TransformView transformView)
        {
            view.ViewTransform(transformView.View());
        }

        //заглушка
        //public ISignal AddSignal()
        //{
        //    return new DigitalSignal(new double[model.Size]);
        //}

        //public Start()
        //{
        //    view.View();
        //}
    }
}
