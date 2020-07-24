using System;
using FiguresLibrary.Exceptions;
using FiguresLibrary.Models.FilmFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _Figures.Tests
{
    [TestClass]
    public class FilmFiguresTests
    {
        [TestMethod]
        public void Cut_FilmCircle_5_from_FilmRectangle_10_20_and_FilmTringle_30_50_30_from_FilmSquare_10()
        {
            //arrange
            FilmRectangle rectangle = new FilmRectangle(10, 20);
            FilmCircle expected = new FilmCircle(5);
            FilmSquare square = new FilmSquare(10);
            FilmTriangle triangle = null;
            //act
            FilmCircle actual = new FilmCircle(rectangle, 5);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<CannotCutableException>(() => triangle = new FilmTriangle(square, 30, 50, 30));
        }

    }
}
