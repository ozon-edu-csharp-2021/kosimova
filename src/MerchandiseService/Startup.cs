using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchandiseService.Infrastructure.Interceptors;
using MerchandiseService.Infrastructure.StartupFilter;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MerchandiseService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMerchandiseService, Services.MerchandiseService>();
            services.AddGrpc(opt => opt.Interceptors.Add<LoggingInterceptor>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<Services.MerchandiseService>();
                endpoints.MapControllers();
            });
        }
    }
}