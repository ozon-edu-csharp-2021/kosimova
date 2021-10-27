using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;
        
        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.ContentType.Contains("grpc"))
                return;
            
            await _next(context);
            await LogResponse(context);
        }
        private async Task LogResponse(HttpContext context)
        {
            try
            {
                if (context.Response.Headers.Count > 0)
                {
                    var headerText = await GetResponseHeaderData(context);

                    var result = "Response log: \n";
                    result += "Route: " + context.Request.Path + '\n';
                    result += "Headers: \n" + headerText;
                    
                    _logger.LogInformation(result);
                }    
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Can't log response");
            }
            string path = context.Request.Path;
            var headers = context.Request.Headers.ToString();
        }

        private async Task<string> GetResponseHeaderData(HttpContext context)
        {
            string headerItems = string.Empty;
            foreach (var item in context.Response.Headers)
                headerItems += item.Key + ": "+ item.Value + '\n';
            return headerItems;
        }
    }
}