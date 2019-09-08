using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Stuffs
{
    public class WindowedTransformStuff : TransformStuff
    {
        private int winSize;
        private int winStep;

        public int WinSize
        {
            get { return winSize; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Win size must be more than 0!");
                winSize = value;
            }
        }

        public int WinStep
        {
            get { return winStep; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Steps count must be more than 0!");
                winStep = value;
            }
        }

        public int LeftWinSize
        {
            get { return WinSize / 2 + (winSize % 2); }
        }

        public int RightWinSize
        {
            get { return WinSize / 2; }
        }

        public IEnumerable<int> Centers()
        {
            var center = LeftWinSize;

            while (true)
            {
                yield return center;
                center += WinStep;
            }
        }

        public WindowedTransformStuff(double start, double step, int count, int winSize, int winStep) : base(start, step, count)
        {
            WinSize = winSize;
            WinStep = winStep;
        }

        public WindowedTransformStuff() : this(0.05, 0.05, 1000, 128, 128) { }
    }
}
