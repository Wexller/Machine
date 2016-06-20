using Inventor;

namespace Machine
{
    public abstract class Element
    {
        #region Fields

        /// <summary>
        /// Переменная, хранящая ссылку на текущий эскиз.
        /// </summary>
        protected PlanarSketch Sketch = default(PlanarSketch);

        /// <summary>
        /// Переменная, хранящая ссылку на выдавленный объект
        /// </summary>
        protected ExtrudeFeature Extrude = default(ExtrudeFeature);

        /// <summary>
        /// Массив, хранящая ссылку на новую рабочую плоскость
        /// </summary>
        protected WorkPoint[] WorkPoint = new WorkPoint[3];

        /// <summary>
        /// Массив, для хранения рабочих точек
        /// </summary>
        protected WorkPlane WorkPlane = default(WorkPlane);

        /// <summary>
        /// Переменная, хранящая ссылку на сопряжение объекта
        /// </summary>
        protected FilletFeature Fillet = default(FilletFeature);

        /// <summary>
        /// Переменная, хранящая ссылку на длину корпуса
        /// </summary>
        protected double CorpsLength;

        /// <summary>
        /// Переменная, хранящая ссылку на ширину корпуса
        /// </summary>
        protected double CorpsWidth;

        /// <summary>
        /// Переменная, хранящая ссылку на высоту
        /// </summary>
        protected double CorpsHeight;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса Element. Переносит параметры из класса Data
        /// </summary>
        protected Element(double corpsLength, double corpsWidth, double corpsHeight)
        {
            CorpsHeight = corpsHeight;
            CorpsLength = corpsLength;
            CorpsWidth = corpsWidth;
        }

        public abstract void AddElement(OptionsInventor optionsInventor, Construction constructionMachine);

        /// <summary>
        /// Метод, выполняющий удаление
        /// </summary>
        public void DeleteElement(double coupling)
        {

            Extrude.Delete();
            if (WorkPlane != null)
            {
                WorkPlane.Delete();
            }
            
            for (int i = 0; i < WorkPoint.LongLength; i++)
            {
                if (WorkPoint[i] != null)
                {
                    WorkPoint[i].Delete();
                }
                }

            if (coupling != 0)
            {
                Fillet.Delete();
            }
        }

        /// <summary>
        /// Метод, создающий новую рабочую плоскость
        /// </summary>
        /// <para name = "optionsInventor">Объект класса хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "xCoord1">Переменная, хранящая точку X1</para>
        /// <para name = "yCoord1">Переменная, хранящая точку Y1</para>
        /// <para name = "zCoord1">Переменная, хранящая точку Z1</para>
        /// <para name = "xCoord2">Переменная, хранящая точку X2</para>
        /// <para name = "yCoord2">Переменная, хранящая точку Y2</para>
        /// <para name = "zCoord2">Переменная, хранящая точку Z2</para>
        /// <para name = "xCoord3">Переменная, хранящая точку X3</para>
        /// <para name = "yCoord3">Переменная, хранящая точку Y3</para>
        /// <para name = "zCoord3">Переменная, хранящая точку Z3</para>
        /// <returns>_sketch</returns>
        public PlanarSketch PlanarSketchArray(OptionsInventor optionsInventor, 
            double xCoord1, double yCorrd1, double zCoord1, 
            double xCoord2, double yCorrd2, double zCoord2, 
            double xCoord3, double yCorrd3, double zCoord3)
        {

            TransientGeometry transientGeometry = default(TransientGeometry);

            transientGeometry = optionsInventor.ThisApplication().TransientGeometry;

            WorkPoint[0] = optionsInventor.CompDefenition().WorkPoints.AddFixed
                (transientGeometry.CreatePoint(xCoord1, yCorrd1, zCoord1));
            
            WorkPoint[1] = optionsInventor.CompDefenition().WorkPoints.AddFixed
                (transientGeometry.CreatePoint(xCoord2, yCorrd2, zCoord2));

            WorkPoint[2] = optionsInventor.CompDefenition().WorkPoints.AddFixed
                (transientGeometry.CreatePoint(xCoord3, yCorrd3, zCoord3));

            for (int i = 0; i < 3; i++)
            {
                WorkPoint[i].Visible = false;
            }

            WorkPlane = optionsInventor.CompDefenition().WorkPlanes.AddByThreePoints
                (WorkPoint[0], WorkPoint[1], WorkPoint[2]);
            WorkPlane.Visible = false;
            Sketch = optionsInventor.CompDefenition().Sketches.Add(WorkPlane);

            return Sketch;
        }

        #endregion

    }
}
