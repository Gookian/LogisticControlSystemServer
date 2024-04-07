using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Application.UseCases;
using LogisticControlSystemServer.Application;
using LogisticControlSystemServer.Domain.Entities;
using LogisticControlSystemServer.Infrastructure.Interfaces;
using LogisticControlSystemServer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogisticControlSystemServer.Utils.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<TokenManager>();
            services.AddSingleton<IAuthenticationUseCase, AuthenticationUseCase>();
            services.AddSingleton<ITokenValidationUseCase, TokenValidationUseCase>();

            return services;
        }
    }
}
