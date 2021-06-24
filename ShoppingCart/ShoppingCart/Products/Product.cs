using ShoppingCart.Interfaces;

namespace ShoppingCart.Products
{
    public abstract class Product:IProduct
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        protected Product(string name,decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}