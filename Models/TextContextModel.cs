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
                return (Math.Sin(stuff.PhaseOffset) + stuff.Const).ToString();

            var argStr = (stuff.PhaseOffset > 0) ? "(x + " + stuff.PhaseOffset + ")" :
                (stuff.PhaseOffset < 0) ? "(x - " + Math.Abs(stuff.PhaseOffset) + ")" : "x";

            var freqStr = (stuff.Freq != 1) ? stuff.Freq.ToString() + "PI" : "PI";

            var multStr = (stuff.Mult != 1) ? stuff.Mult + " * " : "";

            var constStr = (stuff.Const > 0) ? " + " + stuff.Const :
                (stuff.Const < 0) ? " - " + Math.Abs(stuff.Const) : "";

            return multStr + "sin(" + freqStr + argStr + ")" + constStr;
        }
    }
}
