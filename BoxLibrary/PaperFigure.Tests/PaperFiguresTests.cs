using System;
using FiguresLibrary.Exceptions;
using FiguresLibrary.Models.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorsLibrary;
using ColorsLibrary.Exceptions;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PaperFigure.Tests
{
    [TestClass]
    public class PaperFiguresTests
    {
        /// <summary>
        /// Прокерка вырезания одной фигуры из другой
        /// </summary>
        [TestMethod]
        public void Cut_PaperCircle_7_from_PaperSqaure_20_and_PaperTringle_30_50_30_from_PaperRectangle_14_12()
        {
            //arrange

            PaperSquare square = new PaperSquare(20);
            PaperCircle expected = new PaperCircle(7);
            PaperRectangle rectangle = new PaperRectangle(14, 12);
            PaperTriangle triangle = null;

            //act

            PaperCircle actual = new PaperCircle(square, 7);

            //assert

            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<CannotCutableException>(() => triangle = new PaperTriangle(square, 30, 50, 30));
        }
        /// <summary>
        /// Проверка метода закрашивания бумажной фигуры
        /// </summary>
        [TestMethod]
        public void Paint_PaperCircle_7_Red_PaperCircle_7_Green_returned_and_PaperCircle_7_Green_CannotPaintableException_returned()
        {
            //arrange
            PaperCircle actual = new PaperCircle(7,Colors.Red);
            PaperCircle expected = new PaperCircle(7,Colors.Green);

            //act

            actual.Paint(Colors.Green);
            
            //assert

            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<CannotPaintableException>(() => actual.Paint(Colors.Yellow));
        }
        /// <summary>
        /// Проверка метода получения данных для аттрибутов xml
        /// </summary>
        [TestMethod]
        public void AttributeXml_PaperCircle_15_FilmSquare_10()
        {
            //arrange
            Dictionary<string, string> circleAttr = new Dictionary<string, string>();
            Dictionary<string, string> sqAttr = new Dictionary<string, string>();
            Dictionary<string, string> sqExpected = new Dictionary<string, string>();
            Dictionary<string, string> circleExpected = new Dictionary<string, string>();
            sqExpected.Add("side", "10");
            sqExpected.Add("color", "Red");
            sqExpected.Add("type", "PaperSquare");
            circleExpected.Add("radius", "15");
            circleExpected.Add("color", "Pink");
            circleExpected.Add("type", "PaperCircle");
            //act
            circleAttr = new PaperCircle(15,Colors.Pink).AttributeXml();
            sqAttr = new PaperSquare(10,Colors.Red).AttributeXml();
            //assert
            CollectionAssert.AreEqual(sqExpected, sqAttr);
            CollectionAssert.AreEqual(circleExpected, circleAttr);
        }
    }
}
