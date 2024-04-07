using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Application.UseCases;
using LogisticControlSystemServer.Application;
using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using LogisticControlSystemServer.Infrastructure.Repositories;
using LogisticControlSystemServer.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LogisticControlSystemServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
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

            services.AddControllers();

            services.AddInfrastructureLayer();
            services.AddApplicationLayer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                options.RoutePrefix = "";
            });

            app.UseLogUrl();
            app.UseTokenAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Order}/{action=GetAll}/{id?}");
            });
        }
    }
}