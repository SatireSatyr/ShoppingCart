using ShoppingCartService.DAL.Interfaces;
using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Models.Commands;

namespace ShoppingCartService.Handler.Command.Implementations
{
    public class UpdateQuantityQueryHandler : IUpdateQuantityCommandHandler
    {
        private readonly IShoppingCartDAL shoppingCartDAL;

        public UpdateQuantityQueryHandler(
            IShoppingCartDAL shoppingCartDAL)
        {
            this.shoppingCartDAL = shoppingCartDAL;
        }

        public async Task<bool> Handle(UpdateQuantityCommand command)
        {
            var cart = await shoppingCartDAL.GetShoppingCart(command.CartId);

            if (cart == null || cart.Products.All(x => x.ProductId != command.ProductId))
                return false;

            var item = cart.Products.FirstOrDefault(x => x.ProductId == command.ProductId);

            item.Quantity = command.Quantity;

            await shoppingCartDAL.UpsertShoppingCart(cart);

            return true;
        }
    }
}
