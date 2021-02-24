using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace track_a_report_service.Exceptions
{
    public class HttpResponseExceptionFilter : ActionFilterAttribute
    {
        public new int Order { get; } = int.MaxValue - 10;

        public override void OnActionExecuting(ActionExecutingContext context) { }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var exceptionType = context.Exception;

            if (exceptionType == null)
                return;

            switch (exceptionType)
            {
                case AssetBadRequestException _:
                case AssetAlreadyExistsException _:
                    var exception = exceptionType as HttpResponseException;
                    context.Result = new ObjectResult(exception.Message)
                    {
                        StatusCode = exception.Status,
                    };
                    context.ExceptionHandled = true;
                    return;
                default:
                    context.Result = new ObjectResult(exceptionType.Message)
                    {
                        StatusCode = 500
                    };
                    context.ExceptionHandled = true;
                    return;
            }
        }
    }
}
