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
        abstract public double GetValueAt(int time);
        abstract public int GetLength();

        virtual public IEnumerable<double> GetValues()
        {
            for (var i = 0; i < GetLength(); i++)
                yield return GetValueAt(i);
        }

        virtual public int GetActualLength()
        {
            return GetLength();
        }

    }
}
