using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Interfaces
{
    public interface IUpdateQuantityCommandHandler
    {
        public Task<bool> Handle(UpdateQuantityCommand command);
    }
}
