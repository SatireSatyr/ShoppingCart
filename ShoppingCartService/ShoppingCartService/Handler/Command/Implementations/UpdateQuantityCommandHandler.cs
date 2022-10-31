using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Implementations
{
    public class UpdateQuantityQueryHandler : IUpdateQuantityCommandHandler
    {
        public Task<bool> Handle(UpdateQuantityCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
