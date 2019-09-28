using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    public class BidirectDictionary<Key1, Key2>
    {
        private Dictionary<Key1, Key2> strict;
        private Dictionary<Key2, Key1> reverse;

        public BidirectDictionary(Dictionary<Key1, Key2> dict)
        {
            strict = dict;

            var uniqueValues = strict.Values.Distinct();
            if (uniqueValues.Count() < strict.Values.Count())
                throw new Exception("Values must not repeat!");

            reverse = new Dictionary<Key2, Key1>();
            foreach (var key in strict.Keys)
            {
                reverse[strict[key]] = key;
            }
        }

        public Key2 this[Key1 key]
        {
            get
            {
                return strict[key];
            }
        }

        public Key1 this[Key2 key]
        {
            get
            {
                return reverse[key];
            }
        }

        public IEnumerable<Key1> GetFirstKeys()
        {
            return strict.Keys;
        }

        public IEnumerable<Key2> GetSecondKeys()
        {
            return reverse.Keys;
        }
    }
}
