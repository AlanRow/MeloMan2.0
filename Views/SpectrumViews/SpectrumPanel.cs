using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrumVisor
{
    //отвечает за расположение панели настроек, панели представления преобразования и кнопки смены типа
    class SpectrumPanel : Panel
    {
        public SpectrumPanel(TransformControler transformer )
        {
            var view = new SpectrumView(transformer);
            var options = new SpectrumOptionsPanel();
            
            Controls.Add(options);
            Controls.Add(view);

            SizeChanged += (sender, ev) =>
            {
                var chartSize = Math.Min(Width, Height * 70 / 100);
                view.Size = new Size(chartSize, chartSize);
                options.SetBounds(0, chartSize + 25, Width, Math.Max(250, Height / 4));
                Invalidate();
            };
        }
    }
}
