using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Transformers;

namespace SpectrumVisor.Models
{
    public class TransformersSetModel
    {
        private Dictionary<TransformType, ITransformer> set;

        public TransformersSetModel()
        {
            set = new Dictionary<TransformType, ITransformer>
            {
                [TransformType.Fourier] = new FourierTransformer(),
                [TransformType.Windowed] = new WindowedFourierTransformer(),
                //[TransformType.Gabor] = new GaborTransformer()
            };
        }

        public ITransformer GetTransformer(TransformType type)
        {
            return set[type];
        }
    }
}
