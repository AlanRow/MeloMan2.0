using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Controllers;
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
        private Dictionary<ViewType, ISpectrumView> views;
        private ViewType currentView;

        private Panel lastSpectrum;
        private Panel lastView;
        private ComboBox viewChangeBox;
        private Button configButt;

        private SpectrumViewContext lastContext;

        static readonly public int ControlPanHeight = 30;

        public SpectrumPanelView(AppController controller)
        {
            views = new Dictionary<ViewType, ISpectrumView>
            {
                [ViewType.RoundView] = new RoundView(),
                [ViewType.LinearChart] = new SpectrumDensityChart(),
                [ViewType.Spectrogram] = new SpectrogramView()
            };
            currentView = ViewType.Spectrogram;

            viewChangeBox = new ComboBox
            {
                Width = 200
            };
            viewChangeBox.Items.Add(new BoxItem(ViewType.Spectrogram, "Спектрограмма"));
            viewChangeBox.Items.Add(new BoxItem(ViewType.LinearChart, "График спектра мощности"));
            viewChangeBox.Items.Add(new BoxItem(ViewType.RoundView, "Диаграмма преобразования Фурье"));
            viewChangeBox.SelectedIndexChanged += (sender, ev) => {
                currentView = ((ViewType)((BoxItem)((ComboBox)sender).SelectedItem).Key);
                SwitchView();
            };

            configButt = new Button()
            {
                Text = "Настройки..."
            };
            configButt.Click += (sender, ev) =>
            {
                controller.ChangeTransformConfigs();
            };
        }

        public Panel View(SpectrumViewContext context)
        {
            var pan = new TableLayoutPanel
            {
                Dock = DockStyle.Fill
            };

            lastSpectrum = views[currentView].View(context);
            lastSpectrum.Dock = DockStyle.Fill;

            var controlPan = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight
            };

            controlPan.Controls.Add(viewChangeBox);
            controlPan.Controls.Add(configButt);

            pan.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            pan.RowStyles.Add(new RowStyle(SizeType.Percent, 90));

            pan.Controls.Add(controlPan, 0, 0);
            pan.Controls.Add(lastSpectrum, 0, 1);

            lastView = pan;
            lastContext = context;

            return pan;
        }

        private void SwitchView()
        {
            lastView.Controls.Remove(lastSpectrum);
            lastSpectrum = views[currentView].View(lastContext);
            lastView.Controls.Add(lastSpectrum);
            lastView.Invalidate();
        }
    }
}
