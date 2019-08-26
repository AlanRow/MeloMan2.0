using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;

namespace SpectrumVisor.Views.SpectrumViews
{
    public interface ISpectrumView
    {
        Panel View(SpectrumViewContext context);
    }
}
