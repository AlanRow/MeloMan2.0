using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //внутреннее состояние приложения
    //WORK
    //COMPLETE
    public class ApplicationModel
    {
        public SignallController Signal { get; private set; }
        public TransformControler Transform { get; private set; }

        public ApplicationModel()
        {
            Signal = new SignallController();
            Transform = new TransformControler(Signal);
        }
    }
}
