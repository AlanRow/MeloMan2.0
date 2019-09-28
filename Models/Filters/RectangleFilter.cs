using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Signals;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models.Filters
{
    public class RectangleFilter : IWindowFilter
    {
        private int center;
        private int winSize;

        public RectangleFilter(FilterStuff stuff)
        {
            center = stuff.Center;
            winSize = stuff.Size;
        }

        public RectangleFilter()
        {
            center = 0;
            winSize = 128;
        }

        public ISignal GetFiltered(ISignal signal, int c, int size)
        {
            var start = Math.Max(c - size / 2 - (size % 2), 0);
            size = Math.Min(size, signal.GetLength() - start);

            //return new FilteredSignal(signal, ind => (ind < start || ind >= start + window) ? 0 : 1);
            return new WindowedSignal(signal, start, size);
        }

        ISignal IWindowFilter.GetFiltered(ISignal signal)
        {
            return GetFiltered(signal, center, winSize);
        }

        void IWindowFilter.SetWinCenter(int c)
        {
            if (c >= 0)
                center = c;
        }

        void IWindowFilter.SetWinSize(int size)
        {
            if (size > 0)
                winSize = size;
        }
    }
}
