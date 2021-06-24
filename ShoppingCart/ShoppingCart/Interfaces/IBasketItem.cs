namespace ShoppingCart.Interfaces
{
    public interface IBasketItem
    {
        /// <summary>
        /// Product 
        /// </summary>
         IProduct Product { get; }
        
        /// <summary>
        /// Product quantity
        /// </summary>
         int ProductQuantity { get; }
        
        /// <summary>
        /// An item total cost in basket considering total quantity of an item
        /// </summary>
         public decimal ItemTotalCost { get;  set; }

        /// <summary>
        /// Method declaration to update item cost with or without offers
        /// </summary>
        /// <param name="quantityInOffer"></param>
        /// <param name="offerCost"></param>
        void UpdateItemCost(int quantityInOffer=0, decimal offerCost=0);

    }
}