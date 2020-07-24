using FiguresLibrary.Exceptions;
using FiguresLibrary.Models.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Figures.Tests
{
    [TestClass]
    class PaperFiguresTest
    {
        [TestMethod]
        public void Cut_PaperCircle_7_from_PaperSqaure_20_and_PaperTringle_30_50_30_from_PaperRectangle_14_12()
        {
            //arrange
            PaperSquare square = new PaperSquare(20);
            PaperCircle expected = new PaperCircle(7);
            PaperRectangle rectangle = new PaperRectangle(14,12);
            PaperTriangle triangle = null;
            //act
            PaperCircle actual = new PaperCircle(square, 7);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<CannotCutableException>(() => triangle = new PaperTriangle(square, 30, 50, 30));
        }
    }
}
