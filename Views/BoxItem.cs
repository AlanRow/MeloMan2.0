using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Views
{
    public class BoxItem
    {
        public readonly object Key;
        public string Name { get; private set; }

        public BoxItem(object key, string name)
        {
            Key = key;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
