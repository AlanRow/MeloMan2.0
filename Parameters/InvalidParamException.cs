using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Exceptions;

namespace SpectrumVisor.Parameters
{
    public class InvalidParamException : Exception
    {
        public InvalidParamException(string message) : base(message) { }
    }
}
