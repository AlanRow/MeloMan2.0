using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models
{
    public class SignalsManageModel
    {
        private List<ISignal> ids;

        public SignalsManageModel()
        {
            ids = new List<ISignal>();
        }

        public ISignal GetSignal(int id)
        {
            return ids[id];
        }

        public int RegisterSignal(ISignal signal)
        {
            ids.Add(signal);
            Logger.DEFLOG.WriteLog(String.Format("Register id: {0}", ids.Count - 1));
            Logger.DEFLOG.Flush();
            return ids.Count - 1;
        }

        public int GetID(ISignal signal)
        {
            Logger.DEFLOG.WriteLog(String.Format("Get id: {0}", ids.IndexOf(signal)));
            Logger.DEFLOG.Flush();
            return ids.IndexOf(signal);
        }
    }
}
