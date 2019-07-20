﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpectrumVisor
{
    class RoundOptions : TransformViewOptions
    {
        private int currentSpec;
        public int WinStep { get; private set; }

        //настройки размеров
        public double ScalePercents { get; private set; }//масштаб в процентах
        public int PointRadius { get; private set; }
        public int TextSize { get; private set; }
        public int CircleThickness { get; private set; }

        //настройки цветов
        public Color CircleColor { get; private set; }
        public Color LineColor { get; private set; }
        public Color PointColor { get; private set; }

        //тип шрифта
        public Font TextFont { get; private set; }

        //дефолтный конструктор
        public RoundOptions(TransformOptions state) : base(state)
        {
            currentSpec = 0;

            WinStep = 16;

            ScalePercents = 95;
            PointRadius = 4;
            TextSize = 10;
            CircleThickness = 5;
            CircleColor = Color.Red;
            LineColor = Color.Yellow;
            PointColor = Color.Green;
            TextFont = new Font("Arial", TextSize);
        }

        //передвинуть окно на указанный индекс
        public void ViewSpec(int ind)
        {
            currentSpec = ind;
        }

        //текущий спектр
        public FreqPoint[] GetCurrent(ITransformer transformer)
        {
            return transformer.GetSpectrum()[currentSpec];
        }

        //изменение масштаба
        public void ZoomScale(double zoomFactor)
        {
            if (zoomFactor > 0)
                ScalePercents *= zoomFactor;
        }
    }
}
