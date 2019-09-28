using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectrumVisor.Contexts;
using SpectrumVisor.Models;
using SpectrumVisor.Parameters;
using SpectrumVisor.Stuffs;
using SpectrumVisor.Views;

namespace SpectrumVisor.Controllers
{
    public class ConfigTransformController : IInputFormController
    {
        private AppModel model;
        private InputFormView typeView;
        private InputFormView paramsView;

        public ConfigTransformController(AppModel appModel)
        {
            model = appModel;
            typeView = new InputFormView(this, new TransformTypeContext(model.Transformation.GetWindowType()));
            paramsView = new InputFormView(this, new TransformContext(model.Transformation.GetTransformConfigs()));
        }

        public void Config()
        {
            typeView.View();
        }

        public void Send(IInputFormParameters parameters)
        {
            if (parameters is TransformTypeParameters)
            {
                var typePar = (parameters as TransformTypeParameters);
                model.Transformation.SetWindowType(typePar.Type.GetValue());
                
                if (typePar.Type.GetValue() == WindowType.NoWin)
                {
                    paramsView = new InputFormView(this, new TransformContext(model.Transformation.GetTransformConfigs()));
                }
                else
                {
                    if (model.Transformation.GetTransformConfigs() is WindowedTransformStuff)
                    {
                        var stuff = model.Transformation.GetTransformConfigs() as WindowedTransformStuff;
                        paramsView = new InputFormView(this, new WindowTransformContext(stuff));
                    }
                    else
                    {
                        var stuff = new WindowedTransformStuff(model.Transformation.GetTransformConfigs());
                        paramsView = new InputFormView(this, new WindowTransformContext(stuff));
                    }
                }
                paramsView.View();
            }
            else if (parameters is WindowTransformParameters)
            {
                var par = parameters as WindowTransformParameters;
                model.Transformation.SetConfigs(new WindowedTransformStuff(par.Start.GetValue(), par.Step.GetValue(), par.Count.GetValue(),
                                                                           par.WinSize.GetValue(), par.WinStep.GetValue()));
            }
            else if (parameters is TransformParameters)
            {
                var par = parameters as TransformParameters;
                model.Transformation.SetConfigs(new TransformStuff(par.Start.GetValue(), par.Step.GetValue(), par.Count.GetValue()));
            }else
            {
                throw new FormatException("Parameters aren't transform configurations!");
            }
        }
    }
}
