﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Data;
using Product.Microservice.Model;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ProductCorsPolicy")]
    public class ProductController : ControllerBase
    {
        private IApplicationDbContext _context;
        public ProductController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Model.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChanges();
            return Ok(product.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null) return NotFound();
            return Ok(products);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("CategoryId/{CategoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var products = await _context.Products.Where(a => a.CategoryId == categoryId).ToListAsync();
            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChanges();
            return Ok(product.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Model.Product productData)
        {
            var product = _context.Products.Where(a => a.Id == id).FirstOrDefault();
            if (product == null) return NotFound();
            else
            {
                product.Name = productData.Name;
                product.Description = productData.Description;
                product.Price = productData.Price;
                product.Rating = productData.Rating;
                product.Stock_Available = productData.Stock_Available;
                product.Url = productData.Url;

                await _context.SaveChanges();
                return Ok(product.Id);
            }
        }
    }
}
