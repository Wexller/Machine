using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Machine
{
    public partial class MachineBuilderForm : Form
    {
        /// <summary>
        /// Параметры модели
        /// </summary>
        private Data _dataStorage;

        /// <summary>
        /// Новый проект
        /// </summary>
        private WasherBuilder _newProject;

        /// <summary>
        /// Название САПР
        /// </summary>
        private string _programmName = "Inventor";

        /// <summary>
        /// Проверка существования модели
        /// </summary>
        private bool _modelIs = false;

        /// <summary>
        /// Построение отверстия
        /// </summary>
        private bool _airingChanged;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MachineBuilderForm()
        {
            InitializeComponent();
            airingCount.Enabled = false;
            airingLength.Enabled = false;
            airingRadius.Enabled = false;
            airingCoupling.Enabled = false;
        }

        /// <summary>
        /// Создание нового проекта
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void RunInventorButton_Click(object sender, EventArgs e)
        {
        
            if (Process.GetProcessesByName(_programmName).Any() == false)
            {
                Process.Start(_programmName);
            }
            else
            {
                MessageBox.Show(@"Инвентор уже запущен!");
            }
            
        }

        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (Process.GetProcessesByName(_programmName).Any())
            {
                _dataStorage = new Data();
                SetData();
                _newProject = new WasherBuilder();
                _newProject.NewProjectCreate(_dataStorage, _airingChanged);
                _newProject.CreatingMachine();
                _modelIs = true;
            }
            else
            {
                MessageBox.Show(@"Инвентор не запущен!");
            }

        }
        
        /// <summary>
        /// Метод, записывающий данные
        /// </summary>
        private void SetData()
        {
            //Запись данных о корпусе
            _dataStorage.CorpsLenght = Convert.ToDouble(corpsLength.Value);
            _dataStorage.CorpsWidth = Convert.ToDouble(corpsWidth.Value);
            _dataStorage.CorpsHeight = Convert.ToDouble(corpsHeight.Value);
            _dataStorage.CorpsCoupling = Convert.ToDouble(corpsCoupling.Value);

            //Запись данных о ножках
            _dataStorage.LegsHeight = Convert.ToDouble(legsHeight.Value);
            _dataStorage.LegsRadius = Convert.ToDouble(legsRadius.Value);
            _dataStorage.LegsCoupling = Convert.ToDouble(legsCoupling.Value);

            //Запись данных о дверке
            _dataStorage.DoorLength = Convert.ToDouble(doorLength.Value);
            _dataStorage.DoorRadius = Convert.ToDouble(doorRadius.Value);
            _dataStorage.DoorCoupling = Convert.ToDouble(doorCoupling.Value);
            _dataStorage.DrumRadius = Convert.ToDouble(drumRadius.Value);

            //Запись данных о кнопках
            _dataStorage.SwitcherRadius = Convert.ToDouble(switcherRadius.Value);
            _dataStorage.SwitcherLength = Convert.ToDouble(switcherLength.Value);
            _dataStorage.ButtonsLength = Convert.ToDouble(buttonsLength.Value);
            _dataStorage.ButtonsRadius = Convert.ToDouble(buttonsRadius.Value);
            _dataStorage.ButtonsCoupling = Convert.ToDouble(buttonsCoupling.Value);

            //Запись данных о дозаторе
            _dataStorage.BatcherLenght = Convert.ToDouble(batcherLength.Value);
            _dataStorage.BatcherWidth = Convert.ToDouble(batcherWidth.Value);
            _dataStorage.BatcherHeight = Convert.ToDouble(batcherHeight.Value);
            _dataStorage.BatcherCoupling = Convert.ToDouble(batcherCoupling.Value);

            //Запись данных о отверстии
            if (_airingChanged)
            {
                _dataStorage.AiringCount = Convert.ToDouble(airingCount.Value);
                _dataStorage.AiringLength = Convert.ToDouble(airingLength.Value);
                _dataStorage.AiringRadius = Convert.ToDouble(airingRadius.Value);
                _dataStorage.AiringCoupling = Convert.ToDouble(airingCoupling.Value);
            }

        }
        
        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void deleteModel_Click(object sender, EventArgs e)
        {
            if (_modelIs && (_newProject != null) && Process.GetProcessesByName(_programmName).Any())
            {
                _newProject.DeleteMachine();
                _modelIs = false;
            }
            else
            {
                MessageBox.Show(@"Постройте модель!");
            }
            
        }

        private void airing_CheckedChanged(object sender, EventArgs e)
        {
            if (airing.Checked)
            {
                _airingChanged = true;
                airingCount.Enabled = true;
                airingLength.Enabled = true;
                airingRadius.Enabled = true;
                airingCoupling.Enabled = true;
            }
            else
            {
                _airingChanged = false;
                airingCount.Enabled = false;
                airingLength.Enabled = false;
                airingRadius.Enabled = false;
                airingCoupling.Enabled = false;
            }
        }
    }
}
