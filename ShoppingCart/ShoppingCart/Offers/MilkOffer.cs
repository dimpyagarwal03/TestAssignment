using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Offers
{
    public class MilkOffer: IOffer
    {
        private readonly int _minimumMilkQuantityForOffer = 3;
        private readonly int _freeMilkQuantity = 1;
        public void ApplyOfferPriceOnBasketItem(IList<IBasketItem> itemList)
        {
            if (itemList.Any(x => Constants.Milk.Equals(x.Product.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                var milkItem = itemList.First(x =>
                    Constants.Milk.Equals(x.Product.Name, StringComparison.InvariantCultureIgnoreCase));
                var totalMilkQuantity = milkItem.ProductQuantity;
                if (totalMilkQuantity <= _minimumMilkQuantityForOffer) return;
                var freeMilkQuantity = (totalMilkQuantity) / (_minimumMilkQuantityForOffer + _freeMilkQuantity);
                milkItem.UpdateItemCost(freeMilkQuantity, 0);
            }
        }
        
    }
}