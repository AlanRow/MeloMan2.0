using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Views.SpectrumViews;

namespace SpectrumVisor.Views
{
    //генерирует новую панель с текущим изображением преобразования
    public class SpectrumPanelView
    {
        private enum ViewType
        {
            RoundView,
            LinearChart,
            Spectrogram
        }
    
        //private Panel transformPanel;
        private ISpectrumView spectrumView;
        private Dictionary<ViewType, ISpectrumView> views;

        public SpectrumPanelView()
        {
            views = new Dictionary<ViewType, ISpectrumView>
            {
                [ViewType.RoundView] = new RoundView(),
                [ViewType.LinearChart] = new SpectrumDensityChart(),
                [ViewType.Spectrogram] = new SpectrogramView()
            };
            spectrumView = views[ViewType.Spectrogram];
        }

        public Panel View(SpectrumViewContext context)
        {
            var pan = new Panel
            {
                Dock = DockStyle.Fill
            };

            var spectrumPan = spectrumView.View(context);
            spectrumPan.Dock = DockStyle.Fill;

            pan.Controls.Add(spectrumPan);

            return pan;
        }
    }
}
