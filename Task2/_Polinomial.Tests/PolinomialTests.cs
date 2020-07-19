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
            //act
            bool actual1 = p1 == p2;
            bool actual2 = p1 != p3;
            //assert
            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
        }
        //[TestMethod]
        //public void Div()
        //{
        //    //arrange
        //    Polynomial p1 = new Polynomial(8, 12, 99, 150);
        //    Polynomial p2 = new Polynomial(40, 7, 3);
        //    Polynomial expected = new Polynomial(96.54, 149.21);
        //    //act
        //    Polynomial actual = p1 / p2;
        //    MessageBox.Show(actual.ToString());
        //    MessageBox.Show(expected.ToString());
        //    //assert
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
