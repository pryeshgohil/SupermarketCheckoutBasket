using System;
using System.Collections.Generic;
using NUnit.Framework;
using SupermarketCheckoutBasketService.Classes;
using SupermarketCheckoutBasketService.Factory;

namespace SupermarketCheckoutBasketTest
{

    [TestFixture]
    public class CashierTests
    {
        private List<Sku> _listOfItems;


        public void AddToList(string code, int numberOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                _listOfItems.Add(new Sku(code));
            }
        }

        [SetUp]
        public void Setup()
        {
            _listOfItems = new List<Sku>();
        }

        [Test]
        public void Cashier_WhenNoProductsInBasket_PriceIsZero()
        {
            var finalPrice = new Cashier().Checkout(new List<Sku>());

            Assert.AreEqual(0, finalPrice);
        }


        [TestCase(1, 0.50)]
        [TestCase(2, 1.00)]
        [TestCase(3, 1.30)]
        [TestCase(4, 1.80)]
        [TestCase(5, 2.30)]
        public void Cashier_ProductA99_displays_correct_final_price(int numberOfItems, double expectedPrice)
        {

            //Arrange
            AddToList("A99", numberOfItems);

            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [TestCase(1, 0.30)]
        [TestCase(2, 0.45)]
        [TestCase(3, 0.75)]
        [TestCase(4, 0.90)]
        [TestCase(5, 1.20)]
        public void Cashier_ProductB15_displays_correct_final_price(int numberOfItems, double expectedPrice)
        {
            //Arrange
            AddToList("B15", numberOfItems);

            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);

        }


        [TestCase(1, 1.80)]
        [TestCase(2, 3.60)]
        [TestCase(3, 5.40)]
        [TestCase(4, 7.20)]
        [TestCase(5, 9.00)]
        public void Cashier_ProductC40_displays_correct_final_price(int numberOfItems, double expectedPrice)
        {
            //Arrange
            AddToList("C40", numberOfItems);

            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);
            
            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);

        }

        [TestCase(1, 0.99)]
        [TestCase(2, 1.98)]
        [TestCase(3, 2.97)]
        [TestCase(4, 3.96)]
        [TestCase(5, 4.95)]
        public void Cashier_ProductT23_displays_correct_final_price(int numberOfItems, double expectedPrice)
        {
            //Arrange
            AddToList("T23", numberOfItems);
         
            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void Cashier_RegularPricedProducts_display_correct_final_price()
        {

            //Arrange
            AddToList("A99", 1);
            AddToList("B15", 2);

            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Assert
            double expectedPrice = 0.95;
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [Test]
        public void Cashier_RegularPricedProductsWithSpecialOffer_display_correct_final_price()
        {
            //Arrange
            AddToList("A99", 3);
            AddToList("T23", 2);

            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Assert
            double expectedPrice = 3.28;
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [Test]
        public void Cashier_SpecialOfferProducts_display_correct_final_price()
        {
            //Arrange
            AddToList("A99", 3);
            AddToList("B15", 2);

            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Asset
            double expectedPrice = 1.75;
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void Cashier_SkuItem_Does_Not_Exist()
        {
            //Arrange
            AddToList("Z10", 1);

            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Assert
            double expectedPrice = 0;

            Assert.AreEqual(expectedPrice, actualPrice);

        }


        [Test]
        public void Cashier_SkuItem_Does_Not_Exist_And_Valid_Item()
        {
            //Arrange
            AddToList("Z10", 1);
            AddToList("C40", 2);
            //Act
            var actualPrice = new Cashier().Checkout(_listOfItems);

            //Assert
            double expectedPrice = 3.60;

            Assert.AreEqual(expectedPrice, actualPrice);

        }
    }
}
