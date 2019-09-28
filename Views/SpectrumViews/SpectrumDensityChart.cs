using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SpectrumVisor.Contexts;

namespace SpectrumVisor.Views.SpectrumViews
{
    //For visua;ise spectrum density of signal on chart
    public class SpectrumDensityChart : ISpectrumView
    {
        private int timeInd;

        public SpectrumDensityChart()
        {
            timeInd = 0;
        }

        public Panel View(SpectrumViewContext context)
        {
            var pan = new Panel
            {
                Dock = DockStyle.Fill
            };

            var chart = GenerateChart(context);
            chart.Dock = DockStyle.Fill;
            pan.Controls.Add(chart);

            return pan;
        }

        private Chart GenerateChart(SpectrumViewContext spectrum)
        {
            var chart = new Chart();

            var area = chart.ChartAreas.Add("spectrum");
            Series signalSeries = new Series("spectrum");
            signalSeries.ChartType = SeriesChartType.Line;
            signalSeries.ChartArea = "spectrum";
            signalSeries.Color = spectrum.LinearGraphics.LineColor;
            area.AxisX.IsLabelAutoFit = false;

            var interval = (int)Math.Round((spectrum.Transformed.GetFreqSize() / 15.0) * spectrum.Transformed.GetFreqDiff());
            area.AxisX.Interval = interval;

            area.AxisX2.LineColor = Color.Red;


            var freqs = spectrum.Transformed.GetFreqsAtTime(timeInd);
            for (var i = 0; i < freqs.Length; i++)
            {
                var mod = freqs[i].Coords.Magnitude;
                //Spectral density = |F|*|F|/T, where F - Fourier Transform, and T - time
                signalSeries.Points.AddXY(freqs[i].Freq, (mod * mod)/spectrum.Origin.GetLength());
            }

            chart.Series.Add(signalSeries);

            return chart;
        }
    }
}
