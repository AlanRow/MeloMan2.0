using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    public class DoubleParam : Param
    {
        private double value;

        public DoubleParam(string label, string shortName, double doubleValue)
        {
            Label = label;
            ShortName = shortName;
            value = doubleValue;
        }

        public override string GetStrValue()
        {
            return value.ToString();
        }

        public double GetValue()
        {
            return value;
        }

        public override void SetValue(string strValue)
        {
            try
            {
                value = Double.Parse(strValue);
            }
            catch (FormatException ex)
            {
                throw new InvalidParamException(String.Format("{0}, это действительное число", ShortName));
            }
        }
    }
}
