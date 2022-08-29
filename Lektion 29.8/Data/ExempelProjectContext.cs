using ExempelProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExempelProject.Data
{
    public class ExempelProjectContext :DbContext
    {
        private readonly IConfiguration config;

        public ExempelProjectContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);
            bldr.UseSqlServer(config.GetConnectionString("ExempleProjectContextDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                        .HasData(new Order()
                        {
                            Id = 1,
                            OrderDate = DateTime.Now,
                            OrderNumber="12345"
                        });
        }
    }
 
}
