
namespace Machine
{
    /// <summary>
    /// Класс создания нового проекта
    /// </summary>
    public class WasherBuilder
    {
        #region Fields

        /// <summary>
        /// Создание экземпляра класса для построения стиральной машины
        /// </summary>
        private Construction _constructionMachine;

        /// <summary>
        /// Создание экземпляра класса для построения корпуса
        /// </summary>
        private Corps _corpsSketch;

        /// <summary>
        /// Создание экземпляра класса для построения ножек
        /// </summary>
        private Legs _legsSketch;

        /// <summary>
        /// Создание экземпляра класса для построения дверки
        /// </summary>
        private Door _doorSketch;

        /// <summary>
        /// Создание экземпляра класса для построения переключателя
        /// </summary>
        private Switcher _swithcerSketch;

        /// <summary>
        /// Создание экземпляра класса для построения кнпок
        /// </summary>
        private Buttons _buttonsSketch;

        /// <summary>
        /// Создание экземпляра класса для построения дозатора
        /// </summary>
        private Batcher _batcherSketch;

        /// <summary>
        /// Создание экземпляра класса для отверстий
        /// </summary>
        private Airing _airingSketch;

        /// <summary>
        /// Создание экземпляра класса для хранения переменных Inventor
        /// </summary>
        private readonly OptionsInventor _optionsInventor;

        /// <summary>
        /// Переменная, для проверки построения стиральной машины
        /// </summary>
        private bool _machineBuit;

        /// <summary>
        /// Переменная, для проверки существования отверстий
        /// </summary>
        private bool _airingExist;

        /// <summary>
        /// Создание экземпляра класса Data
        /// </summary>
        private Data _dataStorage;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор класса WasherBuilder. Создает новый объект класса OptionsInventor
        /// </summary>
        public WasherBuilder()
        {

            _machineBuit = false;
            _optionsInventor = new OptionsInventor();

        }

        /// <summary>
        /// Создание объектов классов для построения стиральной машины
        /// </summary>
        /// <para name = "dataStorage">Объект класса Data, хранящий значение переменных</para>
        /// <para name = "airingExist">Переменная, хранящая информацию о сувществовании отверстий</para>
        public void NewProjectCreate(Data dataStorage, bool airingExist)
        {
            _dataStorage = dataStorage;
            _airingExist = airingExist;
            if (_optionsInventor.ThisApplication() != null)
            {
                _constructionMachine = new Construction();

                _corpsSketch = new Corps(_dataStorage.CorpsLenght, _dataStorage.CorpsWidth, _dataStorage.CorpsHeight, 
                    _dataStorage.CorpsCoupling);

                _legsSketch = new Legs(_dataStorage.LegsHeight, _dataStorage.LegsRadius, _dataStorage.LegsCoupling, 
                    _dataStorage.CorpsLenght, _dataStorage.CorpsWidth, _dataStorage.CorpsHeight);

                _doorSketch = new Door(_dataStorage.DoorLength, _dataStorage.DoorRadius, _dataStorage.DrumRadius,
                    _dataStorage.DoorCoupling, _dataStorage.CorpsLenght, _dataStorage.CorpsWidth, _dataStorage.CorpsHeight);

                _swithcerSketch = new Switcher(_dataStorage.SwitcherLength, _dataStorage.SwitcherRadius, _dataStorage.ButtonsCoupling, 
                    _dataStorage.CorpsLenght, _dataStorage.CorpsWidth, _dataStorage.CorpsHeight);

                _buttonsSketch = new Buttons(_dataStorage.ButtonsLength, _dataStorage.ButtonsRadius, _dataStorage.ButtonsCoupling, 
                    _dataStorage.SwitcherRadius, _dataStorage.CorpsLenght, _dataStorage.CorpsWidth,
                    _dataStorage.CorpsHeight);

                _batcherSketch = new Batcher(_dataStorage.BatcherLenght, _dataStorage.BatcherWidth, _dataStorage.BatcherHeight, 
                    _dataStorage.BatcherCoupling, _dataStorage.SwitcherRadius, _dataStorage.CorpsLenght, _dataStorage.CorpsWidth, 
                    _dataStorage.CorpsHeight);

                if (_airingExist)
                {
                    _airingSketch = new Airing(_dataStorage.AiringCount, _dataStorage.AiringLength, 
                        _dataStorage.AiringRadius, _dataStorage.AiringCoupling, _dataStorage.CorpsLenght, 
                        _dataStorage.CorpsWidth, _dataStorage.CorpsHeight);  
                }
                
            }

        }

        /// <summary>
        /// Метод выполняющий построение стиральной машины
        /// </summary>
        public void CreatingMachine()
        {

            _corpsSketch.AddElement(_optionsInventor, _constructionMachine);
            _legsSketch.AddElement(_optionsInventor, _constructionMachine);
            _doorSketch.AddElement(_optionsInventor, _constructionMachine);
            _swithcerSketch.AddElement(_optionsInventor, _constructionMachine);
            _buttonsSketch.AddElement(_optionsInventor, _constructionMachine);
            _batcherSketch.AddElement(_optionsInventor, _constructionMachine);

            if (_airingExist)
            {
                _airingSketch.AddElement(_optionsInventor, _constructionMachine);
            }

            _machineBuit = true;

        }

        /// <summary>
        /// Метод выполняющий удаление стиральной машины
        /// </summary>
        public void DeleteMachine()
        {

            if (_machineBuit)
            {
                if (_airingExist)
                {
                    _airingSketch.DeleteElement(_dataStorage.AiringCoupling);
                }
                _batcherSketch.DeleteElement(_dataStorage.BatcherCoupling);
                _buttonsSketch.DeleteElement(_dataStorage.ButtonsCoupling);
                _swithcerSketch.DeleteElement(_dataStorage.ButtonsCoupling);
                _doorSketch.DeleteElement(_dataStorage.DoorCoupling);
                _legsSketch.DeleteElement(_dataStorage.LegsCoupling);
                _corpsSketch.DeleteElement(_dataStorage.CorpsCoupling);
            }
            _machineBuit = true;

        }

        #endregion
    }
}