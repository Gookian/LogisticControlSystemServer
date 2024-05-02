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

            context.Request.EnableBuffering();
            var bodyAsText = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;

            if (context.Response.StatusCode == 200)
            {
                _logger.LogInformation($"[{context.Request.Method}] [{DateTime.Now}] Request URL: {context.Request.GetDisplayUrl()} Response code: {context.Response.StatusCode}  Reqest Body: {bodyAsText}");
            }
            else
            {
                _logger.LogError($"[{context.Request.Method}] [{DateTime.Now}] Request URL: {context.Request.GetDisplayUrl()} Response code: {context.Response.StatusCode} Reqest Body: {bodyAsText} Response Body: {context.Response.Body.ToString()}");
            }
        }
    }
}
