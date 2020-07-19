using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductTask.Models;
using System.Windows.Forms;

namespace _ElectricalProducts.Tests
{
    [TestClass]
    public class ElectricalProductsTests
    {
        /// <summary>
        /// Проверка метода сложения двух электронных продуктов
        /// </summary>
        [TestMethod]
        public void Sum_ElectricalProducts_Ноутбук_15_Смартфон_12()
        {
            //arrange
            ElectricalProducts notebook = new ElectricalProducts("Ноутбук", 15m);
            ElectricalProducts phone = new ElectricalProducts("Смартфон", 12m);
            ElectricalProducts expected = new ElectricalProducts("Ноутбук-Смартфон", 13.5m);
            //act
            ElectricalProducts actual = notebook  + phone;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        /// <summary>
        /// Проверка метода явного преобразования от типа ElectricalProducts к типу FoodProducts
        /// </summary>
        [TestMethod]
        public void ElectricalProductsНоутбук_50ToFoodProducts()
        {
            //arrange
            ElectricalProducts notebook = new ElectricalProducts("Ноутбук", 50);
            ElectricalProducts fakenotebook = null;
            FoodProducts expected = new FoodProducts("Ноутбук", 50);
            //act
            FoodProducts actual = (FoodProducts)notebook;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
            Assert.ThrowsException<Exception>(() => (FoodProducts)fakenotebook);
        }
        /// <summary>
        /// Проверка метода явного преобразования от типа ElectricalProducts к типу StationeryProducts
        /// </summary>
        [TestMethod]
        public void ElectricalProductsНоутбук_50ToStationeryProducts()
        {
            //arrange
            ElectricalProducts notebook = new ElectricalProducts("Ноутбук", 50);
            ElectricalProducts incorrectnotebook = null;
            StationeryProducts expected = new StationeryProducts("Ноутбук", 50);
            //act
            StationeryProducts actual = (StationeryProducts)notebook;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
            Assert.ThrowsException<Exception>(() => (FoodProducts)incorrectnotebook);
        }
        /// <summary>
        /// Проверка метода преобразования к целочисленному типу (int) 
        ///</summary>
        [TestMethod]
        public void TransformationInt_ElectricalProducts_Ноутбук50_int5000returned()
        {
            //arrange
            ElectricalProducts notebook = new ElectricalProducts("Ноутбук", 50);
            int expected = 5000;
            //act
            int actual = (int)notebook;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///  Проверка метода преобразования к вещественному типу(decimal)
        /// </summary>
        [TestMethod]
        public void TransformationInt_ElectricalProducts_Ноутбук50point51_decimal5051returned()
        {
            //arrange
            ElectricalProducts notebook = new ElectricalProducts("Ноутбук", 50.51m);
            decimal expected = 5051;
            //act
            decimal actual = (decimal)notebook;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
