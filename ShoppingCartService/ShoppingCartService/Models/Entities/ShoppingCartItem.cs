namespace ShoppingCartService.Models.Entities
{
    public class ShoppingCartItem
    {
        public long ProductId { get; set; }
        public decimal IndividualProductPrice { get; set; }
        public decimal TotalPrice { get => IndividualProductPrice * Quantity; }
        public long Quantity { get; set; } 
    }
}
