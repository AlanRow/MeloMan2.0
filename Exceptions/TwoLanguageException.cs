using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Exceptions
{
    public class TwoLanguageException : Exception
    {
        protected Dictionary<string, string> locale;

        public TwoLanguageException(string enMessage, string ruMessage) : base(enMessage)
        {
            locale["en"] = enMessage;
            locale["ru"] = ruMessage;
        }

        public string getRu()
        {
            return locale["ru"];
        }

        public string getEn()
        {
            return locale["en"];
        }
    }
}
