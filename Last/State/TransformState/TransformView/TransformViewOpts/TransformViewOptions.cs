namespace SpectrumVisor
{
    //добавляет преобразованию граф. настройки
    //предназначен для наследования
    public class TransformViewOptions
    {
        //преобразование
        public TransformOptions Options { get; private set; }

        public TransformViewOptions(TransformOptions state)
        {
            Options = state;
        }
    }
}