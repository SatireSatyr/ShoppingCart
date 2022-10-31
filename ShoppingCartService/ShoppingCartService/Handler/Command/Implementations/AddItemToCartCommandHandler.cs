using ProductAPI;
using ProductAPI.Models;
using ShoppingCartService.DAL.Interfaces;
using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Models.Commands;
using ShoppingCartService.Models.Entities;

namespace ShoppingCartService.Handler.Command.Implementations
{
    public class AddItemToCartCommandHandler : IAddItemToCartCommandHandler
    {
        private readonly IShoppingCartDAL shoppingCartDAL;
        private readonly IGetProductQueryHandler getProductQueryHandler;

        public AddItemToCartCommandHandler(
            IShoppingCartDAL shoppingCartDAL,
            IGetProductQueryHandler getProductQueryHandler)
        {
            this.shoppingCartDAL = shoppingCartDAL;
            this.getProductQueryHandler = getProductQueryHandler;
        }

        public async Task<bool> Handle(AddItemCommand command)
        {
            var cart = await shoppingCartDAL.GetShoppingCart(command.CartId);

            if (cart == null) 
                return false;

            if (cart.Products.Any(x => x.ProductId == command.ProductId))
            {
                var product = cart.Products.FirstOrDefault(x => x.ProductId == command.ProductId);
                product.Quantity++;
            }
            else
            {
                var product = await getProductQueryHandler.Handle(command.ProductId);

                cart.Products.Add(new ShoppingCartItem
                {
                    ProductId = product.Id,
                    IndividualProductPrice = product.Price,
                    Quantity = 1
                });
            }

            await shoppingCartDAL.UpsertShoppingCart(cart);

            return true;
        }
    }
}
