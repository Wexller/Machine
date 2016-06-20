using System;

namespace Machine
{
    /// <summary>
    /// Класс для ввода данных для дальнейшго построения стриальной машины
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Перечисление операторов
        /// </summary>
        private enum Operators
        {
            Less,
            LessOrEqual,
            More
        }

        /// <summary>
        /// Длина корпуса
        /// </summary>
        private double _corpsLenght;
        /// <summary>
        /// Метод, считывающий или возвращающий длину корпуса 
        /// </summary>
        public double CorpsLenght
        {
            get { return _corpsLenght; }
            set
            {
                Check(value, 0, Operators.Less, "Длина корпуса меньше нуля");
                _corpsLenght = value;
            }
        }

        /// <summary>
        /// Ширина корпуса
        /// </summary>
        private double _corpsWidth;
        /// <summary>
        /// Метод, считывающий или возвращающий ширину корпуса 
        /// </summary>
        public double CorpsWidth
        {
            get { return _corpsWidth; }
            set
            {
                Check(value, 0, Operators.Less, "Ширина корпуса меньше нуля");
                _corpsWidth = value;
            }
        }

        /// <summary>
        /// Высота корпуса
        /// </summary>
        private double _corpsHeight;
        /// <summary>
        /// Метод, считывающий или возвращающий высоту корпуса 
        /// </summary>
        public double CorpsHeight
        {
            get { return _corpsHeight; }
            set
            {
                Check(value, 0, Operators.Less, "Высота корпуса меньше нуля");
                _corpsHeight = value;
            }
        }

        /// <summary>
        /// Сопряжение корпуса
        /// </summary>
        private double _corpsCoupling;
        /// <summary>
        /// Метод, считывающий или возвращающий сопряжение корпуса 
        /// </summary>
        public double CorpsCoupling
        {
            get { return _corpsCoupling; }
            set
            {
                Check(value, 0, Operators.Less, "Сопряжение корпуса меньше нуля");
                _corpsCoupling = value;
            }
        }
        
        /// <summary>
        /// Длина ножек
        /// </summary>
        private double _legsHeight;
        /// <summary>
        /// Метод, считывающий или возвращающий длину ножек
        /// </summary>
        public double LegsHeight
        {
            get { return _legsHeight; }
            set
            {

                Check(value, 0, Operators.Less, "Длина ножек меньше нуля");
                Check(value, _corpsHeight * 0.25, Operators.More, "Длина ножек больше 25% от высоты корпуса");
                _legsHeight = value;

            }
        }

        /// <summary>
        /// Радиус ножек
        /// </summary>
        private double _legsRadius;
        /// <summary>
        /// Метод, считывающий или возвращающий радиус ножек
        /// </summary>
        public double LegsRadius
        {
            get { return _legsRadius; }
            set
            {
                {
                    Check(value, 0, Operators.LessOrEqual, "Радиус ножек меньше или равен нулю");
                    Check(value, _corpsWidth * 0.25, Operators.More, "Радиус ножек больше 25% от ширины корпуса");
                    _legsRadius = value;
                }
            }
        }

        /// <summary>
        /// Сопряжение ножек
        /// </summary>
        private double _legsCoupling;
        /// <summary>
        /// Метод, считывающий или возвращающий сопряжение ножек
        /// </summary>
        public double LegsCoupling
        {
            get { return _legsCoupling; }
            set
            {
                {
                    Check(value, 0, Operators.Less, "Сопряжение ножек меньше нуля");
                    _legsCoupling = value;
                }
            }

        }

        /// <summary>
        /// Длина дверки
        /// </summary>
        private double _doorLenght;
        /// <summary>
        /// Метод, считывающий или возвращающий длина дверки
        /// </summary>
        public double DoorLength
        {
            get { return _doorLenght; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Длина дверки меньше или равна нулю");
                Check(value, _corpsLenght * 0.4, Operators.More, "Длина дверки больше 40% от длины корпуса");
                _doorLenght = value;
            }
        }

