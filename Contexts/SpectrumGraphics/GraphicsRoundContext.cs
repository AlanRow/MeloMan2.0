using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Contexts.SpectrumGraphics
{
    public class GraphicsRoundContext
    {
        readonly public Color PointsColor;
        readonly public Color CenterColor;
        readonly public Color LineColor;
        readonly public Color RoundColor;

        readonly public int PointsRadius;
        readonly public int CenterRadius;
        readonly public int LineThickness;
        readonly public int RoundThickness;

        public GraphicsRoundContext(Color points, int pointsRad, Color center, int centerRad, 
                                    Color line, int lineThick, Color border, int borderThick)
        {
            PointsColor = points;
            CenterColor = center;
            LineColor = line;
            RoundColor = border;

            PointsRadius = pointsRad;
            CenterRadius = centerRad;
            LineThickness = lineThick;
            RoundThickness = borderThick;
        }

        public GraphicsRoundContext() : this(Color.Green, 5, Color.Red, 8, Color.Green, 2, Color.Black, 5) { }
    }
}
