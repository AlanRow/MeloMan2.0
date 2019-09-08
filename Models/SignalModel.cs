using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //агрегирует информацию об исходных сигналах
    //сообщает о создании и удалении сигнала
    public class SignalsModel
    {
        //исходные сигналы
        public List<SinSignal> Signals { get; private set; }
        public SumSignal Sum { get; private set;}

        //next ID
        //private long nextID;

        //общая длительность по времени (не используется)
        //public double TimeDuration { get; private set; }
        public int Size { get; private set; }


        //public delegate void SignalsChanged(SinSignal gener);
        //public event SignalsChanged AddedSignal;
        //public event SignalsChanged DeletedSignal;

        public SignalsModel(int size)
        {
            Signals = new List<SinSignal>();
            Sum = new SumSignal(this);
            Size = size;
        }

        public ISignal AddSignal(SignalStuff material)
        {
            Signals.Add(new SinSignal(material));
            return Signals[Signals.Count - 1];

            //if (AddedSignal != null)
            //    AddedSignal(signal);
        }

        //public SinSignal GetSignalById(int id)
        //{
        //    return Signals.Where(s => s.ID == id).First();
        //}

        //public void DeleteSignalById(int id)
        //{
        //    var index = Signals.Where(s => s.ID == id).First().ID;
        //    Signals.RemoveAt(id);
        //}

        public void DeleteSignal(SinSignal signal)
        {
            var i = Signals.IndexOf(signal);

            if (i >= 0)
                Signals.RemoveAt(i);

            //if (AddedSignal != null)
            //    DeletedSignal(signal);
        }
    }
}
