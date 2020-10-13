using Gupy.Core.Interfaces.Data.UnitOfWork;
using Gupy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gupy.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TelegramUser> TelegramUsers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}