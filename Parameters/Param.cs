using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    abstract public class Param
    {
        public string Label;
        public string ShortName;
        public abstract void SetValue(string strValue);
        public abstract string GetStrValue();
    }
}