        /// <summary>
        /// Радиус дверки
        /// </summary>
        private double _doorRadius;
        /// <summary>
        /// Метод, считывающий или возвращающий радиус дверки
        /// </summary>
        public double DoorRadius
        {
            get { return _doorRadius; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Радиус дверки меньше или равен нулю");
                Check(value, _corpsWidth, Operators.More, "Диаметр дверки больше ширины корпуса");
                _doorRadius = value;
            }
        }

        /// <summary>
        /// Радиус отверстия
        /// </summary>
        private double _drumRadius;
        /// <summary>
        /// Метод, считывающий или возвращающий радиус отверстия
        /// </summary>
        public double DrumRadius
        {
            get { return _drumRadius; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Отверстие меньше или равно нулю");
                Check(value, _doorRadius, Operators.More, "Радиус отверстия больше радиуса дверки");
                _drumRadius = value;
            }
        }

        /// <summary>
        /// Сопряжение дверки
        /// </summary>
        private double _doorCoupling;
        /// <summary>
        /// Метод, считывающий или возвращающий сопряжение дверки
        /// </summary>
        public double DoorCoupling
        {
            get { return _doorCoupling; }
            set
            {
                Check(value, 0, Operators.Less, "Сопряжение дверки меньше нуля");
                _doorCoupling = value;
            }

        }
        
        /// <summary>
        /// Длина переключателя
        /// </summary>
        private double _switcherLength;
        /// <summary>
        /// Метод, считывающий или возвращающий длину переключателя
        /// </summary>
        public double SwitcherLength
            {
            get { return _switcherLength; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Длина переключателя меньше или равна нулю");
                Check(value, _corpsLenght * 0.3, Operators.More, "Длина переключателя больше 30% от длины корпуса");
                _switcherLength = value;
            }
        }

        /// <summary>
        /// Радиус переключателя
        /// </summary>
        private double _switcherRadius;
        /// <summary>
        /// Метод, считывающий или возвращающий радиус переключателя
        /// </summary>
        public double SwitcherRadius
        {
            get { return _switcherRadius; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Радиус переключателя меньше или равен нулю");
                Check(value, _corpsWidth *0.25, Operators.More, "Диаметр переключателя больше 25% от ширины корпуса");
                _switcherRadius = value;
            }
        }

        /// <summary>
        /// Длина кнопок
        /// </summary>
        private double _buttonsLength;
        /// <summary>
        /// Метод, считывающий или возвращающий длину кнопок
        /// </summary>
        public double ButtonsLength
        {
            get { return _buttonsLength; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Длина кнопок меньше или равна нулю");
                Check(value, _corpsLenght * 0.25, Operators.More, "Длина кнопок больше 25% от длины корпуса");
                _buttonsLength = value;
            }
        }

        /// <summary>
        /// Радиус кнопок
        /// </summary>
        private double _buttonsRadius;
        /// <summary>
        /// Метод, считывающий или возвращающий радиус кнопок
        /// </summary>
        public double ButtonsRadius
        {
            get { return _buttonsRadius; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Радиус кнопок меньше или равен нулю");
                Check(value, _corpsWidth * 0.15, Operators.More, "Диаметр кнопок больше 15% от ширины корпуса");
                _buttonsRadius = value;
            }
        }

        /// <summary>
        /// Сопряжение кнопок
        /// </summary>
        private double _buttonsCoupling;
        /// <summary>
        /// Метод, считывающий или возвращающий сопряжение кнопок
        /// </summary>
        public double ButtonsCoupling
        {
            get { return _buttonsCoupling; }
            set
            {
                Check(value, 0, Operators.Less, "Сопряжение кнопок меньше нуля");
                _buttonsCoupling = value;
            }

        }

        /// <summary>
        /// Длина дозатора
        /// </summary>
        private double _batcherLenght;
        /// <summary>
        /// Метод, считывающий или возвращающий длину дозатора
        /// </summary>
        public double BatcherLenght
        {
            get { return _batcherLenght; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Длина дозатора меньше или равна нулю");
                Check(value, _corpsLenght * 0.25, Operators.More, "Длина дозатора больше 25% от длины корпуса");
                _batcherLenght = value;
            }
        }

