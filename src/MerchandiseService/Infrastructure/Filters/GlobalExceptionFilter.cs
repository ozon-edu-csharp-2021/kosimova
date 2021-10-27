using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MerchandiseService.Infrastructure.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionInfo = new
            {
                ExceptionType = context.Exception.GetType().FullName,
                StackTrace = context.Exception.StackTrace
            };

            var result = new JsonResult(exceptionInfo)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = result;
        }
    }
}