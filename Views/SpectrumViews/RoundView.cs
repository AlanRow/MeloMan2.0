using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;

namespace SpectrumVisor.Views.SpectrumViews
{
    public class RoundView : ISpectrumView
    {
        private int freqInd = 10;
        private int timeInd = 0;
        //private ScrollBar freqScroll;
        //private ScrollBar timeScroll;

        public Panel View(SpectrumViewContext context)
        {
            var pan = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                //FlowDirection = FlowDirection.TopDown,
            };

            pan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            //"накручиваем" линейный сигнал на окружность
            var freq = 0d;

            try
            {
                freq = context.Transformed.GetFreqsAtTime(timeInd)[freqInd].Freq;
            } catch (IndexOutOfRangeException ex)
            {
                return pan;
            }

            var points = context.Origin.GetValues().Select((v, i) => Complex.FromPolarCoordinates(v, -i /* * timeFactor */))
                                                   .ToArray();

            foreach (var p in points)
            {
                //MessageBox.Show(p.ToString());
            }
            //var points = new Complex[] { Complex.FromPolarCoordinates(0.5, 0),
            //                             Complex.FromPolarCoordinates(0.5, Math.PI / 2),
            //                             Complex.FromPolarCoordinates(0.5, Math.PI),
            //                             Complex.FromPolarCoordinates(0.5, 3 * Math.PI / 2)};
            var round = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Green,
            };

            round.Paint += (sender, ev) =>
            {
                var center = context.Transformed.GetFreqsAtTime(timeInd)[freqInd].Coords;
                //var center = new Point((int)Math.Round(centerCoords.Real), (int)Math.Round(centerCoords.Imaginary));

                ev.Graphics.Clear(Color.White);
                ev.Graphics.DrawImage(RoundDrawer.GetView(round.ClientSize, center, points, context.RoundGraphics), new Point(0, 0));
            };

            pan.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            pan.Controls.Add(round);
            

            //задаем скролл частот
            if (context.Transformed.GetTimeSize() > 0)
            {
                var freqControl = new Panel
                {
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 40)
                    //FlowDirection = FlowDirection.TopDown
                };

                var freqLabel = new Label
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    Text = "Текущая частота: " + context.Transformed.GetFreqsValues()
                                  .First()
                                  .ToString()
                };

                var freqScroll = new HScrollBar
                {
                    Minimum = 0,
                    Maximum = context.Transformed.GetFreqSize() - 1,
                    Value = freqInd,
                    Dock = DockStyle.Top
                };

                freqScroll.ValueChanged += (sender, ev) => {
                    freqInd = freqScroll.Value;
                    freqLabel.Text = "Текущая частота: " + context.Transformed.GetFreqsValues()
                                            .Skip(freqScroll.Value)
                                            .First()
                                            .ToString();
                    round.Invalidate();
                };

                freqControl.Controls.Add(freqScroll);
                freqControl.Controls.Add(freqLabel);

                pan.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                pan.Controls.Add(freqControl);
            }


            return pan;
        }



    }
}
