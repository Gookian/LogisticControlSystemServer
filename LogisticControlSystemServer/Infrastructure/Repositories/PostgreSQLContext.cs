using Microsoft.EntityFrameworkCore;
using LogisticControlSystemServer.Domain.Entities;

namespace LogisticControlSystemServer.Infrastructure.Repositories
{
    public class PostgreSQLContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPickUpPoint> OrderPickUpPoints { get; set; }
        public DbSet<ProductData> ProductDatas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductState> ProductStates { get; set; }
        public DbSet<SortingCenter> SortingCenters { get; set; }
        public DbSet<ProductInWarehouse> ProductInWarehouses { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageСontent> PackageСontents { get; set; }
        public DbSet<PackageState> PackageStates { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<Delivery> Delivery { get; set; }

        public PostgreSQLContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Server=localhost;Port=5432;Database=logistics_control_system_database;User Id=postgres;Password=root");
        }
    }
}