using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    public class StringParam : Param
    {
        private string value;

        public StringParam(string label, string shortName, string startValue)
        {
            Label = label;
            ShortName = shortName;
            value = startValue;
        }

        public override string GetStrValue()
        {
            return value;
        }
        public override void SetValue(string strValue)
        {
            value = strValue;
        }
    }
}
