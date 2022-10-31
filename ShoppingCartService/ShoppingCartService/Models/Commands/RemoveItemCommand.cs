namespace ShoppingCartService.Models.Commands
{
    public class RemoveItemCommand
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
