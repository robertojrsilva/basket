using BasketBackend.Models;
using BasketBackend.Services.Basket;
using BasketBackend.Services.Discounts;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BasketBackend.Tests
{
    public class CheckoutTests
    {
        private readonly Dictionary<string, Product> _products;

        public CheckoutTests()
        {
            _products = new Dictionary<string, Product>
            {
                { "Soup", new Product("Soup", 0.65m, "EUR") },
                { "Bread", new Product("Bread", 0.80m, "EUR") },
                { "Milk", new Product("Milk", 1.30m, "EUR") },
                { "Apples", new Product("Apples", 1.00m, "EUR") }
            };
        }

        [Fact]
        public void SubtotalSumOfItems()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Soup"], 2),
                new BasketItem(_products["Bread"], 1),
                new BasketItem(_products["Apples"], 3)
            };

            decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);

            Assert.Equal(5.10m, subtotal);
        }

        [Fact]
        public void AppleDiscount10Percent()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Apples"], 3)
            };

            AppleDiscount rule = new AppleDiscount();

            Discount discount = rule.ApplyDiscount(basket);

            Assert.Equal(0.30m, discount.Value);
        }

        [Fact]
        public void SoupBreadDiscountHalfPriceBread()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Soup"], 2),
                new BasketItem(_products["Bread"], 1)
            };

            SoupBreadDiscount rule = new SoupBreadDiscount();

            Discount discount = rule.ApplyDiscount(basket);

            Assert.Equal(0.40m, discount.Value);
        }

        [Fact]
        public void SoupBreadDiscountMultipleHalfPriceBreads()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Soup"], 4),
                new BasketItem(_products["Bread"], 2)
            };

            SoupBreadDiscount rule = new SoupBreadDiscount();

            Discount discount = rule.ApplyDiscount(basket);

            Assert.Equal(0.80m, discount.Value);
        }

        [Fact]
        public void CheckoutTotalWithDiscounts()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Soup"], 2),
                new BasketItem(_products["Bread"], 1),
                new BasketItem(_products["Apples"], 3)
            };

            CheckoutService checkout = new CheckoutService();

            decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);

            decimal totalDiscount = 0;
            foreach (var rule in checkout._discounts) 
            {
                Discount discount = rule.ApplyDiscount(basket);
                totalDiscount += discount.Value;
            }

            decimal total = subtotal - totalDiscount;

            Receipt receipt = checkout.PrintReceipt(basket);

            //Assert.Equal(5.10m, subtotal);
            //Assert.Equal(0.70m, totalDiscount);
            //Assert.Equal(4.40m, total);
            Assert.Equal(receipt.Subtotal, subtotal);
            Assert.Equal(receipt.Discounts.Sum(i => i.Value), totalDiscount);
            Assert.Equal(receipt.Total, total);
        }

        [Fact]
        public void EmptyBasket()
        {
            List<BasketItem> basket = new List<BasketItem>();
            CheckoutService checkout = new CheckoutService();

            decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);
            decimal totalDiscount = checkout._discounts.Sum(rule => rule.ApplyDiscount(basket).Value);
            decimal total = subtotal - totalDiscount;

            Receipt receipt = checkout.PrintReceipt(basket);

            //Assert.Equal(0m, subtotal);
            //Assert.Equal(0m, totalDiscount);
            //Assert.Equal(0m, total);
            Assert.Equal(receipt.Subtotal, subtotal);
            Assert.Equal(receipt.Discounts.Sum(i => i.Value), totalDiscount);
            Assert.Equal(receipt.Total, total);
        }

        [Fact]
        public void ApplesOnly10PercentDiscount()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Apples"], 2)
            };
            CheckoutService checkout = new CheckoutService();

            decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);
            decimal totalDiscount = checkout._discounts.Sum(rule => rule.ApplyDiscount(basket).Value);
            decimal total = subtotal - totalDiscount;

            Receipt receipt = checkout.PrintReceipt(basket);
            //Assert.Equal(2.00m, subtotal);
            //Assert.Equal(0.20m, totalDiscount);
            //Assert.Equal(1.80m, total);

            Assert.Equal(receipt.Subtotal, subtotal);
            Assert.Equal(receipt.Discounts.Sum(i => i.Value), totalDiscount);
            Assert.Equal(receipt.Total, total);
        }

        [Fact]
        public void SoupsWithoutBread()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Soup"], 4)
            };
            CheckoutService checkout = new CheckoutService();

            decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);
            decimal totalDiscount = checkout._discounts.Sum(rule => rule.ApplyDiscount(basket).Value);
            decimal total = subtotal - totalDiscount;

            Receipt receipt = checkout.PrintReceipt(basket);

            //Assert.Equal(2.60m, subtotal);
            //Assert.Equal(0m, totalDiscount);
            //Assert.Equal(2.60m, total);
            Assert.Equal(receipt.Subtotal, subtotal);
            Assert.Equal(receipt.Discounts.Sum(i => i.Value), totalDiscount);
            Assert.Equal(receipt.Total, total);
        }

        [Fact]
        public void BreadWithoutSoup()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Bread"], 2)
            };
            CheckoutService checkout = new CheckoutService();

            decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);
            decimal totalDiscount = checkout._discounts.Sum(rule => rule.ApplyDiscount(basket).Value);
            decimal total = subtotal - totalDiscount;

            Receipt receipt = checkout.PrintReceipt(basket);
            //Assert.Equal(1.60m, subtotal); 
            //Assert.Equal(0m, totalDiscount);
            //Assert.Equal(1.60m, total);
            Assert.Equal(receipt.Subtotal, subtotal);
            Assert.Equal(receipt.Discounts.Sum(i => i.Value), totalDiscount);
            Assert.Equal(receipt.Total, total);
        }

        [Fact]
        public void MultipleSoupsAndMoreBreadsThanDiscount()
        {
            List<BasketItem> basket = new List<BasketItem>
            {
                new BasketItem(_products["Soup"], 2), //0.65
                new BasketItem(_products["Bread"], 3) //0.8
            };
            CheckoutService checkout = new CheckoutService();

            decimal subtotal = basket.Sum(i => i.Product.Price * i.Quantity);
            decimal totalDiscount = checkout._discounts.Sum(rule => rule.ApplyDiscount(basket).Value);
            decimal total = subtotal - totalDiscount;

            Receipt receipt = checkout.PrintReceipt(basket);
            Assert.Equal(3.70m, subtotal);
            Assert.Equal(0.40m, totalDiscount);
            Assert.Equal(3.30m, total);
            Assert.Equal(receipt.Subtotal, subtotal);
            Assert.Equal(receipt.Discounts.Sum(i => i.Value), totalDiscount);
            Assert.Equal(receipt.Total, total);
        }
    }
}

