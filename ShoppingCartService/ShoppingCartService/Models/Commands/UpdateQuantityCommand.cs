namespace ShoppingCartService.Models.Commands
{
    public class UpdateQuantityCommand
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
    }
}
