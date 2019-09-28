using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Contexts.SpectrumGraphics
{
    public class GraphicsLinearContext
    {
        readonly public Color LineColor;

        public GraphicsLinearContext(Color lineColor)
        {
            LineColor = lineColor;
        }

        public GraphicsLinearContext() : this(Color.Green) { }
    }
}
