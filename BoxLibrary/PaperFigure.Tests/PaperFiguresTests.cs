using System;
using FiguresLibrary.Exceptions;
using FiguresLibrary.Models.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorsLibrary;
using ColorsLibrary.Exceptions;

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
    }
}