        /// <summary>
        /// Ширина дозатора
        /// </summary>
        private double _batcherWidth;
        /// <summary>
        /// Метод, считывающий или возвращающий ширину дозатора
        /// </summary>
        public double BatcherWidth
        {
            get { return _batcherWidth; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Ширина дозатора меньше или равна нулю");
                Check(value, _corpsWidth * 0.8, Operators.More, "Ширина дозатора больше 40% от ширины корпуса");
                _batcherWidth = value;
            }
        }

        /// <summary>
        /// Высота дозатора
        /// </summary>
        private double _batcherHeight;
        /// <summary>
        /// Метод, считывающий или возвращающий высоту дозатора
        /// </summary>
        public double BatcherHeight
        {
            get { return _batcherHeight; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Высота дозатора меньше или равна нулю");
                Check(value, _corpsHeight * 0.2, Operators.More, "Высота дозатора больше 20% от высоты корпуса");
                _batcherHeight = value;
            }
        }

        /// <summary>
        /// Сопряжение дозатора
        /// </summary>
        private double _batcherCoupling;
        /// <summary>
        /// Метод, считывающий или возвращающий сопряжение дозатора
        /// </summary>
        public double BatcherCoupling
        {
            get { return _batcherCoupling; }
            set
            {
                Check(value, 0, Operators.Less, "Сопряжение дозатора меньше нуля");
                _batcherCoupling = value;
            }
        }

        /// <summary>
        /// Количетво отверстий
        /// </summary>
        private double _airingCount;
        /// <summary>
        /// Метод, считывающий или возвращающий количество отверстий
        /// </summary>
        public double AiringCount
        {
            get { return _airingCount; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Количество отверстий меньше или равно нулю");
                _airingCount = value;
            }
        }

        /// <summary>
        /// Длина отверстий
        /// </summary>
        private double _airingLength;
        /// <summary>
        /// Метод, считывающий или возвращающий длину отверстий
        /// </summary>
        public double AiringLength
        {
            get { return _airingLength; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Длина отверстий меньше или равна нулю");
                Check(value, _corpsWidth * 0.2, Operators.More, "Длина отверстий больше 20% от ширины корпуса");
                _airingLength = value; 
                
            }
        }

        /// <summary>
        /// Радиус отверстий
        /// </summary>
        private double _airingRadius;
        /// <summary>
        /// Метод, считывающий или возвращающий радиус отверстий
        /// </summary>
        public double AiringRadius
        {
            get { return _airingRadius; }
            set
            {
                Check(value, 0, Operators.LessOrEqual, "Радиус отверстий меньше или равен нулю");
                Check(value, _corpsLenght * 0.25, Operators.More, "Радиус отверстий больше 25% от длины корпуса");
                _airingRadius = value; 
                
            }
        }

        /// <summary>
        /// Радиус отверстий
        /// </summary>
        private double _airingCoupling;
        /// <summary>
        /// Метод, считывающий или возвращающий скругление отверстий
        /// </summary>
        public double AiringCoupling
        {
            get { return _airingCoupling; }
            set
            {
                Check(value, 0, Operators.Less, "Сопряжение отверстий меньше нуля");
                _airingCoupling = value; 
                
            }
        }

        /// <summary>
        /// Метод, делающий проверку внесенных данных
        /// </summary>
        /// <para name = "value1">Первая переменная для сравнения</para>
        /// <para name = "value2">Вторая переменная для сравнения</para>
        /// <para name = "operation">Оператор сравнения</para>
        /// <para name = "text">Текст ошибки</para>
        private void Check(double value1, double value2, Operators operation, string text)
        {
            switch (operation)
            {
                case Operators.Less:
                    if (value1 < value2)
                    {
                        throw new ArgumentException(text);
                    }
                    break;

                case Operators.LessOrEqual:
                    if (value1 <= value2)
                    {
                        throw new ArgumentException(text);
                    }
                    break;

                case Operators.More:
                    if (value1 > value2)
                    {
                        throw new ArgumentException(text);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }
    }
}