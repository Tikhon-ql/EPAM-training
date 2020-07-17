using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorLib.Tests
{
    [TestClass]
    class ProductsTests
    {
        /// <summary>
        /// Проверка метода сложения двух пищевых продуктов
        /// </summary>
        [TestMethod]
        public void Sum_FoodProduct_Хлеб_15_Молоко_12()
        {
            //arrange
            FoodProducts bread = new FoodProducts("Хлеб",15);
            FoodProducts milk = new FoodProducts("Молока",12);
            FoodProducts expected = new FoodProducts("Хлеб-молоко",Convert.ToDecimal(13.5));
            //act
            FoodProducts actual = bread + milk;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка метода явного преобразования от типа FoodProducts к типу ElectricalProducts
        /// </summary>
        [TestMethod]
        public void FoodProductХлеб_12ToElectricalProduct()
        {
            //arrange
            FoodProducts bread = new FoodProducts("Хлеб", 12);
            ElectricalProducts expected = new ElectricalProducts("Хлеб",12);
            //act
            ElectricalProducts actual = (ElectricalProducts)bread;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
