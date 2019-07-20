using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    public class IntParam : Param
    {
        private int value;

        public IntParam(string label, string shortName, int startValue)
        {
            Label = label;
            ShortName = shortName;
            value = startValue;
        }

        public override string GetStrValue()
        {
            return value.ToString();
        }

        public int GetValue()
        {
            return value;
        }

        public override void SetValue(string strValue)
        {
            try
            {
                value = int.Parse(strValue);
            }
            catch (FormatException ex)
            {
                throw new InvalidParamException(String.Format("{0}, это целое число", ShortName));
            }
        }
    }
}
