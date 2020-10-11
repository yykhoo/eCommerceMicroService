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

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ShoppingCartMyPolicy")]
    public class CartController : ControllerBase
    {
        private IApplicationDbContext _context;
        public CartController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Model.Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChanges();
            return Ok(cart.CartId);
        }
        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetByCartId(int cartId)
        {
            var cart = await _context.Carts.Where(a => a.CartId == cartId).FirstOrDefaultAsync();
            if (cart == null) return NotFound();
            return Ok(cart);
        }
        [HttpDelete("{cartId}")]
        public async Task<IActionResult> Delete(int cartId)
        {
            var cart = await _context.Carts.Where(a => a.CartId == cartId).FirstOrDefaultAsync();
            if (cart == null) return NotFound();
            _context.Carts.Remove(cart);
            await _context.SaveChanges();
            return Ok(cart.CartId);
        }

    }

}

