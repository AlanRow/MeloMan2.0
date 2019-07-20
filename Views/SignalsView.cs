using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Views
{
    //генерирует новую панель с текущим изображением сигнала
    public class SignalsView : IPanelView
    {
        private Panel signalPanel;

        public SignalsView()
        {
            signalPanel = new Panel();
            var but = new Button
            {
                Text = "Сигнал",
                Dock = DockStyle.Fill
            };
            signalPanel.Controls.Add(but);
        }

        public Panel View()
        {
            return signalPanel;
        }

        //заглушка
        public Panel View(SignalsViewContext context)
        {
            return signalPanel;
        }
    }
}
