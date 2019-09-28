using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Parameters
{
    public class WindowTransformParameters : TransformParameters
    {
        public IntParam WinSize;
        public IntParam WinStep;

        public WindowTransformParameters(WindowedTransformStuff current) : base(current)
        {
            WinSize = new IntParam("Размер окна: ", "Окно", current.WinSize);
            WinStep = new IntParam("Сдвиг окна: ", "Сдвиг окна", current.WinStep);
        }

        public override Param[] GetParams()
        {
            return new Param[] { Start, Step, Count, WinStep, WinSize };
        }

    }
}
