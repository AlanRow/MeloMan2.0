using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;
using SpectrumVisor.Parameters;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    class StartController : IInputFormController
    {
        public StartController()
        {
            var view = new InputFormView(this, new StartContext());
            view.View();
        }

        public void Send(IInputFormParameters parameters)
        {
            var appModel = new AppModel(((StartParameters)parameters).Size.GetValue());
            var app = new AppController(appModel);

            var appThread = new Thread(app.Start);
            appThread.Start();
        }
    }
}
