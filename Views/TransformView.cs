using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrumVisor.Views
{
    //генерирует новую панель с текущим изображением преобразования
    public class TransformView : IPanelView
    {
        private Panel transformPanel;

        public TransformView()
        {
            transformPanel = new Panel();
            var but = new Button
            {
                Text = "Преобразование",
                Dock = DockStyle.Fill
            };
            transformPanel.Controls.Add(but);
        }

        public Panel View()
        {
            return transformPanel;
        }
    }
}
