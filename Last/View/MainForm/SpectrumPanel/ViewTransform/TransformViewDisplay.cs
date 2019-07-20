using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpectrumVisor
{
    //обеспечивает смену представления спектра
    class TransformViewDisplay : Panel
    {
        private Dictionary<ViewVersion, ISpectrumViewer> viewers;
        private TransformControler transform;

        public TransformViewDisplay(TransformControler controller)
        {
            transform = controller;

            viewers = new Dictionary<ViewVersion, ISpectrumViewer>
            {
                [ViewVersion.Round] = new RoundSpectrum(transform.View)
            };

            DoubleBuffered = true;

            transform.ViewChanged += () =>
            {
                Invalidate();
            };

            Paint += (sender, ev) =>
            {
                RedrawView(ev.Graphics);
            };

            Invalidate();
        }

        public void RedrawView(Graphics gr)
        {
            var size = new Size(ClientRectangle.Width, ClientRectangle.Height);
            var viewer = viewers[transform.View.CurrentType];

            gr.Clear(Color.White);
            gr.DrawImage(viewer.GetView(size, transform.Transform.Transformer), new Point(0, 0));
        }
    }
}