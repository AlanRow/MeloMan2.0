using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Views
{
    //интерфейс элемента представления
    public interface ISelfView : IView
    {
        void View();
    }
}
