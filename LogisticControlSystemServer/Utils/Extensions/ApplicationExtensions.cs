using LogisticControlSystemServer.Application.Interfaces;
using LogisticControlSystemServer.Application.UseCases;
using LogisticControlSystemServer.Application;

namespace LogisticControlSystemServer.Utils.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<TokenManager>();
            services.AddSingleton<IRegistrationUseCase, RegistrationUseCase>();
            services.AddSingleton<IAuthenticationUseCase, AuthenticationUseCase>();
            services.AddSingleton<IRemoveAuthenticationUseCase, RemoveAuthenticationUseCase>();
            services.AddSingleton<ITokenValidationUseCase, TokenValidationUseCase>();

            return services;
        }
    }
}
