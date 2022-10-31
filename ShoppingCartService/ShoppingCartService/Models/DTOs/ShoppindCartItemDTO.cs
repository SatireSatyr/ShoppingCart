using ShoppingCartService.Models.Entities;

namespace ShoppingCartService.Models.DTOs
{
    public class ShoppindCartItemDTO : ShoppingCartItem
    {
        public ProductDTO Product { get; set; }
    }
}
