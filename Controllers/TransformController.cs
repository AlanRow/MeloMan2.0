using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    //данный класс отвечает за создание представления преобразования и за взаимодействие его с моделями и другими
    //контроллерами
    public class TransformController
    {
        private AppController app;
        private SpectrumPanelView view;

        public TransformController(AppController application, AppModel model)
        {
            app = application;
            view = new SpectrumPanelView();
        }

        public void Start()
        {
            //app.SetTransformView(view);
        }
    }
}
