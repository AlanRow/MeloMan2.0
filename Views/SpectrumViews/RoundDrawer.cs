﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts.SpectrumGraphics;

namespace SpectrumVisor.Views.SpectrumViews
{
    static class RoundDrawer
    {
        static public Bitmap GetView(Size area, Complex center, Complex[] values, GraphicsRoundContext context)
        {
            var logger = new Logger("GetView1.txt");//log

            var bitmapChart = new Bitmap(area.Width, area.Height);
            //var scale = opts.ScalePercents / 100;
            var size = Math.Min(area.Width /* scale*/, area.Height /** scale*/);
            var gr = Graphics.FromImage(bitmapChart);

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            gr.Clear(Color.White);

            gr.DrawEllipse(new Pen(context.RoundColor, context.RoundThickness), 
                           new Rectangle(0, 0, size, size));

            var points = values.Select(v => GetAbsoluteCoords(v, size)).ToArray();

            //for (var i = 0; i < points.Length; i++)
            //{
            //    DrawPoint(gr, points[i], context.PointsRadius, context.PointsColor,
            //              String.Format("{0:0.###}", values[i].Magnitude));
            //}

            gr.DrawCurve(new Pen(context.LineColor, context.LineThickness), points);

            DrawPoint(gr, GetAbsoluteCoords(center, size), context.CenterRadius, context.CenterColor,
                      center.Magnitude.ToString());
          
            return bitmapChart;
        }

        static private Point GetAbsoluteCoords(Complex z, int size)
        {
            return new Point((int)Math.Round((z.Real * size + size) / 2.0),
                    (int)Math.Round((z.Imaginary * size + size) / 2.0));
        }

        static private void DrawPoint(Graphics gr, Point p, int radius, Color color, string label)
        {
            var pointBr = new SolidBrush(color);
            gr.FillEllipse(pointBr, p.X - radius, p.Y - radius, 2 * radius, 2 * radius);

            gr.DrawString(label, new Font(FontFamily.GenericSerif, 8), Brushes.Black, 
                                        p.X - radius, p.Y - radius);
        }
    }
}
