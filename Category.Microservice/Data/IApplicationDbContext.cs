using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Category.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Model.Category> Categories { get; set; }

        Task<int> SaveChanges();
    }
}