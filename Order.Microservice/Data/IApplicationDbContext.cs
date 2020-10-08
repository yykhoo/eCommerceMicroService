using System.Threading.Tasks;

namespace Order.Microservice.Data
{
    public interface IApplicationDbContext
    {
        Microsoft.EntityFrameworkCore.DbSet<Model.OrderDetail> OrderDetail { get; set; }
        Microsoft.EntityFrameworkCore.DbSet<Model.Order> Orders { get; set; }

        Task<int> SaveChanges();
    }
}