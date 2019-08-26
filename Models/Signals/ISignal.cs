using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //объект позволяющий получить изменчивое перечисление значений сигнала
    abstract public class ISignal
    {
        abstract public IEnumerable<double> GetValues();
        virtual public int GetLength()
        {
            return GetValues().Count();
        }
    }
}
