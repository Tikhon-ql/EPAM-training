using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductTask.Models;

namespace _StatineryProducts.Tests
{
    [TestClass]
    public class StationeryProductsTests
    {
        /// <summary>
        /// Проверка метода сложения двух канцелярских товаров
        /// </summary>
        [TestMethod]
        public void Sum_StationeryProducts_Карандаши_15_Скрепки_12()
        {
            //arrange
            StationeryProducts pencils = new StationeryProducts("Карандаши", 15m);
            StationeryProducts clips = new StationeryProducts("Скрепки", 12m);
            StationeryProducts expected = new StationeryProducts("Карандаши-Скрепки", 13.5m);
            //act
            StationeryProducts actual = pencils + clips;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        /// <summary>
        /// Проверка метода явного преобразования от типа StationeryProducts к типу ElectricalProducts
        /// </summary>
        [TestMethod]
        public void StationeryProductsСкрепки_12ToElectricalProduct()
        {
            //arrange
            StationeryProducts clips = new StationeryProducts("Скрепки", 12m);
            StationeryProducts incorrectclips = null;
            ElectricalProducts expected = new ElectricalProducts("Скрепки", 12m);
            //act
            ElectricalProducts actual = (ElectricalProducts)clips;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
            Assert.ThrowsException<Exception>(() => (ElectricalProducts)incorrectclips);
        }
        /// <summary>
        /// Проверка метода явного преобразования от типа StationeryProducts к типу FoodProducts
        /// </summary>
        [TestMethod]
        public void StationeryProductsСкрепки_12ToFoodProducts()
        {
            //arrange
            StationeryProducts clips = new StationeryProducts("Скрепки", 12m);
            StationeryProducts incorrectclips = null;
            FoodProducts expected = new FoodProducts("Скрепки", 12m);
            //act
            FoodProducts actual = (FoodProducts)clips;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
            Assert.ThrowsException<Exception>(() => (FoodProducts)incorrectclips);
        }
        /// <summary>
        /// Проверка метода преобразования к целочисленному типу (int) 
        ///</summary>
        [TestMethod]
        public void TransformationInt_StationeryProducts_Карандаши_15_int1500returned()
        {
            //arrange
            StationeryProducts pencils = new StationeryProducts("Карандаши", 15m);
            int expected = 1500;
            //act
            int actual = (int)pencils;
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///  Проверка метода преобразования к вещественному типу (decimal) 
        /// </summary>
        [TestMethod]
        public void TransformationInt_StationeryProducts_Карандаши_15point37_decimal1537returned()
        {
            //arrange
            StationeryProducts pencils = new StationeryProducts("Карандаши", 15.37m);
            decimal expected = 1537;
            //act
            decimal actual = (decimal)pencils;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
