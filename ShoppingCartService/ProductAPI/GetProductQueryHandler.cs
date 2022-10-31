using ProductAPI.Models;

namespace ProductAPI
{
    public class GetProductQueryHandler : IGetProductQueryHandler
    {
        public Task<Product?> Handle(long productId)
        {
            return Task.FromResult(new Products()[productId]);
        }

        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(new Products().GetProducts());
        }
    }
}