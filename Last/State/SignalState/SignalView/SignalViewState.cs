﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor
{
    //предоставляет информацию о текущем представлении сигнала/сигналов
    //WORK
    //INCOMPLETE
    public class SignalViewState
    {
        public static SignalViewType DEFAULT_VIEW = SignalViewType.Divided;

        public SignalViewType CurrentType { get; set; }
        private Dictionary<SignalViewType, ISignalsVisualizer> views;

        public SignalViewState(SignalsModel manager, SignalViewType current)
        {
            views = new Dictionary<SignalViewType, ISignalsVisualizer>();
            SetView( new AloneVisualizer(manager.Sum), SignalViewType.Summarized);
            SetView(new ManagerVisualizer(manager), SignalViewType.Divided);

            var divided = new List<SignalViewOptions>();

            CurrentType = current;
        }

        public SignalViewState(SignalsModel manager) : this(manager, DEFAULT_VIEW) { }

        public void AddSignal(SinSignal signal, SignalViewType type)
        {
            views[type].AddSignal(signal);
        }
        
        public void SetView(ISignalsVisualizer signals, SignalViewType type)
        {
            views[type] = signals;
        }

        public ISignalsVisualizer GetCurrentViews()
        {
            return views[CurrentType];
        }

        //текущее название сигнала
        public string GetCurrentName()
        {
            return "Default";
        }
    }
}
