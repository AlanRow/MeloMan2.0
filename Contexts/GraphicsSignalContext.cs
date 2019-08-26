using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Contexts
{
    public class GraphicsSignalContext
    {
        readonly public Color LineColor;

        public GraphicsSignalContext(Color color)
        {
            LineColor = color;
        }

        static public GraphicsSignalContext GetDefault()
        {
            return new GraphicsSignalContext(Color.Red);
        }
    }
}
