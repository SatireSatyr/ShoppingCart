using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Interfaces
{
    public interface IRemoveItemCommandHandler
    {
        public Task<bool> Handle(RemoveItemCommand command);
    }
}
