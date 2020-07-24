using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ColorsLibrary;
using FiguresLibrary.Abstract;
using FiguresLibrary.Models.FilmFigures;
using FiguresLibrary.Models.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoxLibrary.Tests
{
    [TestClass]
    public class BoxTests
    {
        /// <summary>
        /// Проверка метода добавления фигур
        /// </summary>
        [TestMethod]
        public void Add_PaperCircle_15_FilmRectangle_15_12_PaperTrianlge_10_24_20()
        {
            //arrange
            Box box = new Box();

            //act

            bool actual1 = box.AddFigure(new PaperCircle(15));
            bool actual2 = box.AddFigure(new FilmRectangle(15,12));
            bool actual3 = box.AddFigure(new PaperTriangle(10, 24, 20));
            box.AddFigure(new PaperTriangle(1,22,22));
            box.AddFigure(new PaperTriangle(2,22,22));
            box.AddFigure(new PaperTriangle(3,22,22));
            box.AddFigure(new PaperTriangle(4,22,22));
            box.AddFigure(new PaperTriangle(5,22,22));
            box.AddFigure(new PaperTriangle(6,22,22));
            box.AddFigure(new PaperTriangle(7,22,22));
            box.AddFigure(new PaperTriangle(8,22,22));
            box.AddFigure(new PaperTriangle(9,22,22));
            box.AddFigure(new PaperTriangle(10,22,22));
            box.AddFigure(new PaperTriangle(11,22,22));
            box.AddFigure(new PaperTriangle(12,22,22));
            box.AddFigure(new PaperTriangle(13,22,22));
            box.AddFigure(new PaperTriangle(14,22,22));
            box.AddFigure(new PaperTriangle(15,22,22));
            box.AddFigure(new PaperTriangle(16,22,22));
            box.AddFigure(new PaperTriangle(17,22,22));
            box.AddFigure(new PaperTriangle(18,22,22));
            box.AddFigure(new PaperTriangle(19,22,22));
            box.AddFigure(new PaperTriangle(20,22,22));
            bool actual4 = box.AddFigure(new PaperTriangle(18, 24, 34));
            //assert

            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
            Assert.IsFalse(actual3);
            Assert.IsFalse(actual4);
        }
        /// <summary>
        /// Метод просмотра определенной фигуры
        /// </summary>
        [TestMethod]
        public void See_PaperRectangle_17_15_Green()
        {
            //arrange
            Box box = new Box(new PaperCircle(15),new FilmTriangle(10,15,10),new PaperSquare(10),new PaperRectangle(17,15,Colors.Green));
            PaperRectangle expected = new PaperRectangle(17, 15, Colors.Green);
            //act

            Figure actual = box.SeeFigure(3);

            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка метода получения фигуры с удалением
        /// </summary>
        [TestMethod]
        public void Pop_FilmCircle_10()
        {
            //arrange
            Box box = new Box(new FilmCircle(10), new FilmTriangle(10, 15, 10), new PaperSquare(10));
            FilmCircle expected = new FilmCircle(10);
            //act

            Figure actual = box.PopFigure(0);

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2, box.Count);
        }
        /// <summary>
        /// Проверка метода замены фигуры
        /// </summary>
        [TestMethod]
        public void Replace_FilmCircle_10_Rectangle_15_17_Green()
        {
            //arrange
            Box box = new Box(new FilmCircle(10), new FilmTriangle(10, 15, 10), new PaperSquare(10));
            PaperRectangle rectangle = new PaperRectangle(15,17,Colors.Green);
            //act

            bool actual = box.Replace(0, rectangle);

            //assert
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// Метод проверки поиска фигуры
        /// </summary>
        [TestMethod]
        public void Seacrhe_FilmSquare_10()
        {
            //arrange
            Box box = new Box(new FilmCircle(10), new FilmTriangle(10, 15, 10), new PaperSquare(10),new FilmSquare(10));
            FilmSquare expected = new FilmSquare(10);
            //act

            Figure actual = box.Searche(expected);

            //assert
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Проверка метода получения списка текущих фигур
        /// </summary>
        [TestMethod]
        public void GetCurrentFigures_Box_FilmCircle_10_FilmTriangle_10_15_10_PaperSquare_10()
        {
            //arrange
            Box box = new Box(new FilmCircle(10), new FilmTriangle(10, 15, 10), new PaperSquare(10));
            List<Figure> expected = new List<Figure>();
            List<Figure> notexpected = new List<Figure>();
            expected.AddRange(new List<Figure> { new FilmCircle(10), new FilmTriangle(10, 15, 10), new PaperSquare(10) });
            notexpected.AddRange(new List<Figure> { new FilmCircle(10), new FilmTriangle(10, 15, 10), new PaperSquare(10) , new FilmCircle(10)});
            //act

            List<Figure> actual = box.GetCurrentFigures();
            //assert
            CollectionAssert.AreEqual(expected, actual);
            CollectionAssert.AreNotEqual(notexpected, actual);
        }
        /// <summary>
        /// Проверка метода получения суммарного перимектра
        /// </summary>
        [TestMethod]
        public void GetSumP_Box_FilmCircle_10_PaperSquare_10()
        {
            //arrange
            Box box = new Box(new FilmCircle(10), new PaperSquare(10));
            double expected = 102.83;
            //act
            double actual = box.GetSumP();
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка метода получения суммарной площади
        /// </summary>
        [TestMethod]
        public void GetSumS_Box_FilmTriangle_10_12_15_PaperSquare_10()
        {
            //arrange
            Box box = new Box(new FilmTriangle(10, 12, 15), new PaperSquare(10));
            double expected = 159.81;
            //act
            double actual = box.GetSumS();
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка метода получения определенных фигур
        /// </summary>
        [TestMethod]
        public void GetAllCircles_Box_PaperCircle_10_FilmSquare_10_FilmCircle_10_PaperRectangle_10_15()
        {
            //arrange
            Box box = new Box(new PaperCircle(10), new FilmSquare(10),new FilmCircle(10),new PaperRectangle(10,15));
            List<Figure> expected = new List<Figure> {new PaperCircle(10),new FilmCircle(10)};
            //act
            List<Figure> actual = box.GetExactFugire("Circle");
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Метод получения фигур по материалу (false - пленочные, true - бумажные)
        /// </summary>
        [TestMethod]
        public void GetAllFilmFigures_Box_PaperCircle_10_FilmSquare_10_FilmCircle_10_PaperRectangle_10_15()
        {
            //arrange
            Box box = new Box(new PaperCircle(10), new FilmSquare(10), new FilmCircle(10), new PaperRectangle(10, 15));
            List<Figure> expected = new List<Figure> { new FilmSquare(10), new FilmCircle(10) };
            //act
            List<Figure> actual = box.GetExactFigureByMaterial(false);
 
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка метода сохранения данных в xml файл через XmlWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFile_Box_PaperCircle_10_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(10), new FilmSquare(10), new PaperTriangle(10,12,15,Colors.Red), new PaperRectangle(10, 20,Colors.Blue));
            string filename = "test.xml";
            string notxmlfilename = "test.txt";
            string badfilename = "";
            string nullfilename = null;
            //act
            bool actual = box.SaveFiguresXmlWriter(filename);

            //assert
            Assert.IsTrue(actual);
            Assert.IsFalse(box.SaveFiguresXmlWriter(notxmlfilename));
            Assert.IsFalse(box.SaveFiguresXmlWriter(badfilename));
            Assert.IsFalse(box.SaveFiguresXmlWriter(nullfilename));
        }
        /// <summary>
        /// Проверка метода сохранения фигур определённого материала (true - бумага, false - пленка) в xml файл через XmlWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFileByMaterial_Box_PaperCircle_10_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(10), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20, Colors.Blue));

            string filename = "testbymat.xml";
            //act
            bool actual = box.SaveFiguresXmlWriter(filename,true);

            //assert
            Assert.IsTrue(actual);
        }
    }
}
