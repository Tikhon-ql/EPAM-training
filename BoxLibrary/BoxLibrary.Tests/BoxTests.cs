using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BoxLibrary.Enums;
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
        /// Checking add figure method
        /// </summary>
        [TestMethod]
        public void Add_PaperCircle_15_FilmRectangle_15_12_PaperTrianlge_10_24_20()
        {
            //arrange
            Box box = new Box();

            //act

            bool actual1 = box.AddFigure(new PaperRectangle(10,10,Colors.Pink));
            bool actual2 = box.AddFigure(new FilmRectangle(15,12));
            bool actual3 = box.AddFigure(new PaperSquare(10,Colors.Pink));
            box.AddFigure(new FilmTriangle(1,22,22));
            box.AddFigure(new FilmTriangle(2,22,22));
            box.AddFigure(new FilmTriangle(3,22,22));
            box.AddFigure(new FilmTriangle(4,22,22));
            box.AddFigure(new FilmTriangle(5,22,22));
            box.AddFigure(new FilmTriangle(6,22,22));
            box.AddFigure(new FilmTriangle(7,22,22));
            box.AddFigure(new FilmTriangle(8,22,22));
            box.AddFigure(new FilmTriangle(9,22,22));
            box.AddFigure(new FilmTriangle(10,22,22));
            box.AddFigure(new FilmTriangle(11,22,22));
            box.AddFigure(new FilmTriangle(12,22,22));
            box.AddFigure(new FilmTriangle(13,22,22));
            box.AddFigure(new FilmTriangle(14,22,22));
            box.AddFigure(new FilmTriangle(15,22,22));
            box.AddFigure(new FilmTriangle(16,22,22));
            box.AddFigure(new FilmTriangle(17,22,22));
            box.AddFigure(new FilmTriangle(18,22,22));
            box.AddFigure(new PaperTriangle(19,22,22));
            box.AddFigure(new PaperTriangle(20,22,22));
            bool actual4 = box.AddFigure(new FilmTriangle(18, 24, 34));
            //assert

            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
            Assert.IsFalse(actual3);
            Assert.IsFalse(actual4);
        }
        /// <summary>
        /// Checking figure view method
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
        /// Checking figure pop method
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
        /// Checking figure replace method
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
        /// Checking figure search method
        /// </summary>
        [TestMethod]
        public void Seacrhe_FilmSquare_10()
        {
            //arrange
            Box box = new Box(new FilmCircle(10), new FilmTriangle(10, 15, 10), new PaperSquare(10),new FilmSquare(10));
            FilmSquare expected = new FilmSquare(10);
            //act

            Figure actual = box.Search(expected);

            //assert
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Checking all figure view method
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
        /// Checking get sun perimetr method
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
        ///  Checking get sun square method
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
        /// Checking get circles method
        /// </summary>
        [TestMethod]
        public void GetAllCircles_Box_PaperCircle_17_FilmSquare_10_FilmCircle_12_PaperRectangle_10_15()
        {
            //arrange
            Box box = new Box(new PaperCircle(17), new FilmSquare(10),new FilmCircle(12),new PaperRectangle(10,15));
            List<Figure> expected = new List<Figure> {new PaperCircle(17),new FilmCircle(12)};
            //act
            List<Figure> actual = box.GetCircle();
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Checking get film figures method
        /// </summary>
        [TestMethod]
        public void GetAllFilmFigures_Box_PaperCircle_10_FilmSquare_10_FilmCircle_10_PaperRectangle_10_15()
        {
            //arrange
            Box box = new Box(new PaperCircle(10), new FilmSquare(12), new FilmCircle(15), new PaperRectangle(10, 15));
            List<Figure> expected = new List<Figure> { new FilmSquare(12), new FilmCircle(15) };
            //act
            List<Figure> actual = box.GetFilmFigures();
 
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Checking save to xml file through XmlWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFile_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10,12,15,Colors.Red), new PaperRectangle(10, 20,Colors.Blue));
            string filename = "test.xml";
            string badfilename = "";
            string nullfilename = null;
            //act
            bool actual = box.SaveFiguresXmlWriter(filename);

            //assert
            Assert.IsTrue(actual);
            Assert.IsFalse(box.SaveFiguresXmlWriter(badfilename));
            Assert.IsFalse(box.SaveFiguresXmlWriter(nullfilename));
        }
        /// <summary>
        /// Checking save to xml file film figures through XmlWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFileFilmFigures_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new FilmRectangle(10, 20));

            string filename = "filmfigures.xml";
            //act
            bool actual = box.SaveFiguresXmlWriter(filename,SaveType.FilmFigures);

            //assert
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// Checking save to xml file paper figures through XmlWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFilePaperFigures_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20,Colors.Green));

            string filename = "paperfigures.xml";
            //act
            bool actual = box.SaveFiguresXmlWriter(filename, SaveType.PaperFigures);

            //assert
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// Checking load all figures from xml file  method through XmlReader
        /// </summary>
        [TestMethod]
        public void LoadFromXmlFile_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box();
            Box expected = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20, Colors.Green));

            string filename = "test.xml";
            //act
            bool actual = box.LoadFiguresXmlReader(filename);

            //assert
           
            Assert.IsTrue(actual);
            CollectionAssert.AreEqual(expected.GetCurrentFigures(), box.GetCurrentFigures());
        }
        /// <summary>
        /// Checking load all figures from xml file method through StreamReader
        /// </summary>
        [TestMethod]
        public void LoadFromXmlThroughStreamReaderFile_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box();
            Box expected = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20, Colors.Green));

            string filename = "test.xml";
            //act
            bool actual = box.LoadFiguresStreamReader(filename);
            //assert
            Assert.IsTrue(actual);
            CollectionAssert.AreEqual(expected.GetCurrentFigures(), box.GetCurrentFigures());
        }
        /// <summary>
        /// Checking the mutual work of saving / loading data from xml file XmlWriter and StreamReader
        /// </summary>
        [TestMethod]
        public void Save_Box_Through_XmlWriter_And_Load_Box_Throung_StreamReader()
        {
            //arrange
            Box box = new Box();
            Box expected = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20, Colors.Green));

            string filename = "test.xml";
            //act
            bool actualSave = expected.SaveFiguresXmlWriter(filename);
            bool actualLoad = box.LoadFiguresStreamReader(filename);
            //assert
            Assert.IsTrue(actualSave);
            Assert.IsTrue(actualLoad);
            CollectionAssert.AreEqual(expected.GetCurrentFigures(), box.GetCurrentFigures());
        }
        /// <summary>
        /// Checking the mutual work of saving/loading data from xml file StreamWriter and XmlReader
        /// </summary>
        [TestMethod]
        public void Save_Box_Through_StreamWriter_And_Load_Box_Throung_XmlReader()
        {
            //arrange
            Box box = new Box();
            Box expected = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20, Colors.Green));

            string filename = "testStreamWriter.xml";
            //act
            bool actualSave = expected.SaveFiguresStreamWriter(filename);
            bool actualLoad = box.LoadFiguresXmlReader(filename);
            //assert
            Assert.IsTrue(actualSave);
            Assert.IsTrue(actualLoad);
            CollectionAssert.AreEqual(expected.GetCurrentFigures(), box.GetCurrentFigures());
        }

        /// <summary>
        /// Checking save to xml file through StreamWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFileStreamWriter_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20, Colors.Blue));
            string filename = "testStreamWriter.xml";
            string badfilename = "";
            string nullfilename = null;
            //act
            bool actual = box.SaveFiguresStreamWriter(filename);

            //assert
            Assert.IsTrue(actual);
            Assert.IsFalse(box.SaveFiguresStreamWriter(badfilename));
            Assert.IsFalse(box.SaveFiguresStreamWriter(nullfilename));
        }

        /// <summary>
        /// Checking save to xml file film figures through StreamWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFileThroughStreamWriterFilmFigures_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new FilmRectangle(10, 20));

            string filename = "filmfiguresStreamWriter.xml";
            //act
            bool actual = box.SaveFiguresStreamWriter(filename, SaveType.FilmFigures);

            //assert
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// Checking save to xml file paper figures through StreamWriter
        /// </summary>
        [TestMethod]
        public void SaveToXmlFileThroughStreamWriterPaperFigures_Box_PaperCircle_12_FilmSquare_10_PaperTriangle_10_12_15_Red_PaperRectangle_10_20_Blue()
        {
            //arrange
            Box box = new Box(new PaperCircle(12), new FilmSquare(10), new PaperTriangle(10, 12, 15, Colors.Red), new PaperRectangle(10, 20, Colors.Green));

            string filename = "paperfiguresStreamWriter.xml";
            //act
            bool actual = box.SaveFiguresStreamWriter(filename, SaveType.PaperFigures);

            //assert
            Assert.IsTrue(actual);
        }
    }
}
