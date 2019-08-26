using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Contexts
{
    public class AppViewContext
    {
        readonly public SignalsViewContext Signals;
        readonly public SpectrumViewContext Spectrum;

        public AppViewContext(SignalsViewContext signals, SpectrumViewContext spectrum)
        {
            Signals = signals;
            Spectrum = spectrum;
        }
    }
}
