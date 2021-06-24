using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Offers
{
    public class ButterOfferWithBread : IOffer
    {
        private readonly int _minimumButterQuantityForOffer = 2;
        private readonly int _minimumBreadQuantityForOffer = 1;
        public void ApplyOfferPriceOnBasketItem(IList<IBasketItem> itemList)
        {
            if (itemList.Any(x => Constants.Butter.Equals(x.Product.Name, StringComparison.InvariantCultureIgnoreCase))
            && itemList.Any(x => Constants.Bread.Equals(x.Product.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                var butterItem = itemList.First(x =>
                    Constants.Butter.Equals(x.Product.Name, StringComparison.InvariantCultureIgnoreCase));
                var breadItem = itemList.First(x =>
                    Constants.Bread.Equals(x.Product.Name, StringComparison.InvariantCultureIgnoreCase));
                
                if (butterItem.ProductQuantity < _minimumButterQuantityForOffer &&
                    breadItem.ProductQuantity < _minimumBreadQuantityForOffer) return;
                
                 var discountedBreadQuantity = (butterItem.ProductQuantity) / (_minimumButterQuantityForOffer);

                 discountedBreadQuantity = discountedBreadQuantity > breadItem.ProductQuantity
                     ? breadItem.ProductQuantity
                     : discountedBreadQuantity;
                 
                 breadItem.UpdateItemCost(discountedBreadQuantity,breadItem.Product.Cost/2);
            }
        }
    }
}