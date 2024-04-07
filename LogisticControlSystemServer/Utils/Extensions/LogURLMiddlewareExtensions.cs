using LogisticControlSystemServer.Presentation.Middlewares;

namespace LogisticControlSystemServer.Utils.Extensions
{
    public static class LogURLMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogURLMiddleware>();
        }
    }
}
