using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Views;

namespace SpectrumVisor.Parameters
{
    public class EnumParam<T> : SwitchParam
    {
        private BidirectDictionary<T, string> values;
        private T current;

        public EnumParam(string label, string shortName, BidirectDictionary<T, string> validValues, T initial)
        {
            Label = label;
            ShortName = shortName;
            values = validValues;
            current = initial;
        }

        public override IEnumerable<string> GetValidValues()
        {
            return values.GetSecondKeys();
        }

        public override string GetStrValue()
        {
            return values[current];
        }

        public override void SetValue(string strValue)
        {
            var set = values[strValue];

            if (set != null)
                current = set;
        }

        public T GetValue()
        {
            return current;
        }
    }
}
