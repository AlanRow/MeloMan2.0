﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Stuffs;
using SpectrumVisor.Models.Signals;

namespace SpectrumVisor.Models
{
    //отвечает за доступ к методам изменения/чтения сигналов/преобразования и за их координацию
    //между собой
    public class TransformAPIModel
    {
        private SignalsModel signals;
        private TransformModel transform;
        private NormalizeModel norm;
        readonly public SignalsManageModel ManageModel;

        public delegate void StateNotification();
        public event StateNotification SignalsChanged;
        public event StateNotification TransformChanged;


        public TransformAPIModel(int size)
        {
            signals = new SignalsModel(size);
            transform = new TransformModel(new TransformersSetModel());
            norm = new NormalizeModel();
            ManageModel = new SignalsManageModel();

            SignalsChanged = new StateNotification(() => { });
            TransformChanged = new StateNotification(() => { });
        }

        public List<SinSignal> GetSignals()
        {
            return signals.Signals;
        }

        public ISignal GetSum()
        {
            return signals.Sum;
        }

        public NormalizedSignal GetNorm()
        {
            return norm.GetNorm(GetSum());
        }

        public Spectrum GetTransform()
        {
            return transform.Spectrum;
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
    }
}
