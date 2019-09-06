using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;

namespace SpectrumVisor.Models
{
    public class TextContextModel
    {
        private Dictionary<ISignal, TextSignalContext> contexts;
        
        public TextContextModel()
        {
            contexts = new Dictionary<ISignal, TextSignalContext>();
        }


        public void SetContext(ISignal signal, TextSignalContext context)
        {
            contexts[signal] = context;
        }

        public TextSignalContext GetContext(ISignal signal)
        {
            if (contexts.ContainsKey(signal))
                return contexts[signal];

            return TextSignalContext.GetDefault();
        }

        static public string GetDescriptionByStuff(SignalStuff stuff)
        {

            if (stuff.Mult == 0)
                return "0";

            if (stuff.Freq == 0)
                return (Math.Sin(stuff.PhaseOffset)).ToString();

            var argStr = (stuff.PhaseOffset > 0) ? "(x + " + stuff.PhaseOffset + ")" :
                (stuff.PhaseOffset < 0) ? "(x - " + Math.Abs(stuff.PhaseOffset) + ")" : "x";

            var freqStr = (stuff.Freq != 1) ? stuff.Freq.ToString() + "PI" : "PI";

            var multStr = (stuff.Mult != 1) ? stuff.Mult + " * " : "";
            
            return multStr + "sin(" + freqStr + argStr + ")";
        }
    }
}
