namespace ShoppingCartService.Models.Commands
{
    public class AddItemCommand
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
