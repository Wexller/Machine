using System;
using System.Collections.Generic;
using NUnit.Framework;
using Machine;

namespace UnitTests
{
    class NUnitTest
    {
        
        private static Data _testData = new Data();

        private enum _method
        {
            CorpsLength,
            CorpsWidth,
            CorpsHeight,
            CorpsCoupling,
            LegsHeight,
            LegsRadius,
            LegsCoupling,
            DoorLength,
            DoorRadius,
            DrumRadius,
            DoorCoupling,
            SwitcherLength,
            SwitcherRadius,
            ButtonsLength,
            ButtonsRadius,
            ButtonsCoupling,
            BatcherLength,
            BatcherWidth,
            BatcherHeight,
            BatcherCoupling,
        };

        [Test]

        [TestCase(26, 26, TestName = "Тестирование. Длина корпуса = 26. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина корпуса = -10. Негативный")]
        //Тестирование ввода длины корпуса
        public void TestCorpsLength(double count, double result)
        {
            _testData.CorpsLenght = count;
            Assert.AreEqual(result, _testData.CorpsLenght);
        }


        [TestCase(30, 30, TestName = "Тестирование. Ширина корпуса = 30. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Ширина корпуса = -10. Негативный")]
        //Тестирование ввода ширины корпуса
        public void TestCorpsWidth(double count, double result)
        {
            _testData.CorpsWidth = count;
            Assert.AreEqual(result, _testData.CorpsWidth);
        }


        [TestCase(80, 80, TestName = "Тестирование. Высота корпуса = 80. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Высота корпуса = -10. Негативный")]
        //Тестирование ввода высоты корпуса
        public void TestCorpsHeight(double count, double result)
        {
            _testData.CorpsHeight = count;
            Assert.AreEqual(result, _testData.CorpsHeight);

        }


        [TestCase(1, 1, TestName = "Тестирование. Сопряжение корпуса = 1. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Сопряжение  корпуса = -10. Негативный")]
        //Тестирование ввода сопряжения корпуса
        public void TestCorpsCoupling(double count, double result)
        {
            _testData.CorpsCoupling = count;
            Assert.AreEqual(result, _testData.CorpsCoupling);

        }


