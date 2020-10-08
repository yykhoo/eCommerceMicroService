using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Category.Microservice.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Category.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CategoryController : ControllerBase
    {
        private IApplicationDbContext _context;
        public CategoryController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Model.Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChanges();
            return Ok(category.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            if (categories == null) return NotFound();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (category == null) return NotFound();
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChanges();
            return Ok(category.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Model.Category categoryData)
        {
            var category = _context.Categories.Where(a => a.Id == id).FirstOrDefault();
            if (category == null) return NotFound();
            else
            {
                category.Description = categoryData.Description;

                await _context.SaveChanges();
                return Ok(category.Id);
            }
        }
    }
}
