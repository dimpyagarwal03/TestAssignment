namespace ShoppingCart.Products
{
    public class Bread : Product
    {
        public Bread(string name = Constants.Bread, decimal cost = Constants.BreadDefaultCost) : base(name, cost)
        {
        }
    }
}