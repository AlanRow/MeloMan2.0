using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Converters;
using SpectrumVisor.Models;
using SpectrumVisor.Parameters;
using SpectrumVisor.State.Signal;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    public class AppController
    {
        private AppView view;
        private AppModel model;
        private AppForm form;

        private AddSignalController signalIniter;

        //private SignalsController signals;
        //private TransformController transform;

        //private SignalModel signalModel;
        //private TransformsModel transformsModel;

        //AppController - входная точка для конкретного приложения инициализирует основные контроллеры и форму
        public AppController(AppModel appModel)
        {
            model = appModel;
            model.Transformation.AddSignal(new SignalStuff(
                0, model.Size, 48, 10, 15));
            model.Transformation.AddSignal(new SignalStuff(
                0, model.Size, 32, 10, 15));
            view = new AppView(this);
            form = new AppForm(view.View(AppContextConverter.GetContext(model)));

            signalIniter = new AddSignalController(model);

            model.Transformation.SignalsChanged += () =>
            {
                UpdateAppView();
            };
        }

        public void Start()
        {
            UpdateAppView();

            Application.Run(form);
        }

        public void DeleteSignal(int id)
        {
            model.Transformation.DeleteSignalById(id);
        }

        public void AddSignal()
        {
            signalIniter.AddSignal();
        }

        public void UpdateAppView()
        {
            form.Update(view.View(AppContextConverter.GetContext(model)));
        }
    }
}
