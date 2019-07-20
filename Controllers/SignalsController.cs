using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    //данный класс отвечает за создание представления сигналов и за взаимодействие их с моделями и другими
    //контроллерами
    public class SignalsController
    {
        public SignalsController(AppController app, AppModel model)
        {
            var view = new SignalsView();
            app.SetSignalsView(view);
        }
    }
}
