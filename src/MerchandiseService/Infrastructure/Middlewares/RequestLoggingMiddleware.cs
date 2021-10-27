using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }
        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Headers.Count > 0)
                {
                    var headerText = await GetRequestHeaderData(context);

                    var result = "Request log: \n";
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

        private async Task<string> GetRequestHeaderData(HttpContext context)
        {
            string headerItems = string.Empty;
            foreach (var item in context.Request.Headers)
                headerItems += item.Key + ": "+ item.Value + '\n';
            return headerItems;
        }
    }
}