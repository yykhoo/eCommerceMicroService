using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Microservice.Data;

namespace ShoppingCart.Microservice.Controllers
{

    [Route("api/{controller}")]
    [ApiController]
    [EnableCors("ShoppingCartMyPolicy")]
    public class CartItemController : ControllerBase
    {
        private IApplicationDbContext _context;
        public CartItemController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Model.CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChanges();
            return Ok(cartItem.CartItemId);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.CartItems.ToListAsync();
            if (categories == null) return NotFound();
            return Ok(categories);
        }
        [HttpGet]
        [Route("GetCartItemsByCartId/{cartId}")]
        public async Task<IActionResult> GetCartItemsByCartId(int cartId)
        {
            var cartItems = await _context.CartItems.Where(a => a.CartId == cartId).ToListAsync();
            if (cartItems == null) return NotFound();
            return Ok(cartItems);
        }
        [HttpGet]
        [Route("GetCartItemByProductId/{productId}")]
        public async Task<IActionResult> GetCartItemByProductId(int productId)
        {
            var cartItem = await _context.CartItems.Where(a => a.ProductId == productId).FirstOrDefaultAsync();

            if (cartItem == null) return NotFound();

            return Ok(cartItem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cartItem = await _context.CartItems.Where(a => a.CartItemId == id).FirstOrDefaultAsync();
            if (cartItem == null) return NotFound();
            _context.CartItems.Remove(cartItem);
            await _context.SaveChanges();
            return Ok(cartItem.CartItemId);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Model.CartItem cartItemData)
        {
            var cartItem = _context.CartItems.Where(a => a.CartItemId == cartItemData.CartId).FirstOrDefault();
            if (cartItem == null) return NotFound();
            else
            {
                cartItem.ProductId = cartItemData.ProductId;
                cartItem.Quantity = cartItemData.Quantity;

                await _context.SaveChanges();
                return Ok(cartItem.CartItemId);
            }
        }
        
    }
}
