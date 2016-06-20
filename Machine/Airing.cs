using Inventor;

namespace Machine
{
    public class Airing : Element
    {
        #region Fields

        //Дверка

        /// <summary>
        /// Переменная, хранящая значение количества отверстий
        /// </summary>
        private readonly double _airingCount;

        /// <summary>
        /// Переменная, хранящая значение длины отверстий
        /// </summary>
        private readonly double _airingLength;

        /// <summary>
        /// Переменная, хранящая значение радиуса отверстий
        /// </summary>
        private readonly double _airingRadius;

        /// <summary>
        /// Переменная, хранящая значение скругления отверстий
        /// </summary>
        private readonly double _airingCoupling;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Airing. Переносит параметры из класса Data
        /// </summary>
        public Airing(double airingCount, double airingLength, double airingRadius, double airingCoupling, double corpsLength,
            double corpsWidth, double corpsHeight) : base(corpsLength, corpsWidth, corpsHeight)
        {
            _airingCount = airingCount;
            _airingLength = airingLength;
            _airingRadius = airingRadius;
            _airingCoupling = airingCoupling;
        }

        /// <summary>
        /// Метод,выполняющий построение отверстий
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "constructionMachine">Объект класса используемый для выдавливания и скругления по готовому эскизу</para>
        public override void AddElement(OptionsInventor optionsInventor, Construction constructionMachine)
        {

            PlanarSketch sketch = default(PlanarSketch);

            sketch = PlanarSketchArray(optionsInventor, CorpsLength, -CorpsWidth, 0, -CorpsLength, -CorpsWidth, 0, -CorpsLength, -CorpsWidth, -CorpsHeight);

            double drumsRangeConst = 2 * CorpsLength / (_airingCount + 1);
            double drumsRange = drumsRangeConst;
            
            for (int i = 0; i < _airingCount; i++)
            {
                constructionMachine.DrawCircle(sketch, optionsInventor, drumsRange, CorpsHeight * 0.2, _airingRadius);
                drumsRange += drumsRangeConst;
            }
              
            constructionMachine.CutExtrude(optionsInventor.CompDefenition(), sketch, _airingLength, _airingCoupling);

            Extrude = constructionMachine.Extrude();
            Fillet = constructionMachine.Fillet();

        }

        #endregion
    }
}
