using ProductAPI.Models;

namespace ProductAPI
{
    public class GetProductQueryHandler : IGetProductQueryHandler
    {
        public Product? Handle(long productId)
        {
            return new Products()[productId];
        }

        public List<Product> GetProducts()
        {
            return new Products().GetProducts();
        }
    }
}