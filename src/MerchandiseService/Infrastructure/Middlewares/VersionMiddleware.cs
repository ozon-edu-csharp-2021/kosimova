using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
            
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = new
            {
                version =  Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version",
                serviceName = Assembly.GetExecutingAssembly().GetName().Name?.ToString() ?? "unknown"
            };
            await context.Response.WriteAsync(version.ToString() ?? string.Empty);
        }
    }
}