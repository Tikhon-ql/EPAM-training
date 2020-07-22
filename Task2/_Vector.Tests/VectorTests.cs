using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace MyVector.Tests
{
    [TestClass]
    public class VectorTests
    {
        /// <summary>
        /// Проверка перегруженного оператора сложения
        /// </summary>
        [TestMethod]
        public void Sum_Vector_10_20_30andVector_40_50_60_Vector_50_70_90()
        {
            //arrange
            Vector v1 = new Vector(10, 20, 30);
            Vector v2 = new Vector(40, 50, 60);
            Vector expected = new Vector(50, 70, 90);
            Vector notexpected = new Vector(20, 40, 10);
            //act
            Vector actual = v1 + v2;
            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(notexpected, actual);
        }
        /// <summary>
        /// Проверка перегруженного оператора вычитания
        /// </summary>
        [TestMethod]
        public void Sub_Vector_50_20_30andVector_40_30_10_Vector_10_minus10_20()
        {
            //arrange
            Vector v1 = new Vector(50, 20, 30);
            Vector v2 = new Vector(40, 30, 10);
            Vector expected = new Vector(10, -10, 20);
            //act
            Vector actual = v1 - v2;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка перегруженного оператора умножения
        /// </summary>
        [TestMethod]
        public void Comp_Vector_5_4_3andVector_15_12_10_Vector_4_minus5_0()
        {
            //arrange
            Vector v1 = new Vector(5, 4, 3);
            Vector v2 = new Vector(15, 12, 10);
            Vector expected = new Vector(4, -5, 0);
            Vector notexpected = new Vector(4, 5, 0);
            //act
            Vector actual = v1 * v2;
            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(notexpected, actual);
        }
        /// <summary>
        /// Проверка перегруженного оператора деления
        /// </summary>
        [TestMethod]
        public void Comp_Vector_10_12_17andVector_10_14_5_Vector_1point185_minus0point3_minus0point485()
        {
            //arrange
            Vector v1 = new Vector(10, 12, 17);
            Vector v2 = new Vector(10, 14, 5);
            Vector expected = new Vector(1.193, -0.3, -0.49);
            //act
            Vector actual = v1 / v2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        /// <summary>
        /// Проверка перегруженного оператора инкремента
        /// </summary>
        [TestMethod]
        public void Increm_Vector_5_17_6()
        {
            //arrange
            Vector v = new Vector(5, 17, 6);
            Vector expected = new Vector(6, 18, 7);
            //act
            Vector actual = ++v;

            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка перегруженного оператора дикремента
        /// </summary>
        [TestMethod]
        public void Decrem_Vector_42_76_23()
        {
            //arrange
            Vector v = new Vector(42, 76, 23);
            Vector expected = new Vector(41, 75, 22);
            //act
            Vector actual = --v;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка перегруженных методов сравнения(== и !=)
        /// </summary>
        [TestMethod]
        public void IsEquals_Vector_40_71_27andVector_40_71_27_and_NotEquals_Vector_40_71_27andVector_44_42_71()
        {
            Vector v1 = new Vector(40, 71, 27);
            Vector v2 = new Vector(40, 71, 27);
            Vector v3 = new Vector(44, 42, 71);
            Assert.IsTrue(v1 == v2);
            Assert.IsTrue(v1 != v3);
        }
        /// <summary>
        /// Проверка перегруженных методов сравнения(> и <)
        /// </summary>
        [TestMethod]
        public void Vector_15_42_24morethanVector_4_6_10()
        {
            Vector v1 = new Vector(15, 42, 24);
            Vector v2 = new Vector(4, 6, 10);
            Assert.IsTrue(v1 > v2);
            Assert.IsFalse(v1 < v2);
        }
    }
}
