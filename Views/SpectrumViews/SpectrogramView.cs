using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;

namespace SpectrumVisor.Views.SpectrumViews
{
    public class SpectrogramView : ISpectrumView
    {
        public SpectrogramView()
        {

        }

        public Panel View(SpectrumViewContext context)
        {
            var pan = new Panel
            {
                Dock = DockStyle.Fill
            };

            var intensities = new byte[context.Transformed.GetTimeSize(), context.Transformed.GetFreqSize()];
            var logger = new Logger("max_magns.txt");

            for (var i = 0; i < intensities.GetLength(0); i++)
            {
                var density = context.Transformed.GetDensitiesAtTime(i)
                    .ToArray();

                var max = density.Max();
                logger.WriteLog(String.Format("Time: {0}, MaxValue: {1}", i, max));


                for (var j = 0; j < intensities.GetLength(1); j++)
                {
                    intensities[i, j] = max > 0 ? (byte)(density[intensities.GetLength(1) - j - 1] * 255 / max) : (byte)0;
                }
            }

            logger.Flush();

            var box = DrawSpectrogram(pan.ClientSize, intensities);
            pan.Controls.Add(box);

            return pan;
        }

        public PictureBox DrawSpectrogram(Size area, byte[,] intensity)
        {
            var spectrogram = new Bitmap(intensity.GetLength(0), intensity.GetLength(1));
            var box = new PictureBox
            {
                Dock = DockStyle.Fill
            };

            for (var i = 0; i < intensity.GetLength(0); i++)
            {
                for (var j = 0; j < intensity.GetLength(1); j++)
                {
                    var intens = intensity[i, j];
                    spectrogram.SetPixel(i, j, Color.FromArgb(intens, intens, intens));
                }
            }

            spectrogram.Save("spectrum");

            box.SizeMode = PictureBoxSizeMode.StretchImage;
            box.Image = spectrogram;

            return box;
        }
    }
}
