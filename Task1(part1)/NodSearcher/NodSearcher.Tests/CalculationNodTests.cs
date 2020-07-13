using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NodSearcher.Tests
{
    [TestClass]
    public class CalculationNodTests
    {
        /// <summary>
        /// Проверка работы нахождения НОД с помощью алгоритма Евклида
        /// </summary>
        [TestMethod]
        public void EvclidNOD_12and76_4returned()
        {
            //arrange

            int first = 12;
            int second = 76;
            int expected = 4;

            //act

            int actual = СalculationNod.EvclideNod(first, second);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EvclidNOD_12and76and64_4returned()
        {
            //arrange

            int first = 12;
            int second = 76;
            int third = 64;
            int expected = 4;

            //act

            int actual = СalculationNod.EvclideNod(first, second, third);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EvclidNOD_46and78and12and6_2returned()
        {
            //arrange

            int first = 46;
            int second = 78;
            int third = 12;
            int fourth = 6;
            int expected = 2;

            //act

            int actual = СalculationNod.EvclideNod(first, second, third, fourth);

            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка работы нахождения НОД с помощью алгоритма Стейна
        /// </summary>
        [TestMethod]
        public void SteinNod_34and17_17returned()
        {
            //arrange

            int first = 34;
            int second = 17;
            int expected = 17;
            TimeSpan time = new TimeSpan();

            //act


            int actual = СalculationNod.SteinNod(first, second, out time);

            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка метода для подготовки данных для гистограммы
        /// </summary>
        [TestMethod]
        public void ForBarCharts_shouldnot0returned()
        {
            //arrange

            Pair<TimeSpan, TimeSpan> actual = new Pair<TimeSpan, TimeSpan>(new TimeSpan(0,0,0), new TimeSpan(0,0,0));
            Pair<TimeSpan, TimeSpan> expected = new Pair<TimeSpan, TimeSpan>(new TimeSpan(0,0,0), new TimeSpan(0,0,0));


            //act

            actual = СalculationNod.ForBarCharts();

            //assert
            Assert.AreNotEqual(expected,actual);
        }
    }
}
