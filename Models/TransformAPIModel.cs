using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Stuffs;
using SpectrumVisor.Models.Signals;
using SpectrumVisor.Models.Filters;
using SpectrumVisor.Contexts;

namespace SpectrumVisor.Models
{
    //отвечает за доступ к методам изменения/чтения сигналов/преобразования и за их координацию
    //между собой
    public class TransformAPIModel
    {
        private SignalsModel signals;
        private TransformModel transform;
        private IWindowFilter filter;

        readonly public SignalsManageModel ManageModel;

        public delegate void StateNotification();
        public event StateNotification SignalsChanged;
        public event StateNotification TransformChanged;


        public TransformAPIModel(int size)
        {
            signals = new SignalsModel(size);
            transform = new TransformModel(new WindowsSetModel());
            filter = new RectangleFilter();
            ManageModel = new SignalsManageModel();

            SignalsChanged = new StateNotification(() => Transform());
            TransformChanged = new StateNotification(() => { });
        }

        public void SetConfigs(TransformStuff stuff)
        {
            transform.Current = stuff;
            Transform();
            TransformChanged();
        }

        public TransformStuff GetTransformConfigs()
        {
            return transform.Current;
        }

        public List<SinSignal> GetSignals()
        {
            return signals.Signals;
        }

        public ISignal GetSum()
        {
            return signals.Sum;
        }

        public ISignal GetFiltered()
        {
            return transform.GetWindow().GetFiltered(GetSum());
            //return filter.GetFiltered(GetSum());
        }

        public Spectrum GetTransform()
        {
            return transform.Spectrum;
        }

        public void SetWindowType(WindowType type)
        {
            transform.WindowType = type;
        }

        public WindowType GetWindowType()
        {
            return transform.WindowType;
        }

        //public ISignal GetSignalById(int id)
        //{
        //    return signals.GetSignalById(id);
        //}

        public Tuple<ISignal, int> AddSignal(SignalStuff material)
        {
            var signal = signals.AddSignal(material);
            var id = ManageModel.RegisterSignal(signal);
            SignalsChanged();

            transform.Transform(GetSum());
            TransformChanged();

            return Tuple.Create(signal, id);
        }

        public void DeleteSignalById(int id)
        {
            var signal = (SinSignal) ManageModel.GetSignal(id);
            signals.DeleteSignal(signal);
            SignalsChanged();

            transform.Transform(GetSum());
            TransformChanged();
        }

        public void Transform(TransformStuff material)
        {
            transform.Transform(material, GetSum());
            TransformChanged();
        }

        public void Transform(WindowedTransformStuff material)
        {
            transform.Transform(material, GetSum());
            TransformChanged();
        }

        public void Transform()
        {
            transform.Transform(GetSum());
            TransformChanged();
        }
    }
}
