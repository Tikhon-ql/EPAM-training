using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Product.Tests
{
    [TestClass]
    class FoodProductsTests
    {
        /// <summary>
        /// Проверка метода сложения двух пищевых продуктов
        /// </summary>
        [TestMethod]
        public void Sum_FoodProduct_Хлеб_15_Молоко_12()
        {
            //arrange
            FoodProducts bread = new FoodProducts("Хлеб", 15);
            FoodProducts milk = new FoodProducts("Молоко", 12);
            FoodProducts expected = new FoodProducts("Хлеб-молоко", 13.5m);
            //act
            FoodProducts actual = bread + milk;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        /// <summary>
        /// Проверка метода явного преобразования от типа FoodProducts к типу ElectricalProducts
        /// </summary>
        [TestMethod]
        public void FoodProductХлеб_12ToElectricalProduct()
        {
            //arrange
            FoodProducts bread = new FoodProducts("Хлеб", 12);
            FoodProducts food = null;
            ElectricalProducts expected = new ElectricalProducts("Хлеб", 12);
            //act
            ElectricalProducts actual = (ElectricalProducts)bread;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
            Assert.ThrowsException<Exception>(() => (ElectricalProducts)food);
        }
        /// <summary>
        /// Проверка метода явного преобразования от типа FoodProducts к типу StationeryProducts
        /// </summary>
        [TestMethod]
        public void FoodProductХлеб_12ToStationeryProducts()
        {
            //arrange
            FoodProducts bread = new FoodProducts("Хлеб", 12);
            FoodProducts food = null;
            StationeryProducts expected = new StationeryProducts("Хлеб", 12);
            //act
            StationeryProducts actual = (StationeryProducts)bread;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
            Assert.ThrowsException<Exception>(() => (ElectricalProducts)food);
        }
        /// <summary>
        /// Проверка метода преобразования к типу int 
        ///</summary>
        [TestMethod]
        public void TransformationInt_FoodProducts_Молоко_15_int1500returned()
        {
            //arrange
            FoodProducts milk = new FoodProducts("Молоко", 15);
            int expected = 1500;
            //act
            int actual = (int)milk;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///  Проверка метода преобразования к типу double 
        /// </summary>
        [TestMethod]
        public void TransformationDouble_FoodProducts_Хлеб_10point5_double1050returned()
        {
            //arrange
            FoodProducts milk = new FoodProducts("Хлеб", 10.5m);
            double expected = 150;
            //act
            double actual = (double)milk;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
