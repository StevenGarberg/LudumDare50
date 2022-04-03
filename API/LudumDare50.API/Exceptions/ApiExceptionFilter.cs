using LudumDare50.API.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LudumDare50.API.Exceptions;

public class ApiExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order { get; } = int.MaxValue - 10;
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is not ApiException exception) return;
            
        context.Result = new ObjectResult(
            new ErrorResponse
            {
                Message = exception.Message
            })
        {
            StatusCode = exception.StatusCode,
        };
        context.ExceptionHandled = true;
    }
}