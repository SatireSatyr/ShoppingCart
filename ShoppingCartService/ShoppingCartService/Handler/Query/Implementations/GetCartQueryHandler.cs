using ShoppingCartService.Handler.Query.Interfaces;
using ShoppingCartService.Models.DTOs;
using ShoppingCartService.Models.Entities;

namespace ShoppingCartService.Handler.Query.Implementations
{
    public class GetCartQueryHandler : IGetCartQueryHandler
    {
        public Task<ShoppingCartDTO> Handle(long id)
        {
            throw new NotImplementedException();
        }
    }
}
