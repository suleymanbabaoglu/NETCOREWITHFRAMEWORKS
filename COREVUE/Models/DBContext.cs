using COREVUE.Models.Entities;
using COREVUE.Models.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace COREVUE.Models
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Customer_Product> Customer_Products { get; set; }

        public DBContext(IConfiguration configuration) : base()
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseMySql(configuration.GetSection("DbSettings:SqlConnection").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DefaultDatas(modelBuilder);
            RelationSettings(modelBuilder);
        }
        private void DefaultDatas(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Demo Product",
                    Brand = "Demo Brand",
                    SerialNumber = "SN112233"
                });
        }
        private void RelationSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Product>()
                .HasKey(s => new { s.CustomerId, s.ProductId });
            modelBuilder.Entity<Customer_Product>()
                .HasOne(s => s.Customer)
                .WithMany(s => s.Customer_Products)
                .HasForeignKey(s => s.CustomerId);
            modelBuilder.Entity<Customer_Product>()
                .HasOne(s => s.Product)
                .WithMany(s => s.Customer_Products)
                .HasForeignKey(s => s.ProductId);
        }
    }
}
