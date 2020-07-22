using System;
using System.Runtime.Remoting.Messaging;
using BoxLibrary.Figures;
using BoxLibrary.MyBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoxLibrary.Tests
{
    [TestClass]
    public class BoxTests
    {
        [TestMethod]
        public void XmlWriter_Box_Figures_Square_10_Rectangle_14_32_Circle_11()
        {
            //arrange
            Box box = new Box();
            Rectangle rectangle = new Rectangle(14,32,Material.Paper,Color.Blue);
            Square square = new Square(10,Material.Film,Color.Green);
            Circle circle = new Circle(11, Material.Paper, Color.Purple);
            box.AddFigure(rectangle);
            box.AddFigure(square);
            box.AddFigure(circle);
            //act
            bool actual = box.SaveFiguresXmlWriter("test.xml");
            //assert
            Assert.IsTrue(actual);
        }
    }
}
