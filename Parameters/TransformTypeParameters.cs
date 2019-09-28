using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    public class TransformTypeParameters : IInputFormParameters
    {
        public EnumParam<WindowType> Type;

        public TransformTypeParameters(WindowType current)
        {
            Type = new EnumParam<WindowType>("Тип преобразования: ", "Тип", new BidirectDictionary<WindowType, string>(new Dictionary<WindowType, string>
            {
                [WindowType.NoWin] = "ДПФ без окна",
                [WindowType.Rectangle] = "Прямоугольное окно",
                [WindowType.Triangle] = "Треугольное окно",
                [WindowType.Hann] = "Окно Ханна",
                [WindowType.Hamming] = "Окно Хэмминга",
                [WindowType.Gabor] = "Преобразование Габора"
            }), current);
        }

        public override Param[] GetParams()
        {
            return new Param[] { Type };
        }
    }
}
