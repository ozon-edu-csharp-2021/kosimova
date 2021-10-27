using System;
using System.IO;
using System.Reflection;
using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.StartupFilter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MerchandiseService.Infrastructure.Extentions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
            });
            return builder;
        }
        
        public static IHostBuilder AddHttp(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            });
            return builder;
        }
    }
}