using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Models.Transformers;

namespace SpectrumVisor
{
    //агрегирует преобразование и позволяет его изменять
    public class TransformManager
    {
        static TransformType DEFAULT_TYPE = TransformType.Fourier;

        public ITransformer Transformer { get; private set; }
        public TransformOptions Options {get; private set;}
        private Dictionary<TransformType, CachTransformer> transformers;

        public delegate void Changed();

        public TransformManager(SignallController sign)
        {
            Options = new TransformOptions();
            transformers = new Dictionary<TransformType, CachTransformer>
            {
                [TransformType.Fourier] = new CachTransformer(new SimpleSpectrumGener(sign.Internal.Sum),
                                                              sign),
                //[TransformType.Windowed] = new WindowedFourier()
            };

            Transformer = transformers[DEFAULT_TYPE];
        }

        public void SwitchTransform(TransformType type)
        {
            Transformer = transformers[type];
        }
    }
}
