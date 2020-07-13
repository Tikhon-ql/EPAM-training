using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using Figures;
using Figures.Models;
using FileWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Part2.Tests
{
    [TestClass]
    public class Part2Tests
    {
        /// <summary>
        /// Проверка чтения из файла
        /// </summary>
        [TestMethod]
        public void ReadFromFile_Should_Return_TextContext()
        {
            //arrange
            List<Figure> figures = new List<Figure>();
            string filename = @"Resources\test.txt";
            string expected = "Triangle;10;15;12Square;15Rectangle;16;4Triangle;11;11;18";

            //act

            figures = FileWorker.ReadFromFile(filename);

            string actual = "";
            foreach (Figure item in figures)
            {
                actual += item.ToString();
            }

            //assert
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Нахождение фигур равных Sqaure(10)
        /// </summary>
        [TestMethod]
        public void Equals_Square_10_Recatangle_15_25_Triangle_12_20_8returned()
        {
            //arrange
            List<Figure> figures = new List<Figure>();
            string expected = "Rectangle;16;4Triangle;11;11;18";
            string filename = @"Resources\test.txt";
            Square square = new Square(10);

            //act
            figures = FileWorker.ReadFromFile(filename);
            string actual = "";
            foreach (Figure item in figures)
            {
                if(item.Equals(square))
                {
                    actual += item.ToString();
                }
            }

            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Тест S всех фигур
        /// </summary>
        [TestMethod]
        public void S()
        {
            //arrange
            List<Figure> figures = new List<Figure>();
            string expected = "59,8116836412419;225;64;56,9209978830308;";
            string filename = @"Resources\test.txt";
            Square square = new Square(10);

            //act
            figures = FileWorker.ReadFromFile(filename);
            string actual = "";
            foreach (Figure item in figures)
            {
                actual += item.S() + ";";
            }

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
