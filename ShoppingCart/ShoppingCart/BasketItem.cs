using ShoppingCart.Interfaces;

namespace ShoppingCart
{
    public class BasketItem : IBasketItem
    {
        public BasketItem(IProduct product, int quantity)
        {
            Product = product;
            ProductQuantity = quantity;
            ItemTotalCost = product.Cost * quantity;
        }
        public IProduct Product { get; }
        public int ProductQuantity { get; }

        public decimal ItemTotalCost { get; set; }

        /// <summary>
        /// Update Item cost overload to update item price with offer
        /// </summary>
        /// <param name="quantityInOffer"></param>
        /// <param name="offerCost"></param>
        public void UpdateItemCost(int quantityInOffer, decimal offerCost)
        {
            ItemTotalCost = (Product.Cost * (ProductQuantity - quantityInOffer)) + (offerCost * quantityInOffer);
        }
        
    }
}