using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Implementations
{
    public class RemoveItemCommandHandler : IRemoveItemCommandHandler
    {
        public Task<bool> Handle(RemoveItemCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
