using LogisticControlSystemServer.Application.Interfaces;

namespace LogisticControlSystemServer.Presentation.Middlewares
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private ITokenValidationUseCase _useCase;

        public TokenAuthenticationMiddleware(RequestDelegate next, ITokenValidationUseCase useCase)
        {
            _next = next;
            _useCase = useCase;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestPath = context.Request.Path;

            if (requestPath != "/api/Authentication")
            {
                string? token = context.Request.Headers["Authorization"];
                
                if (string.IsNullOrEmpty(token))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Missing or invalid token.");
                    return;
                }
                else
                {
                    if (!_useCase.Invoke(Guid.Parse(token)))
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Missing or invalid token.");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
