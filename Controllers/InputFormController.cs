using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models;
using SpectrumVisor.Parameters;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    interface IInputFormController
    {
        void Send(IInputFormParameters parameters);
    }
}
