using Inventor;

namespace Machine
{
    /// <summary>
    /// Класс для построения дозатора
    /// </summary>
    public class Batcher : Element
    {

        #region Fields

        //Переключатель

        /// <summary>
        /// Переменная, хранящая значение радиуса переключателя
        /// </summary>
        private readonly double _switcherRadius;

        //Дозатор

        /// <summary>
        /// Переменная, хранящая значение длины дозатора
        /// </summary>
        private readonly double _batcherLength;

        /// <summary>
        /// Переменная, хранящая значение ширины дозатора
        /// </summary>
        private readonly double _batcherWidth;

        /// <summary>
        /// Переменная, хранящая значение высоты дозатора
        /// </summary>
        private readonly double _batcherHeight;

        /// <summary>
        /// Переменная, хранящая значение скругления дозатора
        /// </summary>
        private readonly double _batcherCoupling;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Batcher. Переносит параметры из класса Data
        /// </summary>
        public Batcher(double batcherLength, double batcherWidth, double batcherHeight, double batcherCoupling, 
            double switcherRadius, double corpsLength, double corpsWidth, double corpsHeight) : base(corpsLength, corpsWidth, corpsHeight)
        {
            _batcherLength = batcherLength;
            _batcherWidth = batcherWidth;
            _batcherHeight = batcherHeight;
            _batcherCoupling = batcherCoupling;
            _switcherRadius = switcherRadius;
        }

        /// <summary>
        /// Метод, выполняющий построение дозатора
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "constructionMachine">Объект класса используемый для выдавливания и скругления по готовому эскизу</para>
        public override void AddElement(OptionsInventor optionsInventor, Construction constructionMachine)
        {
            PlanarSketch sketch = default(PlanarSketch);

            sketch = PlanarSketchArray(optionsInventor, CorpsLength, -CorpsWidth, 0, CorpsLength, CorpsWidth, 0,
                CorpsLength, CorpsWidth, -CorpsHeight);

            constructionMachine.DrawRectangle(sketch, optionsInventor, 
                CorpsWidth/2 - _batcherWidth * 0.5, 2*_switcherRadius - _batcherHeight/2,
                CorpsWidth/2 + _batcherWidth * 0.5, 2*_switcherRadius + _batcherHeight/2);

            constructionMachine.Construct(optionsInventor.CompDefenition(), sketch, _batcherLength, _batcherCoupling);

            Extrude = constructionMachine.Extrude();
            Fillet = constructionMachine.Fillet();

        }
     
        #endregion

    }
}
