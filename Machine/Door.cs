using Inventor;

namespace Machine
{
    /// <summary>
    /// Класс построения дверки
    /// </summary>
    public class Door : Element
    {

        #region Fields

        //Дверка

        /// <summary>
        /// Переменная, хранящая значение скругления дверки
        /// </summary>
        private readonly double _doorCoupling;

        /// <summary>
        /// Переменная, хранящая значение длины дверки
        /// </summary>
        private readonly double _doorLength;

        /// <summary>
        /// Переменная, хранящая значение радиуса дверки
        /// </summary>
        private readonly double _doorRadius;

        /// <summary>
        /// Переменная, хранящая значение радиуса отверстия
        /// </summary>
        private readonly double _drumRadius;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Door. Переносит параметры из класса Data
        /// </summary>
        public Door(double doorLength, double doorRadius, double drumRadius, double doorCoupling, double corpsLength, 
            double corpsWidth, double corpsHeight) : base(corpsLength, corpsWidth, corpsHeight)
        {

            _doorLength = doorLength;
            _doorRadius = doorRadius;
            _drumRadius = drumRadius;
            _doorCoupling = doorCoupling;

        }

        /// <summary>
        /// Метод, выполняющий построение дверки
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "constructionMachine">Объект класса используемый для выдавливания и скругления по готовому эскизу</para>
        public override void AddElement(OptionsInventor optionsInventor, Construction constructionMachine)
        {

            PlanarSketch sketch = default(PlanarSketch);

            sketch = PlanarSketchArray(optionsInventor, CorpsLength, -CorpsWidth, 0, CorpsLength, CorpsWidth, 0,
                CorpsLength, CorpsWidth, -CorpsHeight);

            constructionMachine.DrawCircle(sketch, optionsInventor, CorpsWidth, CorpsHeight/2, _doorRadius);
            constructionMachine.DrawCircle(sketch, optionsInventor, CorpsWidth, CorpsHeight/2, _drumRadius);

            constructionMachine.Construct(optionsInventor.CompDefenition(), sketch, _doorLength, _doorCoupling);

            Extrude = constructionMachine.Extrude();
            Fillet = constructionMachine.Fillet();

        }
        
        #endregion

    }
}
