using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Controllers;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Views
{
    //генерирует новую панель с текущим изображением сигнала
    public class SignalsView
    {
        private enum ViewType
        {
            Sum,
            All,
            //Norm
        }

        //private Panel signals;

        private SignalsChartView chartView;
        private SignalsListView listView;
        private ViewType currentView;

        private Panel controlPanel;
        //private ComboBox viewChangeBox;
        //private Button addSignalButton;

        //caching system
        //private SignalsViewContext lastContext;
        private TableLayoutPanel lastSignals;
        private Panel lastChart;
        private Dictionary<ViewType, Panel> charts;
        //private Panel lastList;

        public SignalsView(AppController controller)
        {
            chartView = new SignalsChartView();
            listView = new SignalsListView(controller);
            currentView = ViewType.All;

            //элементы управления сигналами
            controlPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill
            };

            var viewChangeBox = new ComboBox();
            viewChangeBox.Items.Add(new BoxItem(ViewType.All, "Все"));
            viewChangeBox.Items.Add(new BoxItem(ViewType.Sum, "Сумма"));
            //viewChangeBox.Items.Add(new BoxItem(ViewType.Norm, "Нормализованный"));
            viewChangeBox.SelectedIndexChanged += (sender, ev) => {
                currentView = ((ViewType)((BoxItem)((ComboBox)sender).SelectedItem).Key);
                SwitchView();
            };

            var addSignalButton = new Button
            {
                Text = "Создать сигнал",
                AutoSize = true
            };
            addSignalButton.Click += (sender, ev) => {
                controller.AddSignal();
            };

            controlPanel.Controls.Add(viewChangeBox);
            controlPanel.Controls.Add(addSignalButton);
        }

        public void SwitchView()
        {
            lastSignals.Controls.Remove(lastChart);
            lastSignals.Controls.Add(charts[currentView], 0, 1);
            lastChart = charts[currentView];
        }

        public Panel GetCurrentView(SignalsViewContext context)
        {
            var viewings = new SignalViewContext[0];

            charts = new Dictionary<ViewType, Panel>
            {
                [ViewType.All] = chartView.View(context.Signals),
                [ViewType.Sum] = chartView.View(new[] { context.Sum }),
                //[ViewType.Norm] = chartView.View(new[] { context.Norm }),
            };

            lastChart = charts[currentView];
            return charts[currentView];
        }

        //заглушка
        public Panel View(SignalsViewContext context)
        {
            var signals = new TableLayoutPanel();
            signals.Dock = DockStyle.Fill;

            signals.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            signals.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            signals.RowStyles.Add(new RowStyle(SizeType.Percent, 60));

            signals.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            var chart = GetCurrentView(context);
            var list = listView.View(context.Signals);

            signals.Controls.Add(controlPanel, 0, 0);
            signals.Controls.Add(chart, 0, 1);
            signals.Controls.Add(list, 0, 2);

            lastSignals = signals;
            return signals;
        }
    }
}
