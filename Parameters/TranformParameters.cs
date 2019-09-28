using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Stuffs;

namespace SpectrumVisor.Parameters
{
    public class TransformParameters : IInputFormParameters
    {
        public IntParam Count;
        public DoubleParam Start;
        public DoubleParam Step;

        public TransformParameters(TransformStuff current)
        {
            Start = new DoubleParam("Нижняя частота: ", "Частота", current.StartFreq);
            Step = new DoubleParam("Шаг частоты: ", "Шаг", current.StepFreq);
            Count = new IntParam("Число шагов: ", "Кол-во шагов", current.CountFreq);
        }

        public override Param[] GetParams()
        {
            return new Param[] { Start, Step, Count };
        }
    }
}
