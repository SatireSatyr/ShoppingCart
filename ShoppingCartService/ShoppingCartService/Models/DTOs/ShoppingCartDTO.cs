namespace ShoppingCartService.Models.DTOs
{
    public class ShoppingCartDTO
    {
        public List<ShoppindCartItemDTO> Products { get; set; }
        public long ShoppingCartId { get; set; }
        public decimal TotalPrice { get => Products.Sum(x => x.TotalPrice); }
        public long TotalItems { get => Products.Sum(x => x.Quantity); }
    }
}
