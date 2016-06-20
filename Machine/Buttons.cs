using Inventor;

namespace Machine
{
    /// <summary>
    /// Класс для построения кнопок
    /// </summary>
    public class Buttons : Element
    {
        #region Fields
        
        //Переключатель

        /// <summary>
        /// Переменная, хранящая значение радиуса переключателя
        /// </summary>
        private readonly double _switcherRadius;

        //Кнопки

        /// <summary>
        /// Переменная, хранящая значение длины кнопок
        /// </summary>
        private readonly double _buttonsLength;

        /// <summary>
        /// Переменная, хранящая значение радиуса кнопок
        /// </summary>
        private readonly double _buttonsRadius;

        /// <summary>
        /// Переменная, хранящая значение скругления.
        /// </summary>
        private readonly double _buttonsCoupling;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Buttons. Переносит параметры из класса Data
        /// </summary>
        public Buttons(double buttonsLength, double buttonsRadius, double buttonsCoupling, double switcherRadius, 
            double corpsLength, double corpsWidth, double corpsHeight) : base(corpsLength, corpsWidth, corpsHeight)
        {
            _buttonsLength = buttonsLength;
            _buttonsRadius = buttonsRadius;
            _buttonsCoupling = buttonsCoupling;
            _switcherRadius = switcherRadius;
        }

        /// <summary>
        /// Метод, выполняющий построение кнопок
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "constructionMachine">Объект класса используемый для выдавливания и скругления по готовому эскизу</para>
        public override void AddElement(OptionsInventor optionsInventor, Construction constructionMachine)
        {
            PlanarSketch sketch = default(PlanarSketch);

            sketch = PlanarSketchArray(optionsInventor, CorpsLength, -CorpsWidth, 0, CorpsLength, CorpsWidth, 0,
                CorpsLength, CorpsWidth, -CorpsHeight);

            constructionMachine.DrawCircle(sketch, optionsInventor, 
                CorpsWidth * 1.5 + 1, 2 * _switcherRadius, _buttonsRadius);

            constructionMachine.DrawCircle(sketch, optionsInventor,
                CorpsWidth * 1.25 + 1, 2 * _switcherRadius, _buttonsRadius);

            constructionMachine.DrawCircle(sketch, optionsInventor,
                CorpsWidth * 1.75 + 1, 2 * _switcherRadius, _buttonsRadius);

            constructionMachine.Construct(optionsInventor.CompDefenition(), sketch, _buttonsLength, _buttonsCoupling);

            Extrude = constructionMachine.Extrude();
            Fillet = constructionMachine.Fillet();
        }

        #endregion
    }
}
