﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Signals;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Models.Filters
{
    public class HannFilter : IWindowFilter
    {
        private RectangleFilter window;

        private int center;
        private int winSize;

        public HannFilter(FilterStuff stuff)
        {
            center = stuff.Center;
            winSize = stuff.Size;
            window = new RectangleFilter(stuff);
        }

        public HannFilter()
        {
            center = 0;
            winSize = 128;
            window = new RectangleFilter();
        }

        public ISignal GetFiltered(ISignal signal, int center, int winSize)
        {
            return new FilteredSignal(window.GetFiltered(signal, center, winSize),
                                      (time) => 1 + Math.Cos(2 * Math.PI * (center - time) / winSize));
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
