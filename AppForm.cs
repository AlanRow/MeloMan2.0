using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Views;

namespace SpectrumVisor
{
    public class AppForm : Form
    {
        static public Size DEFAULT_SIZE = new Size(800, 600);

        public AppForm(Panel appPanel, Size startSize)
        {
            Size = startSize;
            Controls.Add(appPanel);
        }

        public AppForm(Panel appPanel) : this(appPanel, DEFAULT_SIZE) { }

        public void Update(Panel updatePanel)
        {
            Controls.Clear();
            Controls.Add(updatePanel);
        }
    }
}
