using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Controllers;

namespace SpectrumVisor.Views
{
    class SignalsListView
    {
        private static int frameHeight = 100;
        private AppController controller;

        public SignalsListView(AppController creator)
        {
            controller = creator;
            //var manager = state.Signal.Internal;

            //Height = (manager.Signals.Count + 1) * frameHeight + 50;
            //FlowDirection = FlowDirection.LeftToRight;

            ////ScrollBar scroll = new VScrollBar();
            ////scroll.Dock = DockStyle.Right;
            ////scroll.Scroll += (sender, ev) =>
            ////{
            ////    VerticalScroll.Value = scroll.Value;
            ////};

            //addButton = GetAddButton(state.Signal);

            //for (var i = 0; i < manager.Signals.Count; i++)
            //{
            //    var j = i;
            //    var signalFrame = GetSignalFrame(manager, manager.Signals[i], j);
            //}

            //Controls.Add(addButton);
            ////Controls.Add(scroll);
        }

        public Panel View(SignalViewContext[] signals)
        {
            var list = new TableLayoutPanel();
            list.Dock = DockStyle.Fill;

            list.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            for (var i = 0; i < signals.Length; i++)
            {
                list.RowStyles.Add(new RowStyle(SizeType.Absolute, frameHeight));
                list.Controls.Add(GetSignalFrame(signals[i]), 0, i);
            }

            
            return list;
        }

        private Panel GetSignalFrame(SignalViewContext context)
        {
            var frame = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Top,
            };

            var delButton = new Button
            {
                Dock = DockStyle.Bottom,
                Text = "Удалить"
            };

            delButton.Click += (sender, ev) =>
            {
                var id = context.SignalID;
                controller.DeleteSignal(id);
                //new SignalDeleteConfirm(manager, signal).ShowDialog();
            };

            var formula = new Label
            {
                Dock = DockStyle.Top,
                Text = context.Name,
                Font = new Font("Arial", 12)
            };

            frame.Controls.Add(formula);
            frame.Controls.Add(delButton);

            return frame;
        }
    }
}
