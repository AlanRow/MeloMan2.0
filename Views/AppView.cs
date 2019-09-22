using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Controllers;

namespace SpectrumVisor.Views
{
    public class AppView
    {
        private int margin;
        private SignalsView signals;
        private SpectrumPanelView spectrum;

        static readonly public Size DEFAULT_SIZE = new Size(800, 640);
        static readonly public int DEFAULT_MARGIN = 20;

        public AppView(AppController controller, Size size, int margin)
        {
            this.margin = margin;
            signals = new SignalsView(controller);
            spectrum = new SpectrumPanelView(controller);
        }

        public AppView(AppController controller) : this(controller, DEFAULT_SIZE, DEFAULT_MARGIN) { }

        public Panel View(AppViewContext context)
        {
            var table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;

            //разметка формы
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, margin));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, margin));

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, margin));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, margin));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, margin));

            var signalPan = signals.View(context.Signals);
            var spectrumPan = spectrum.View(context.Spectrum);
            //signalPan.BackColor = Color.White;
            var transformPan = new Panel();

            table.Controls.Add(new Panel(), 0, 1);
            table.Controls.Add(signalPan, 1, 1);
            table.Controls.Add(new Panel(), 2, 1);
            table.Controls.Add(spectrumPan, 3, 1);
            table.Controls.Add(new Panel(), 4, 1);
            //table.Controls.Add(transformPan, 3, 1);

            table.Dock = DockStyle.Fill;

            return table;
        }
    }
}
