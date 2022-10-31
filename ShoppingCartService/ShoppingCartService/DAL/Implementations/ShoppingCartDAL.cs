using ShoppingCartService.DAL.Interfaces;
using ShoppingCartService.Models.Entities;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace ShoppingCartService.DAL.Implementations
{
    public class ShoppingCartDAL : IShoppingCartDAL
    {
        private readonly IRedisClient client;

        public ShoppingCartDAL(
            IRedisClient client)
        {
            this.client = client;
        }

        public Task<ShoppingCart?> GetShoppingCart(long id)
        {
            return client
                .GetDefaultDatabase()
                .GetAsync<ShoppingCart>(GetKey<ShoppingCart>(id));
        }

        public Task UpsertShoppingCart(ShoppingCart cart)
        {
            return client
                .GetDefaultDatabase()
                .SetAddAsync(GetKey<ShoppingCart>(cart.Id), cart);
        }

        private string GetKey<T>(long id)
        {
            return $"{typeof(T).Name}_{id}";
        }
    }
}
