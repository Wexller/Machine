using Inventor;

namespace Machine
{
    /// <summary>
    /// Класс для выдавливания и скругления эскиза
    /// </summary>
    public class Construction
    {

        #region Fields

        /// <summary>
        /// Переменная, хранящая ссылку на текущий профиль
        /// </summary>
        private Profile _profile = default(Profile);

        /// <summary>
        /// Переменная, хранящая ссылку на текущий выдавленный объект
        /// </summary>
        private ExtrudeDefinition _extrudeDefinition = default(ExtrudeDefinition);

        /// <summary>
        /// Переменная, использующаяся для выдавливания
        /// </summary>
        private ExtrudeFeature _extrude = default(ExtrudeFeature);

        /// <summary>
        /// Переменная, использующаяся для сопряжения выдавленного объекта
        /// </summary>
        private FilletFeature _fillet = default(FilletFeature);

        /// <summary>
        /// Переменная использующаяся для сопряжения
        /// </summary>
        private readonly EdgeCollection _edges = null;

        #endregion

        #region Methods

        /// <summary>
        /// Метод, выполняющий выдавливание эскиза и скругления его граней
        /// </summary>
        /// <para name = "compDefinition">Переменная хранящая ссылку на обозреватель проекта</para>
        /// <para name = "sketch">Переменная хранящая ссылку на эскиз для выдавливания</para>
        /// <para name = "thickness">Переменная хранящая величину выдавливаниея эскиза</para>
        /// <para name = "rounding">Переменная хранящая величину скругления выдавленного объекта</para>
        public void Construct(PartComponentDefinition compDefinition, PlanarSketch sketch, double length, 
            double rounding)
        {
            _profile = sketch.Profiles.AddForSolid();

            _extrudeDefinition = compDefinition.Features.ExtrudeFeatures.
                CreateExtrudeDefinition(_profile, PartFeatureOperationEnum.kJoinOperation);

            _extrudeDefinition.SetDistanceExtent
                (length, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

            _extrude = compDefinition.Features.ExtrudeFeatures.Add(_extrudeDefinition);

            if (rounding != 0)
            {
                _fillet = compDefinition.Features.FilletFeatures.AddSimple
                    (_edges, rounding, false, true, true, false, true, false);
            }
        }

        /// <summary>
        /// Метод, выполняющий отрицательное выдавливание эскиза и скругления его граней
        /// </summary>
        /// <para name = "compDefinition">Переменная хранящая ссылку на обозреватель проекта</para>
        /// <para name = "sketch">Переменная хранящая ссылку на эскиз для выдавливания</para>
        /// <para name = "thickness">Переменная хранящая величину выдавливаниея эскиза</para>
        /// <para name = "rounding">Переменная хранящая величину скругления выдавленного объекта</para>
        public void CutExtrude(PartComponentDefinition compDefinition, PlanarSketch sketch, double length,
            double rounding)
        {
            _profile = sketch.Profiles.AddForSolid();

            _extrudeDefinition = compDefinition.Features.ExtrudeFeatures.
                CreateExtrudeDefinition(_profile, PartFeatureOperationEnum.kCutOperation);

            _extrudeDefinition.SetDistanceExtent
                (length, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

            _extrude = compDefinition.Features.ExtrudeFeatures.Add(_extrudeDefinition);

            if (rounding != 0)
            {
                _fillet = compDefinition.Features.FilletFeatures.AddSimple
                    (_edges, rounding, false, true, true, false, true, false);
            }
        }

        /// <summary>
        /// Метод, выполняющий построение прямоугольника
        /// </summary>
        /// <para name = "sketch">Переменная, хранящая ссылку на эскиз для построения</para>
        /// <para name = "optionsInventor">Объект класса, хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "xCoord1">Переменная, хранящая точку X1</para>
        /// <para name = "yCoord1">Переменная, хранящая точку Y1</para>
        /// <para name = "xCoord2">Переменная, хранящая точку X2</para>
        /// <para name = "yCoord2">Переменная, хранящая точку Y2</para>
        /// <returns>sketch</returns>
        public PlanarSketch DrawRectangle(PlanarSketch sketch, OptionsInventor optionsInventor, 
            double xCoord1, double yCoord1, double xCoord2, double yCoord2)
        {
            sketch.SketchLines.AddAsTwoPointRectangle(
                optionsInventor.ThisApplication().TransientGeometry.CreatePoint2d(xCoord1, yCoord1),
                optionsInventor.ThisApplication().TransientGeometry.CreatePoint2d(xCoord2, yCoord2));

            return sketch;
        }

        /// <summary>
        /// Метод, выполняющий построение круга
        /// </summary>
        /// <para name = "sketch">Переменная, хранящая ссылку на эскиз для построения</para>
        /// <para name = "optionsInventor">Объект класса, хранящий значение переменных для работы с Inventor 2016</para>
        /// <para name = "xCoord">Переменная, хранящая точку X</para>
        /// <para name = "yCoord">Переменная, хранящая точку Y</para>
        /// <para name = "radius">Переменная, хранящая радиус</para>
        /// <returns>sketch</returns>
        public PlanarSketch DrawCircle(PlanarSketch sketch, OptionsInventor optionsInventor,
            double xCoord, double yCoord, double radius)
        {
            sketch.SketchCircles.AddByCenterRadius(
                optionsInventor.ThisApplication().TransientGeometry.CreatePoint2d(xCoord, yCoord), radius);

            return sketch;
        }

        /// <summary>
        /// Метод, возвращающий ссылку на выдавленный объект
        /// </summary>
        /// <returns>_extrude</returns>
        public ExtrudeFeature Extrude()
        {
            return _extrude;
        }

        /// <summary>
        /// Метод, возвращающий ссылку на скругление
        /// </summary>
        /// <returns>_fillet</returns>
        public FilletFeature Fillet()
        {
            return _fillet;
        }

        #endregion

    }
}
