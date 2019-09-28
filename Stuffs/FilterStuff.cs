using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Stuffs
{
    public class FilterStuff
    {
        //центр окна
        private int center;
        public int Center
        {
            get { return center; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Центральный отсчет должен быть неотрицательным целым числом");
                center = value;
            }

        }

        //размер окна
        private int size;
        public int Size
        {
            get { return size; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Размер окна должен быть положительным целым числом");
                size = value;
            }

        }
    }
}
