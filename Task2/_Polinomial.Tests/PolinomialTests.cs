using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolinomialLibrary;
using System.Windows.Forms;

namespace _Polinomial.Tests
{
    [TestClass]
    public class PolinomialTests
    {
        /// <summary>
        /// Методя для проверки перегруженного оператора сложения двух многочленов
        /// </summary>
        [TestMethod]
        public void Sum_Polinomial_17_62_3and_Polinomial_2_4_6_Polinomial_19_66_9returned()
        {
            //arrange
            Polynomial p1 = new Polynomial(17,62,3);
            Polynomial p2 = new Polynomial(2,4,6);
            Polynomial expected = new Polynomial(19,66,9);
            //act
            Polynomial actual = p1 + p2;
          
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Методя для проверки перегруженного оператора вычитания двух многочленов
        /// </summary>
        [TestMethod]
        public void Sub_Polinomial_15_60_8_4and_Polinomial_17_4_5_Polinomial_minus2_56_1_4returned()
        {
            //arrange
            Polynomial p1 = new Polynomial(15, 60, 8, 4);
            Polynomial p2 = new Polynomial(17, 4, 5);
            Polynomial expected = new Polynomial(-2, 56, 3,4);
            //act
            Polynomial actual = p1 - p2;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Методя для проверки перегруженного оператора умножения двух многочленов
        /// </summary>
        [TestMethod]
        public void Comp_Polinomial_6_8_9and_Polinomial_5_3_7_Polinomial_30_58_111_83_63returned()
        {
            //arrange
            Polynomial p1 = new Polynomial(6, 8, 9);
            Polynomial p2 = new Polynomial(5, 3, 7);
            Polynomial expected = new Polynomial(30, 58, 111,83,63);
            //act
            Polynomial actual = p1 * p2;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Методя для проверки перегруженного оператора умножения многочлена на число
        /// </summary>
        [TestMethod]
        public void Comp_Polinomial_6_8_9and_int_5_Polinomial_30_40_45returnedandComp_int6_and_Polinomial_4_3_7_Polinomial_24_18_42returned()
        {
            //arrange
            Polynomial p1 = new Polynomial(6, 8, 9);
            Polynomial p2 = new Polynomial(4, 3, 7);
            int num1 = 5;
            int num2 = 6;
            Polynomial expected1 = new Polynomial(30,40,45);
            Polynomial expected2 = new Polynomial(24,18,42);
            //act
            Polynomial actual1 = p1 * num1;
            Polynomial actual2 = p2 * num2;
            //assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        /// <summary>
        /// Методя для проверки перегруженный оператора сравнения двух многочленов
        /// </summary>
        [TestMethod]
        public void IsEqual_Polinomial_12_15_45_and_Polinomial_12_15_45_IsNotEqual_Polinomial_12_15_45_and_Polinomial_14_75_6()
        {
            //arrange
            Polynomial p1 = new Polynomial(12, 15, 45);
            Polynomial p2 = new Polynomial(12, 15, 45);
            Polynomial p3 = new Polynomial(14, 75, 6);
            Polynomial p4 = null;
            //act
            bool actual1 = p1 == p2;
            bool actual2 = p1 != p3;
            
            //assert

            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
            Assert.IsFalse(p1==p4);
        }
        /// <summary>
        /// Методя для проверки перегруженный оператора деления двух многочленов
        /// </summary>
        [TestMethod]
        public void Div_Polinomial_22_5_14_and_Polinomial_11_6_Polinomial_2_minus_0_point_64returned()
        {
            //arrange
            Polynomial p1 = new Polynomial(9, 5, 2);
            Polynomial p2 = new Polynomial(3, 2, 1, 0);
            Polynomial expected = new Polynomial(6, 3, 1, 0);
            //act
            Polynomial actual = p1 / p2;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///  Методя для проверки перегруженный оператора деления многочлена на вещественное число
        /// </summary>
        [TestMethod]
        public void Div_Polinomial_15_7_9and_double_12()
        {
            //arrange
            Polynomial p1 = new Polynomial(15, 7,9);
            double num1 = 12;
            double zero = 0;
            Polynomial expected = new Polynomial(1.25, 0.58, 0.75);
            //act
            Polynomial actual = p1 / num1;
            //assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<DivideByZeroException>(() => p1 / zero);
        }
    }
}
