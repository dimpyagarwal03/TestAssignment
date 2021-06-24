using System.Collections.Generic;

namespace ShoppingCart.Interfaces
{
    public interface IBasket
    {
        /// <summary>
        /// List of all items in the basket
        /// </summary>
        public IList<IBasketItem> ItemList { get; set; }

        /// <summary>
        /// Method declaration to add new item in basket
        /// </summary>
        /// <param name="item"></param>
        void AddItem(IBasketItem item);

        /// <summary>
        /// Method declaration to calculate total price of all the items in basket
        /// </summary>
        /// <returns></returns>
        decimal CalculateBasketTotal();
    }
}