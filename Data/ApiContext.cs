using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data
{
    public class ApiContext : DbContext, IApiContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Processing> Processings { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().ToTable("order");
            builder.Entity<Order>().Property(o => o.Id).HasColumnName("id");
            builder.Entity<Order>().Property(o => o.SystemType).HasColumnName("system_type");
            builder.Entity<Order>().Property(o => o.OrderNumber).HasColumnName("order_number");
            builder.Entity<Order>().Property(o => o.SourceOrder).HasColumnName("source_order");
            builder.Entity<Order>().Property(o => o.ConvertedOrder).HasColumnName("converted_order");
            builder.Entity<Order>().Property(o => o.CreatedAt).HasColumnName("created_at");

            builder.Entity<Processing>().ToTable("process");
            builder.Entity<Processing>().HasKey(p=>p.Id);
            builder.Entity<Processing>().Property(p => p.Id).HasColumnName("id");
            builder.Entity<Processing>().Property(p => p.OrderId).HasColumnName("order_id");
            builder.Entity<Processing>().Property(p => p.Status).HasColumnName("status");

            builder.Entity<Choice>().ToTable("choice");
            builder.Entity<Choice>().Property(c => c.Id).HasColumnName("id");
            builder.Entity<Choice>().Property(c => c.Key).HasColumnName("key");
            builder.Entity<Choice>().Property(c => c.Value).HasColumnName("value");

            base.OnModelCreating(builder);
        }


    }
}