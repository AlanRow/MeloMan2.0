using System.Drawing;

namespace SpectrumVisor
{
    //предоставляет изображение спектра
    public interface ISpectrumViewer
    {
        Bitmap GetView(Size area, ITransformer transformer);
    }
}