using Microsoft.AspNetCore.Mvc;
using ShoppingCartService.Handler.Command.Interfaces;
using ShoppingCartService.Handler.Query.Interfaces;
using ShoppingCartService.Models.Commands;
using ShoppingCartService.Models.DTOs;
using ShoppingCartService.Models.Entities;

namespace ShoppingCartService.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]/{cartId}")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IAddItemToCartCommandHandler addItemCommand;
        private readonly IUpdateQuantityCommandHandler updateQuantityCommand;
        private readonly IRemoveItemCommandHandler removeItemCommand;
        private readonly IGetCartQueryHandler getCartQuery;

        public CartController(
            IAddItemToCartCommandHandler addItemCommand,
            IUpdateQuantityCommandHandler updateQuantityCommand,
            IRemoveItemCommandHandler removeItemCommand,
            IGetCartQueryHandler getCartQuery)
        {
            this.addItemCommand = addItemCommand;
            this.updateQuantityCommand = updateQuantityCommand;
            this.removeItemCommand = removeItemCommand;
            this.getCartQuery = getCartQuery;
        }

        [ProducesResponseType(200, Type=typeof(ShoppingCart))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCart([FromRoute] long cartId)
        {
            var cart = await getCartQuery.Handle(cartId);

            return Ok(cart);
        }

        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPost]
        [Route("add/{productId}")]
        public async Task<IActionResult> AddItemToCart([FromRoute] long cartId, [FromRoute] long productId)
        {
            if (await addItemCommand.Handle(new AddItemCommand { CartId = cartId, ProductId = productId }))
                return Accepted();
            else
                return NotFound();
        }

        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut]
        [Route("update/{productId}")]
        public async Task<IActionResult> UpdateQuantity([FromRoute] long cartId, [FromRoute] long productId, [FromQuery] long quantity)
        {
            if (await updateQuantityCommand.Handle(new UpdateQuantityCommand { CartId = cartId, ProductId = productId, Quantity = quantity }))
                return Accepted();
            else
                return NotFound();
        }

        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpDelete]
        [Route("remove/{productId}")]
        public async Task<IActionResult> RemoveItemFromCart([FromRoute] long cartId, [FromRoute] long productId)
        {
            if (await removeItemCommand.Handle(new RemoveItemCommand { CartId = cartId, ProductId = productId }))
                return Accepted();
            else
                return NotFound();
        }
    }
}
