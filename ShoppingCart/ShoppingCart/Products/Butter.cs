namespace ShoppingCart.Products
{
    public class Butter : Product
    {
        public Butter(string name = Constants.Butter, decimal cost = Constants.ButterDefaultCost) : base(name, cost)
        {
        }
    }
}