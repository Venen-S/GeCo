using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Threading.Tasks;

namespace Data
{
    public interface IApiContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Processing> Processings { get; set; }
        DbSet<Choice> Choices { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}