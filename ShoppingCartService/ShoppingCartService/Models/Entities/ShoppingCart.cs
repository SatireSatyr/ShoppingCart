namespace ShoppingCartService.Models.Entities
{
    public class ShoppingCart
    {
        public long Id { get; set; }

        public List<ShoppingCartItem> Products { get; set; } = new();

        public decimal TotalPrice { get => Products.Sum(x => x.TotalPrice); }
        public long TotalProducts { get => Products.Sum(x => x.Quantity); }
    }
}
