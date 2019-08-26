using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumVisor.Models
{
    public class AppModel : IModel
    {
        readonly public int Size;
        readonly public TransformAPIModel Transformation;
        readonly public GraphicsContextModel GraphContext;
        readonly public TextContextModel TextContext;

        public AppModel(int size)
        {
            Logger.DEFLOG.WriteLog(String.Format("Start: {0}", size));
            Logger.DEFLOG.Flush();
            Size = size;
            Transformation = new TransformAPIModel(size);
            GraphContext = new GraphicsContextModel();
            TextContext = new TextContextModel();
        }
    }
}
