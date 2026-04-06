using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace StudentCRUD.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                if (!context.Response.HasStarted)
                {
                    // Prefer JSON for clients that accept JSON, otherwise redirect to MVC error page
                    var acceptsJson = context.Request.Headers.Accept.Any(h => h.Contains("application/json"));
                    if (acceptsJson)
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        var payload = new
                        {
                            error = _env.IsDevelopment() ? ex.ToString() : "An unexpected error occurred."
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
                    }
                    else
                    {
                        context.Response.Redirect("/Home/Error");
                    }
                }
            }
        }
    }
}