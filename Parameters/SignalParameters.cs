﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Parameters
{
    public class SignalParameters : IInputFormParameters
    {
        public IntParam Start;
        public IntParam Duration;
        public DoubleParam Mult;
        public DoubleParam Const;
        public DoubleParam Freq;

        public StringParam Name;
        public StringParam Description;

        public SwitchParam LineColor;

        public SignalParameters()
        {
            Start = new IntParam("Начало сигнала: ", "Начало", 0);
            Duration = new IntParam("Продолжительность сигнала: ", "Продолжительность", 1024);
            Mult = new DoubleParam("Множитель значения: ", "Множитель", 1);
            Const = new DoubleParam("Смещение на константу: ", "Смещение", 0);
            Freq = new DoubleParam("Множитель частоты: ", "Частота", 64);
            Name = new StringParam("Название: ", "Название", "сигнал");
            Description = new StringParam("Описание: ", "Описание", "");
            LineColor = new EnumParam<Color>("Цвет линии: ", "Цвет", new BidirectDictionary<Color, string>(new Dictionary<Color, string>
            {
                [Color.Red] = "Красный",
                [Color.Blue] = "Синий",
                [Color.Green] = "Зеленый",
                [Color.Yellow] = "Желтый",
                [Color.Brown] = "Коричневый",
                [Color.Black] = "Черный"
            }), Color.Red);
        }

        public override Param[] GetParams()
        {
            return new Param[] { Start, Duration, Mult, Const, Freq, Name, Description, LineColor };
        }
    }
}
