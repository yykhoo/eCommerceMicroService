using Microsoft.EntityFrameworkCore;
using ShoppingCart.Microservice.Model;
using System.Threading.Tasks;

namespace ShoppingCart.Microservice.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Model.Cart> Carts { get; set; }
        public DbSet<Model.CartItem> CartItems { get; set; }
        Task<int> SaveChanges();
    }
}