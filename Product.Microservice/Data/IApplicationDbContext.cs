using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Product.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Model.Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}