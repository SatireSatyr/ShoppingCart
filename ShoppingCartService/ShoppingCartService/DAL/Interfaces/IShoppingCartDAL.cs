using ShoppingCartService.Models.Entities;

namespace ShoppingCartService.DAL.Interfaces
{
    public interface IShoppingCartDAL
    {
        Task<ShoppingCart?> GetShoppingCart(long id);
        Task UpsertShoppingCart(ShoppingCart cart);
    }
}
