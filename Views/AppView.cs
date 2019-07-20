using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrumVisor.Views
{
    public class AppView : ISelfView
    {
        private Form main;
        private Panel signal;
        private Panel transform;
        private TableLayoutPanel table;

        static readonly public Size DEFAULT_SIZE = new Size(800, 640);

        static readonly public int DEFAULT_MARGIN = 30;

        public AppView(Size size, int margin)
        {
            main = new Form()
            {
                Size = size
            };

            //разметка формы
            table = new TableLayoutPanel();

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, margin));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, margin));

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, margin));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 2 * margin));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, margin));

            signal = new Panel();
            transform = new Panel();

            table.Controls.Add(signal, 1, 1);
            table.Controls.Add(transform, 3, 1);
        }

        public AppView() : this(DEFAULT_SIZE, DEFAULT_MARGIN) { }

        public void Close()
        {
            main.Close();
        }

        public void View()
        {
            try
            {
                Application.Run(main);
            }
            catch (InvalidOperationException ex)
            {
                main.Invalidate();
            }

        }

            public void ViewSignal(Panel newSignal)
        {
            table.Controls.Remove(signal);
            table.Controls.Add(newSignal, 1, 1);
            View();
        }

        public void ViewTransform(Panel newTransform)
        {
            table.Controls.Remove(transform);
            table.Controls.Add(newTransform, 3, 1);
            View();
        }
    }
}
