using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrumVisor
{

    class RoundSpectrum : ISpectrumViewer
    {
        private TransformViewState viewState;
        //private static int WHEEL_DELTA = 120;

        public RoundSpectrum(TransformViewState state)
        {
            viewState = state;
        }

        public Bitmap GetView(Size area, ITransformer transformer)
        {
            var logger = new Logger("GetView1.txt");//log

            var opts = (RoundOptions)viewState.GetCurrent();

            var bitmapChart = new Bitmap(area.Width, area.Height);
            var scale = opts.ScalePercents / 100;
            var size = (int)Math.Round(Math.Min(area.Width * scale, area.Height * scale));
            var gr = Graphics.FromImage(bitmapChart);

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            gr.Clear(Color.White);

            var circlePen = new Pen(opts.CircleColor);
            gr.DrawEllipse(circlePen, opts.CircleThickness, opts.CircleThickness, size, size);
            Point? last = null;

            //log
            logger.WriteLog(String.Format("Transform lenth is: {0}", transformer.GetSpectrum()[0].Length));

            foreach (var freq in opts.GetCurrent(transformer))
            {
                //log
                logger.WriteLog(String.Format("Freq is {0}, X is: {1}, Y is: {2}", freq.Freq, freq.Coords.Real, freq.Coords.Imaginary));
                var value = freq.Coords;
                if (double.IsNaN(value.Real) || double.IsNaN(value.Imaginary))
                    break;

                Point? current = new Point((int)Math.Round((value.Real * size + size) / 2),
                    (int)Math.Round((value.Imaginary * size + size) / 2));

                var pointBr = new SolidBrush(opts.PointColor);
                var rad = opts.PointRadius;
                gr.FillEllipse(pointBr, current.Value.X - rad, current.Value.Y - rad, 2 * rad, 2 * rad);

                if (last != null)
                    gr.DrawLine(Pens.Orange, last.Value, current.Value);

                var freqStr = freq.Freq.ToString();
                gr.DrawString(freqStr, opts.TextFont, Brushes.Black, current.Value.X - rad,
                    current.Value.Y - rad);

                last = current;
            }

            logger.Flush();//log
            return bitmapChart;
        }
    }
}
