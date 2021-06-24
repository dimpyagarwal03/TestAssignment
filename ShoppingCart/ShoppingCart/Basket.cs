using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Interfaces;

namespace ShoppingCart
{
    public class Basket: IBasket
    {
        private readonly IList<IOffer> _offers;
        public Basket(IList<IOffer> offers)
        {
            _offers = offers;
        }
        public IList<IBasketItem> ItemList { get; set; }

        public void AddItem(IBasketItem item)
        {
            ItemList ??= new List<IBasketItem>();
            ItemList.Add(item);
        }

        public decimal CalculateBasketTotal()
        {
            if (ItemList?.Any() != true) return default;
            if (_offers?.Any() == true)
            {
                _offers.ToList().ForEach(offer => offer.ApplyOfferPriceOnBasketItem(ItemList));
            }

            return ItemList.Sum(x => x.ItemTotalCost);
        }
    }
}