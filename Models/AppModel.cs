using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models
{
    public class AppModel : IModel
    {
        readonly public int Size;

        public AppModel(int size)
        {
            Size = size;
        }
    }
}
