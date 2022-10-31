using ShoppingCartService.Models.DTOs;
using ShoppingCartService.Models.Entities;

namespace ShoppingCartService.Handler.Query.Interfaces
{
    public interface IGetCartQueryHandler
    {
        public Task<ShoppingCartDTO> Handle(long id);
    }
}
