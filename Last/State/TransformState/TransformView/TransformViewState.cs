using System;
using System.Collections.Generic;

namespace SpectrumVisor
{
    //отвечает за хранение и смену текущих параметров отображение преобразования
    public class TransformViewState
    {
        static ViewVersion DEFAULT_TYPE = ViewVersion.Round;

        public ViewVersion CurrentType { get; private set; }
        private Dictionary<ViewVersion, TransformViewOptions> views;

        public TransformViewState(TransformOptions opts)
        {
            views = new Dictionary<ViewVersion, TransformViewOptions> {
                [ViewVersion.Round] = new RoundOptions(opts)
            };
            CurrentType = DEFAULT_TYPE;
        }


        public TransformViewOptions GetCurrent()
        {
            return views[CurrentType];
        }

        public void SwitchType(ViewVersion type)
        {
            var newView = views[type];
            if (newView == null)
                throw new ArgumentException(String.Format("Transformation {0} isn't implemented!", type));

            CurrentType = type;
        }
    }
}