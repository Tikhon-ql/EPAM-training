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
        [TestMethod]
        public void ReadFromFile_Should_Return_TextContext()
        {
            //arrange
            List<Figure> figures = new List<Figure>();
            string filename = @"D:\Тихон\Git\EPAM-training\Task1(part2)\Part2\Part2\Resources\test.txt";
            string expected = "Triangle;10;15;41Square;15Rectangle;16;4Triangle;12;20;8";

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
        [TestMethod]
        public void Equals_Square_10_Recatangle_15_25_Triangle_12_20_8returned()
        {
            //arrange
            List<Figure> figures = new List<Figure>();
            string expected = "Rectangle;16;4Triangle;12;20;8";
            string filename = @"D:\Тихон\Git\EPAM-training\Task1(part2)\Part2\Part2\Resources\test.txt";
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
    }
}
