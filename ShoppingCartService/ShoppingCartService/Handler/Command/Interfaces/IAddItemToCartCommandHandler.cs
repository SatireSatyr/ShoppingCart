using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Interfaces
{
    public interface IAddItemToCartCommandHandler
    {
        public Task<bool> Handle(AddItemCommand command);
    }
}
