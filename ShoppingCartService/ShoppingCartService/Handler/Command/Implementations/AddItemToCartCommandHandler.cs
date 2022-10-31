using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Implementations
{
    public class AddItemToCartCommandHandler : IAddItemToCartCommandHandler
    {
        public Task<bool> Handle(AddItemCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
