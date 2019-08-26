using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SpectrumVisor.Contexts;

namespace SpectrumVisor.Views
{
    public class SignalsChartView
    {
        //private Panel chartPanel;
        //private Chart chart;

        public SignalsChartView()
        {
            //chartPanel = new Panel();
            //chart = new Chart();
            //chartPanel.Controls.Add(chart);

            //chartPanel.SizeChanged += (sender, ev) =>
            //{
            //    var minSize = Math.Min(chartPanel.Width, chartPanel.Height);
            //    chartPanel.Size = new Size(minSize, minSize);
            //};
        }

        public Panel View(SignalViewContext[] signals)
        {
            var chartPanel = new Panel();
            chartPanel.Dock = DockStyle.Fill;

            var chart = GenerateChart(signals);
            chart.Dock = DockStyle.Fill;
            chartPanel.Controls.Add(chart);
            //MessageBox.Show(signals.Count().ToString());

            return chartPanel;
        }


        private Chart GenerateChart(SignalViewContext[] signals)
        {
            var chart = new Chart();
            
            chart.ChartAreas.Add("signal");

            for (var i = 0; i < signals.Length; i++)
            {
                Series signalSeries = new Series(i.ToString());

                var signal = signals[i];
                signalSeries.ChartType = SeriesChartType.Line;
                signalSeries.ChartArea = "signal";

                var color = signal.LineColor;
                signalSeries.Color = color;

                var j = 0;
                foreach (var val in signal.Signal.GetValues())
                {
                    signalSeries.Points.AddXY(j, val);
                    j++;
                }

                chart.Series.Add(signalSeries);
            }

            return chart;
        }
    }
}
