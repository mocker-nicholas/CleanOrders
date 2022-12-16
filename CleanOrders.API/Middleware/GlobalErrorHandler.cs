using Microsoft.AspNetCore.Diagnostics;

namespace CleanOrders.API.Middleware
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            var exceptionHandlerPathFeature =
           context.Features.Get<IExceptionHandlerPathFeature>();

            if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
            {
                await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.ToString());
            }
        }
    }
    public static class GlobalErrorHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandler(
                  this IApplicationBuilder builder
            )
        {
            return builder.UseMiddleware<GlobalErrorHandler>();
        }
    }
}