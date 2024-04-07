using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using LogisticControlSystemServer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogisticControlSystemServer.Utils.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddSingleton<DbContext, PostgreSQLContext>();
            services.AddSingleton<IRepository<User>, EntityFrameworkRepository<User>>();
            services.AddSingleton<IRepository<Delivery>, EntityFrameworkRepository<Delivery>>();
            services.AddSingleton<IRepository<DeliveryPoint>, EntityFrameworkRepository<DeliveryPoint>>();
            services.AddSingleton<IRepository<Flight>, EntityFrameworkRepository<Flight>>();
            services.AddSingleton<IRepository<Order>, EntityFrameworkRepository<Order>>();
            services.AddSingleton<IRepository<OrderDetail>, EntityFrameworkRepository<OrderDetail>>();
            services.AddSingleton<IRepository<Package>, EntityFrameworkRepository<Package>>();
            services.AddSingleton<IRepository<PackageState>, EntityFrameworkRepository<PackageState>>();
            services.AddSingleton<IRepository<PackageСontent>, EntityFrameworkRepository<PackageСontent>>();
            services.AddSingleton<IRepository<Product>, EntityFrameworkRepository<Product>>();
            services.AddSingleton<IRepository<ProductData>, EntityFrameworkRepository<ProductData>>();
            services.AddSingleton<IRepository<ProductInWarehouse>, EntityFrameworkRepository<ProductInWarehouse>>();
            services.AddSingleton<IRepository<ProductState>, EntityFrameworkRepository<ProductState>>();
            services.AddSingleton<IRepository<Vehicle>, EntityFrameworkRepository<Vehicle>>();
            services.AddSingleton<IRepository<Warehouse>, EntityFrameworkRepository<Warehouse>>();

            return services;
        }
    }
}
