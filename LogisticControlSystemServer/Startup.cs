using LogisticControlSystemServer.Utils.Extensions;
using WebApplicationServer.Presentation.Habs;

namespace LogisticControlSystemServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {/*
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Swagger Demo API",
                    Description = "Demo API for showing Swagger",
                    Version = "v1"
                });
            });
            */

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddControllers();
            services.AddSignalR();

            services.AddInfrastructureLayer();
            services.AddApplicationLayer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
           /* app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                options.RoutePrefix = "";
            });*/

            app.UseLogUrl();
            app.UseTokenAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Order}/{action=GetAll}/{id?}");

                endpoints.MapHub<DeliveryPointNotificationHub>("/DeliveryPointNotificationHub");
                endpoints.MapHub<FlightNotificationHub>("/FlightNotificationHub");
                endpoints.MapHub<OrderNotificationHub>("/OrderNotificationHub");
                endpoints.MapHub<PackageNotificationHub>("/PackageNotificationHub");
                endpoints.MapHub<ProductDataNotificationHub>("/ProductDataNotificationHub");
                endpoints.MapHub<ProductNotificationHub>("/ProductNotificationHub");
                endpoints.MapHub<VehicleNotificationHub>("/VehicleNotificationHub");
                endpoints.MapHub<WarehouseNotificationHub>("/WarehouseNotificationHub");
            });
        }
    }
}