using Inventor;

namespace Machine
{
    /// <summary>
    /// Класс построения ножек
    /// </summary>
    public class Switcher : Element
    {

        #region Fields

        //Переключатель

        /// <summary>
        /// Переменная, хранящая значение скругления переключателя
        /// </summary>
        private readonly double _switcherCoupling;

        /// <summary>
        /// Переменная, хранящая значение длины переключаетля
        /// </summary>
        private readonly double _switcherLength;

        /// <summary>
        /// Переменная, хранящая значение радиуса переключателя
        /// </summary>
        private readonly double _switcherRadius;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Switcher. Переносит параметры из класса Data
        /// </summary>
        public Switcher(double switcherLength, double switcherRadius, double switcherCoupling, double corpsLength, double corpsWidth,
            double corpsHeight) : base(corpsLength, corpsWidth, corpsHeight)
        {
            _switcherLength = switcherLength;
            _switcherRadius = switcherRadius;
            _switcherCoupling = switcherCoupling;
        }

        /// <summary>
        /// Методы выполняющий построение спинки стула.
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "constructionMachine">Объект класса используемый для выдавливания и скругления по готовому эскизу</para>
        public override void AddElement(OptionsInventor optionsInventor, Construction constructionMachine)
        {

            PlanarSketch sketch = default(PlanarSketch);

            sketch = PlanarSketchArray(optionsInventor, CorpsLength, -CorpsWidth, 0, CorpsLength, CorpsWidth, 0,
                CorpsLength, CorpsWidth, -CorpsHeight);

            constructionMachine.DrawCircle(Sketch, optionsInventor,
                CorpsWidth, 2 * _switcherRadius, _switcherRadius);

            //Выдавливание и скругление 
            constructionMachine.Construct(optionsInventor.CompDefenition(), sketch, _switcherLength, _switcherCoupling);

            Extrude = constructionMachine.Extrude();
            Fillet = constructionMachine.Fillet();

        }


        #endregion

    }
}
