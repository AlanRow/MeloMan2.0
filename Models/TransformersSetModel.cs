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
                [WindowType.Rectangle] = new RectangleFilter()
                //[TransformType.Gabor] = new GaborTransformer()
            };
        }

        public IWindowFilter GetTransformer(WindowType type)
        {
            return set[type];
        }
    }
}
