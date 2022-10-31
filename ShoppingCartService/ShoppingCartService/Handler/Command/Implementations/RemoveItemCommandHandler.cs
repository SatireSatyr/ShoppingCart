using ProductAPI;
using ShoppingCartService.DAL.Interfaces;
using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Implementations
{
    public class RemoveItemCommandHandler : IRemoveItemCommandHandler
    {
        public IShoppingCartDAL shoppingCartDAL { get; set; }

        public RemoveItemCommandHandler(
            IShoppingCartDAL shoppingCartDAL)
        {
            this.shoppingCartDAL = shoppingCartDAL;
        }

        public async Task<bool> Handle(RemoveItemCommand command)
        {
            var cart = await shoppingCartDAL.GetShoppingCart(command.CartId);

            if (cart == null || cart.Products.All(x => x.ProductId != command.ProductId))
                return false;

            cart.Products.RemoveAll(x => x.ProductId == command.ProductId);

            await shoppingCartDAL.UpsertShoppingCart(cart);

            return true;
        }
    }
}
