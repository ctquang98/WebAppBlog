using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace AppBlog.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            } catch (Exception ex)
            {
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var json = JsonSerializer.Serialize(new
                {
                    statusCode = statusCode,
                    message = ex.Message,
                });

                logger.LogError(ex, ex.Message);
                httpContext.Response.StatusCode = statusCode;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
