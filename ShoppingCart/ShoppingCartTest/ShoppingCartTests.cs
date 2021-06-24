using System.Collections.Generic;
using ShoppingCart;
using ShoppingCart.Interfaces;
using ShoppingCart.Offers;
using ShoppingCart.Products;
using Xunit;

namespace ShoppingCartTest
{
    public class ShoppingCartTests
    {

        [Theory]
        [InlineData(1, 1, 1, 2.95)]
        [InlineData(2, 1, 2, 5.1)]
        public void Basket_With_No_Offer_Test(int breadQuantity, int butterQuantity, int milkQuantity,
            decimal expectedOutcome)
        {
            // Arrange
            var offers = new List<IOffer>();
            var basket = GetSut(breadQuantity, butterQuantity, milkQuantity, offers);

            // Act
            var total = basket.CalculateBasketTotal();

            // Assert
            Assert.Equal(expectedOutcome, total);
        }

        [Theory]
        [InlineData(0, 0, 4, 3.45)]
        [InlineData(0, 0, 11, 10.35)]
        public void Basket_With_Milk_Offer_Test(int breadQuantity, int butterQuantity, int milkQuantity,
            decimal expectedOutcome)
        {
            // Arrange
            var offers = new List<IOffer> {new MilkOffer()};
            var basket = GetSut(breadQuantity, butterQuantity, milkQuantity, offers);

            // Act
            var total = basket.CalculateBasketTotal();

            // Assert
            Assert.Equal(expectedOutcome, total);
        }

        [Theory]
        [InlineData(2, 2, 0, 3.10)]
        public void Basket_With_Butter_Offer_Test(int breadQuantity, int butterQuantity, int milkQuantity,
            decimal expectedOutcome)
        {
            // Arrange
            var offers = new List<IOffer> {new ButterOfferWithBread()};
            var basket = GetSut(breadQuantity, butterQuantity, milkQuantity, offers);

            // Act
            var total = basket.CalculateBasketTotal();

            // Assert
            Assert.Equal(expectedOutcome, total);
        }

        [Theory]
        [InlineData(1, 2, 8, 9.00)]
        public void Basket_With_Both_Offer_Test(int breadQuantity, int butterQuantity, int milkQuantity,
            decimal expectedOutcome)
        {
            // Arrange
            var offers = new List<IOffer> {new ButterOfferWithBread(),new MilkOffer()};
            var basket = GetSut(breadQuantity, butterQuantity, milkQuantity, offers);

            // Act
            var total = basket.CalculateBasketTotal();

            // Assert
            Assert.Equal(expectedOutcome, total);
        }
        
        /// <summary>
        /// Method to get system under test i.e. basket
        /// </summary>
        /// <param name="breadQuantity"></param>
        /// <param name="butterQuantity"></param>
        /// <param name="milkQuantity"></param>
        /// <param name="offers"></param>
        /// <returns></returns>
        private static IBasket GetSut(int breadQuantity, int butterQuantity, int milkQuantity, IList<IOffer> offers)
        {
            IBasket basket = new Basket(offers);
            basket.AddItem(new BasketItem(new Bread(), breadQuantity));
            basket.AddItem(new BasketItem(new Butter(), butterQuantity));
            basket.AddItem(new BasketItem(new Milk(), milkQuantity));
            return basket;
        }
        
    }
}