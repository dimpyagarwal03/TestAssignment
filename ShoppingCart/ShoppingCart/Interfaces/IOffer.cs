using System.Collections.Generic;

namespace ShoppingCart.Interfaces
{
    public interface IOffer
    {
        /// <summary>
        /// Method declaration to apply adequate offers over the basket items
        /// </summary>
        /// <param name="itemList"></param>
        void ApplyOfferPriceOnBasketItem(IList<IBasketItem> itemList);
    }
}