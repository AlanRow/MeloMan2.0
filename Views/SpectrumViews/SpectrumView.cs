using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrumVisor
{
    //размещает на панели представление и кнопку смены представления
    class SpectrumView : Panel
    {
        public SpectrumView(TransformControler transformer)
        {
            //кнопка изменения типа представления
            var changeBox = new TransformViewChangeBox(transformer);
            //панель представления преобразования
            var viewer = new TransformViewDisplay(transformer);

            //viewButton.Dock = DockStyle.Top;
            viewer.Dock = DockStyle.Fill;

            Controls.Add(changeBox);
            Controls.Add(viewer);
        }
    }
}
