using LogExample.Controllers;

namespace LogExample
{
    public class ErrorLogMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorLogMiddleware> _logger;

        public ErrorLogMiddleware(RequestDelegate next, ILogger<ErrorLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = 500;
                
                await httpContext.Response.WriteAsync(ex.Message);

                _logger.LogError("Sistem hatası: " + ex.Message);
            }
        }
    }
}