        [TestCase(5, 5, TestName = "Тестирование. Высота ножек = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Высота ножек = -10. Негативный")]
        [TestCase(80, 80, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Высота ножек = 80. Негативный")]
        //Тестирование ввода высота ножек
        public void TestLegsHeight(double count, double result)
        {
            _testData.CorpsHeight = 80;
            _testData.LegsHeight = count;
            Assert.AreEqual(result, _testData.LegsHeight);
        }


        [TestCase(5, 5, TestName = "Тестирование. Радиус ножек = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус ножек = -10. Негативный")]
        [TestCase(50, 50, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус ножек = 50. Негативный")]
        //Тестирование ввода радиуса ножек
        public void TestLegsRadius(double count, double result)
        {
            _testData.CorpsWidth = 50;
            _testData.LegsRadius = count;
            Assert.AreEqual(result, _testData.LegsRadius);
        }


        [TestCase(1, 1, TestName = "Тестирование. Сопряжение ножек = 1. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Сопряжение  ножек = -10. Негативный")]
        //Тестирование ввода сопряжения ножек
        public void TestLegsCoupling(double count, double result)
        {
            _testData.LegsCoupling = count;
            Assert.AreEqual(result, _testData.LegsCoupling);
        }


        [TestCase(5, 5, TestName = "Тестирование. Длина дверки = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина дверки = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина дверки = 30. Негативный")]
        //Тестирование ввода длины дверки
        public void TestDoorLength(double count, double result)
        {
            _testData.CorpsLenght = 30;
            _testData.DoorLength = count;
            Assert.AreEqual(result, _testData.DoorLength);
        }


        [TestCase(10, 10, TestName = "Тестирование. Радиус дверки = 10. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус дверки = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус дверки = 30. Негативный")]
        //Тестирование ввода радиуса дверки
        public void TestDoorRadius(double count, double result)
        {
            _testData.CorpsWidth = 20;
            _testData.DoorRadius = count;
            Assert.AreEqual(result, _testData.DoorRadius);
        }


        [TestCase(5, 5, TestName = "Тестирование. Радиус отверстия = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус отверстия = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус отверстия = 30. Негативный")]
        //Тестирование ввода радиуса отверстия
        public void TestDrumRadius(double count, double result)
        {
            _testData.CorpsWidth = 30;
            _testData.DoorRadius = 20;
            _testData.DrumRadius = count;
            Assert.AreEqual(result, _testData.DrumRadius);
        }


        [TestCase(1, 1, TestName = "Тестирование. Скругление дверки = 1. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Скругление дверки = -10. Негативный")]
        //Тестирование ввода скругление дверки
        public void TestDoorCoupling(double count, double result)
        {
            _testData.DoorCoupling = count;
            Assert.AreEqual(result, _testData.DoorCoupling);
        }


        [TestCase(5, 5, TestName = "Тестирование. Длина переключателя = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина переключателя = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина переключателя = 30. Негативный")]
        //Тестирование ввода длина переключателя
        public void TestSwitcherLength(double count, double result)
        {
            _testData.CorpsLenght = 30;
            _testData.SwitcherLength = count;
            Assert.AreEqual(result, _testData.SwitcherLength);
        }


        [TestCase(5, 5, TestName = "Тестирование. Радиус переключателя = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус переключателя = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус переключателя = 30. Негативный")]
        //Тестирование ввода радиуса переключателя
        public void TestSwitcherRadius(double count, double result)
        {
            _testData.CorpsWidth = 30;
            _testData.SwitcherRadius = count;
            Assert.AreEqual(result, _testData.SwitcherRadius);
        }


        [TestCase(5, 5, TestName = "Тестирование. Длина кнопок = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина кнопок = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина кнопок = 30. Негативный")]
        //Тестирование ввода длина кнопок
        public void TestButtonsLength(double count, double result)
        {
            _testData.CorpsLenght = 30;
            _testData.ButtonsLength = count;
            Assert.AreEqual(result, _testData.ButtonsLength);
        }


        [TestCase(2, 2, TestName = "Тестирование. Радиус кнопок = 2. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус кнопок = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус кнопок = 30. Негативный")]
        //Тестирование ввода радиуса кнопок
        public void TestButtonsRadius(double count, double result)
        {
            _testData.CorpsWidth = 30;
            _testData.ButtonsRadius = count;
            Assert.AreEqual(result, _testData.ButtonsRadius);
        }


        [TestCase(1, 1, TestName = "Тестирование. Скругление кнопок = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Скругление кнопок = -10. Негативный")]
        //Тестирование ввода скругление кнопок
        public void TestButtonsCoupling(double count, double result)
        {
            _testData.ButtonsCoupling = count;
            Assert.AreEqual(result, _testData.ButtonsCoupling);
        }


        [TestCase(5, 5, TestName = "Тестирование. Длина дозатора = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина дозатора = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина дозатора = 30. Негативный")]
        //Тестирование ввода длина дозатора
        public void TestBatcherLength(double count, double result)
        {
            _testData.CorpsLenght = 30;
            _testData.BatcherLenght = count;
            Assert.AreEqual(result, _testData.BatcherLenght);
        }


        [TestCase(5, 5, TestName = "Тестирование. Ширина дозатора = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Ширина дозатора = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Ширина дозатора = 30. Негативный")]
        //Тестирование ввода ширина дозатора
        public void TestBatcherWidth(double count, double result)
        {
            _testData.CorpsWidth = 30;
            _testData.BatcherWidth = count;
            Assert.AreEqual(result, _testData.BatcherWidth);
        }


        [TestCase(5, 5, TestName = "Тестирование. Высота дозатора = 5. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Высота дозатора = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Высота дозатора = 30. Негативный")]
        //Тестирование ввода высота дозатора
        public void TestBatcherHeight(double count, double result)
        {
            _testData.CorpsHeight = 30;
            _testData.BatcherHeight = count;
            Assert.AreEqual(result, _testData.BatcherHeight);
        }


        [TestCase(1, 1, TestName = "Тестирование. Скругление дозатора = 1. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Скругление дозатора = -10. Негативный")]
        //Тестирование ввода скругление дозатора
        public void TestBatcherCoupling(double count, double result)
        {
            _testData.BatcherCoupling = count;
            Assert.AreEqual(result, _testData.BatcherCoupling);
        }

        [TestCase(1, 1, TestName = "Тестирование. Количетво отверстий = 1. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Количетво отверстий = -10. Негативный")]
        //Тестирование ввода количество отверстий
        public void TestAiringCount(double count, double result)
        {
            _testData.AiringCount = count;
            Assert.AreEqual(result, _testData.AiringCount);
        }

        [TestCase(3, 3, TestName = "Тестирование. Длина отверстий = 3. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина отверстий = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Длина отверстий = 30. Негативный")]
        //Тестирование ввода длина отверстий
        public void TestAiringLength(double count, double result)
        {
            _testData.CorpsWidth = 30;
            _testData.AiringLength = count;
            Assert.AreEqual(result, _testData.AiringLength);
        }

        [TestCase(3, 3, TestName = "Тестирование. Радиус отверстий = 3. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус отверстий = -10. Негативный")]
        [TestCase(30, 30, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Радиус отверстий = 30. Негативный")]
        //Тестирование ввода радиус отверстий
        public void TestAiringRadius(double count, double result)
        {
            _testData.CorpsLenght = 30;
            _testData.AiringRadius = count;
            Assert.AreEqual(result, _testData.AiringRadius);
        }

        [TestCase(1, 1, TestName = "Тестирование. Скругление отверстий = 1. Позитивный")]
        [TestCase(-10, -10, ExpectedException = (typeof(ArgumentException)), TestName = "Тестирование. Скругление отверстий = -10. Негативный")]
        //Тестирование ввода скругление отверстий
        public void TestAiringCoupling(double count, double result)
        {
            _testData.AiringCoupling = count;
            Assert.AreEqual(result, _testData.AiringCoupling);
        }
    }
}
