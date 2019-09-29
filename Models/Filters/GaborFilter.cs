using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Signals;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models.Filters
{
    public class GaborFilter : IWindowFilter
    {
        private RectangleFilter window;

        private int center;
        private int winSize;

        //private double alpha;

        public GaborFilter(FilterStuff stuff)
        {
            center = stuff.Center;
            winSize = stuff.Size;
            window = new RectangleFilter(stuff);
        }

        public GaborFilter()
        {
            center = 0;
            winSize = 128;
            window = new RectangleFilter();
        }

        public ISignal GetFiltered(ISignal signal, int center, int winSize)
        {
            var alpha = winSize / 3.8286;
            return new FilteredSignal(window.GetFiltered(signal, center, winSize),
                                      (time) => Math.Exp(-Math.PI*(center - time)*(center - time)/(alpha*alpha)));
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
