using System;
using MerchandiseService.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Infrastructure.StartupFilter
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/ready", builder => builder.UseMiddleware<IsReadyMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<IsLiveMiddleware>());
                app.UseMiddleware<RequestLoggingMiddleware>();
                app.UseMiddleware<ResponseLoggingMiddleware>();
                next(app);
            };
        }
    }
}