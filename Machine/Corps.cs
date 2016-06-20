using Inventor;

namespace Machine
{
    /// <summary>
    /// Класс для построения корпуса
    /// </summary>
    public class Corps : Element
    {

        #region Fields

        //Корпус

        /// <summary>
        /// Переменная, хранящая знечание скругления корпуса
        /// </summary>
        private readonly double _corpsCoupling;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Corps. Переносит параметры корпуса из класса Data
        /// </summary>
        public Corps(double corpsLength, double corpsWidth, double corpsHeight, 
            double corpsCoupling) : base(corpsLength, corpsWidth, corpsHeight)
        {
            _corpsCoupling = corpsCoupling;
            CorpsWidth = corpsWidth;
        }

        /// <summary>
        /// Метод, выполняющий построение корпуса
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "constructionMachine">Объект класса используемый для выдавливания и скругления по готовому эскизу</para>
        public override void AddElement(OptionsInventor optionsInventor, Construction constructionMachine)
        {
            Sketch = optionsInventor.CompDefenition().Sketches.Add(optionsInventor.CompDefenition().WorkPlanes[3]);

            constructionMachine.DrawRectangle(Sketch, optionsInventor, 
                -CorpsLength,-CorpsWidth, CorpsLength, CorpsWidth);

            constructionMachine.Construct(optionsInventor.CompDefenition(), Sketch, CorpsHeight, _corpsCoupling);
            Extrude = constructionMachine.Extrude();
            Fillet = constructionMachine.Fillet();
        }

        #endregion

    }
}
