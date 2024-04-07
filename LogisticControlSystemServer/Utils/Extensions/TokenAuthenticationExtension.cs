using LogisticControlSystemServer.Presentation.Middlewares;

namespace LogisticControlSystemServer.Utils.Extensions
{
    public static class TokenAuthenticationExtension
    {
        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TokenAuthenticationMiddleware>();
        }
    }
}
