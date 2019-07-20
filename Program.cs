using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using SpectrumVisor.Views;
using SpectrumVisor.Controllers;
using SpectrumVisor.Parameters;

namespace SpectrumVisor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Application.Run(new SpectrumVisorForm());
            var start = new StartController();
        }
    }
}
