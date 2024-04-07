using Microsoft.AspNetCore.Http.Extensions;

namespace LogisticControlSystemServer.Presentation.Middlewares
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogURLMiddleware> _logger;

        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            _logger.LogInformation($"[{context.Request.Method}] [{DateTime.Now}] Request URL: {context.Request.GetDisplayUrl()} Response code: {context.Response.StatusCode}");
        }
    }
}
