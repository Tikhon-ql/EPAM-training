using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using FiguresLibrary.Exceptions;
using FiguresLibrary.Models.FilmFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilmFigures.Tests
{
    [TestClass]
    public class FilmFiguresTests
    {
        /// <summary>
        /// Checking a constructor to cut one figure from another
        /// </summary>
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
        /// <summary>
        ///  Checking a method to get data fom xml attributes 
        /// </summary>
        [TestMethod]
        public void AttributeXml_FilmCircle_10_FilmRectanlge_10_20()
        {
            //arrange
            Dictionary<string, string> circleAttr = new Dictionary<string, string>();
            Dictionary<string, string> recAttr = new Dictionary<string, string>();
            Dictionary<string, string> rectExpected = new Dictionary<string, string>();
            Dictionary<string, string> circleExpected = new Dictionary<string, string>();
            rectExpected.Add("width","20");
            rectExpected.Add("height","10");
            rectExpected.Add("type", "FilmRectangle");
            circleExpected.Add("radius","10");
            circleExpected.Add("type","FilmCircle");
            //act
            circleAttr = new FilmCircle(10).AttributeXml();
            recAttr = new FilmRectangle(10,20).AttributeXml();
            //assert
            CollectionAssert.AreEqual(rectExpected, recAttr);
            CollectionAssert.AreEqual(circleExpected, circleAttr);
        }
    }
}
