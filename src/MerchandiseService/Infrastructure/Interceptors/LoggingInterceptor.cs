using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Interceptors
{
    public class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var requestInfo = JsonSerializer.Serialize(request);
            var response = base.UnaryServerHandler(request, context, continuation);
            var responseInfo = JsonSerializer.Serialize(response);
            
            _logger.LogInformation(requestInfo);
            _logger.LogInformation(responseInfo);

            return response;
        }
    }
}