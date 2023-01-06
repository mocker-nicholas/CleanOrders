using CleanOrders.API.ApiDtos;
using System.Text.Json;

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
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (ex.Message.Contains("not found"))
                context.Response.StatusCode = 404;
            else
            {
                context.Response.StatusCode = 500;
            }
            var error = JsonSerializer.Serialize(new GlobalErrorMessage(ex.Message));
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(error);
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