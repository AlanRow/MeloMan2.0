using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //позволяет взаимодействовать с преобразованием (изменять тип представления, параметры сигнала)
    public class TransformControler
    {
        public readonly TransformManager Transform;
        public readonly TransformViewState View;

        public delegate void Changed();
        public event Changed ViewChanged;

        public TransformControler(SignallController signal)
        {
            Transform = new TransformManager(signal);
            View = new TransformViewState(Transform.Options);

            ViewChanged = () => { };
        }

        public void SwitchView(ViewVersion type)
        {
            View.SwitchType(type);
            ViewChanged();
        }
    }
}
