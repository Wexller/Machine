using System;
using NUnit.Framework;
using Machine;

namespace UnitTests
{
    internal class ParametersTest
    {
        private static readonly Data TestData = new Data();

        [Test]

        [TestCase(-15.0, -15.0, ExpectedException = (typeof(ArgumentException)), TestName = "Вводимое значение параметра равно -15")]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, TestName = "Вводимое значение параметра равно бесконечности")]
        [TestCase(double.NaN, double.NaN, TestName = "Вводимое значение параметра равно Not-a-number")]
        [TestCase(double.MinValue, double.MinValue, ExpectedException = (typeof(ArgumentException)), TestName = "Минимальное значение параметра")]
        [TestCase(double.MaxValue, double.MaxValue, TestName = "Максимальное значение параметра")]
        [TestCase(15, 15, TestName = "Вводимое значение параметра равно 15")]
        public void EnterParametrsTest(double count, double result)
        {
            TestData.CorpsLenght = count;
            Assert.AreEqual(result, TestData.CorpsLenght);
        }
        
    }
}
