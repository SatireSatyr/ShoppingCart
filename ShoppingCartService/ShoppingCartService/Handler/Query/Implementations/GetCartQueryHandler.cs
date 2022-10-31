using ProductAPI;
using ShoppingCartService.DAL.Interfaces;
using ShoppingCartService.Handler.Query.Interfaces;
using ShoppingCartService.Models.DTOs;
using ShoppingCartService.Models.Entities;

namespace ShoppingCartService.Handler.Query.Implementations
{
    public class GetCartQueryHandler : IGetCartQueryHandler
    {
        private readonly IShoppingCartDAL shoppingCartDAL;
        private readonly IGetProductQueryHandler getProductQueryHandler;

        public GetCartQueryHandler(
            IShoppingCartDAL shoppingCartDAL,
            IGetProductQueryHandler getProductQueryHandler)
        {
            this.shoppingCartDAL = shoppingCartDAL;
            this.getProductQueryHandler = getProductQueryHandler;
        }

        public async Task<ShoppingCartDTO?> Handle(long id)
        {
            var shoppingCart = await shoppingCartDAL.GetShoppingCart(id);

            if (shoppingCart == null)
                return null;

            var products = new Dictionary<long, ProductDTO>();

            foreach (var item in shoppingCart.Products)
                if (!products.ContainsKey(item.ProductId))
                {
                    var product = await getProductQueryHandler.Handle(item.ProductId);

                    products.Add(item.ProductId, new ProductDTO
                    {
                        Price = product.Price,
                        Description = product.Description,
                        Id = product.Id,
                        Name = product.Name,
                    });
                 }

            return new ShoppingCartDTO
            {
                Products = shoppingCart.Products.Select(x => new ShoppindCartItemDTO
                {
                    IndividualProductPrice = x.IndividualProductPrice,
                    ProductId = x.ProductId,
                    Product = products.GetValueOrDefault(x.ProductId),
                    Quantity = x.Quantity
                }).ToList(),
                ShoppingCartId = shoppingCart.Id
            };
        }
    }
}
