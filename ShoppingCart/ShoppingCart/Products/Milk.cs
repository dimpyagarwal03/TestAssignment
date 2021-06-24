namespace ShoppingCart.Products
{
    public class Milk : Product
    {
        public Milk(string name = Constants.Milk, decimal cost = Constants.MilkDefaultCost) : base(name, cost)
        {
        }
    }
}