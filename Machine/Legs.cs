using Inventor;

namespace Machine
{
    /// <summary>
    /// Класс построения ножек
    /// </summary>
    public class Legs : Element
    {

        #region Fields

        //Ножки

        /// <summary>
        /// Переменная, хранящая значение скругления
        /// </summary>
        private readonly double _legsCoupling;

        /// <summary>
        /// Переменная, хранящая значение длины ножек
        /// </summary>
        private readonly double _legsLength;

        /// <summary>
        /// Переменная, хранящая значение радиуса ножек
        /// </summary>
        private readonly double _legsRadius;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Legs. Переносит параметры из класса Data
        /// </summary>
        public Legs(double legsLength, double legsRadius, double legsCoupling, double corpsLength, 
            double corpsWidth, double corpsHeight) : base(corpsLength, corpsWidth, corpsHeight)
        {
            _legsLength = legsLength;
            _legsRadius = legsRadius;
            _legsCoupling = legsCoupling;
        }

        /// <summary>
        /// Методы выполняющий построение ножек.
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "constructionMachine">Объект класса используемый для выдавливания и скругления по готовому эскизу</para>
        public override void AddElement(OptionsInventor optionsInventor, Construction constructionMachine)
        {
            PlanarSketch sketch = default(PlanarSketch);

            sketch = PlanarSketchArray(optionsInventor, CorpsLength, -CorpsWidth, -CorpsHeight, CorpsLength, CorpsWidth, -CorpsHeight, -CorpsLength, CorpsWidth, -CorpsHeight);

            constructionMachine.DrawCircle(sketch, optionsInventor,
                2 * _legsRadius, 2 * _legsRadius, _legsRadius);

            constructionMachine.DrawCircle(sketch, optionsInventor,
                2 * CorpsWidth - 2 * _legsRadius, 2 * _legsRadius, _legsRadius);

            constructionMachine.DrawCircle(sketch, optionsInventor,
               2 * _legsRadius, CorpsLength*2 - 2 * _legsRadius, _legsRadius);

            constructionMachine.DrawCircle(sketch, optionsInventor,
                2 * CorpsWidth - 2 * _legsRadius, CorpsLength * 2 - 2 * _legsRadius, _legsRadius);

            constructionMachine.Construct(optionsInventor.CompDefenition(), sketch, _legsLength, _legsCoupling);

            Extrude = constructionMachine.Extrude();
            Fillet = constructionMachine.Fillet();
        }

        #endregion

    }
}
