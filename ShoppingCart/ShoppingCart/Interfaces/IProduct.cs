namespace ShoppingCart.Interfaces
{
    public interface IProduct
    {
        /// <summary>
        /// Product Name
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// Product Cost
        /// </summary>
        decimal Cost { get; set; }
    }
}