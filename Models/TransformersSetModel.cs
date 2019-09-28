using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Filters;
using SpectrumVisor.Models.Transformers;

namespace SpectrumVisor.Models
{
    public class WindowsSetModel
    {
        private Dictionary<WindowType, IWindowFilter> set;

        public WindowsSetModel()
        {
            set = new Dictionary<WindowType, IWindowFilter>
            {
                [WindowType.NoWin] = new NoFilter(),
                [WindowType.Rectangle] = new RectangleFilter(),
                [WindowType.Triangle] = new TriangleFilter(),
                [WindowType.Hann] = new HannFilter(),
                [WindowType.Hamming] = new HammingFilter(),
                [WindowType.Gabor] = new GaborFilter()
            };
        }

        public IWindowFilter GetTransformer(WindowType type)
        {
            return set[type];
        }
    }
}
