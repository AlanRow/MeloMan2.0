using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Signals;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models.Filters
{
    public class TriangleFilter : IWindowFilter
    {
        private RectangleFilter window;

        private int center;
        private int winSize;

        public TriangleFilter(FilterStuff stuff)
        {
            center = stuff.Center;
            winSize = stuff.Size;
            window = new RectangleFilter(stuff);
        }

        public TriangleFilter()
        {
            center = 128;
            winSize = 128;
            window = new RectangleFilter();
        }

        public ISignal GetFiltered(ISignal signal, int center, int winSize)
        {
            return new FilteredSignal(window.GetFiltered(signal, center, winSize),
                                      (time) =>  1 - 2 * ((double)Math.Abs(center - time)) / winSize);
        }

        public ISignal GetFiltered(ISignal signal)
        {
            return GetFiltered(signal, center, winSize);
        }

        public void SetWinCenter(int c)
        {
            center = c;
        }

        public void SetWinSize(int size)
        {
            winSize = size;
        }
    }
}
