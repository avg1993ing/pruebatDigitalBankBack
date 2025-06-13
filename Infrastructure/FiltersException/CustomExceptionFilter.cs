using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Infrastructure.FiltersException
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            HttpStatusCode Status = HttpStatusCode.InternalServerError;
            string Title = string.Empty;
            string Detail = string.Empty;
            if (exceptionContext.Exception.GetType() == typeof(InternalServerErrorBusinessExceptions))
            {
                var exception = (InternalServerErrorBusinessExceptions)exceptionContext.Exception;
                Status = HttpStatusCode.InternalServerError;
                Title = !string.IsNullOrEmpty(exception.Exception.Name) ? $"Internal Server Error {exception.Exception.Name}" : $"Not name";
                Detail = !string.IsNullOrEmpty(exception.Exception.Message) ? exception.Exception.Message : exception.Message;
            }
            if (exceptionContext.Exception.GetType() == typeof(BagRequestBusinessException))
            {
                var exception = (BagRequestBusinessException)exceptionContext.Exception;
                Status = HttpStatusCode.BadRequest;
                Title = !string.IsNullOrEmpty(exception.Exception.Name) ? $"BagRequest Server Error {exception.Exception.Name}" : $"Not name";
                Detail = !string.IsNullOrEmpty(exception.Exception.Message) ? exception.Exception.Message : exception.Message;
            }
            if (exceptionContext.Exception.GetType() == typeof(NotFoundException))
            {
                var exception = (NotFoundException)exceptionContext.Exception;
                Status = HttpStatusCode.NotFound;
                Title = !string.IsNullOrEmpty(exception.Exception.Name) ? $"NotFound Server Error {exception.Exception.Name}" : $"Not name";
                Detail = !string.IsNullOrEmpty(exception.Exception.Message) ? exception.Exception.Message : exception.Message;
            }
            var objectException = new
            {
                Status,
                Title,
                Detail
            };
            var json = new
            {
                errors = new[] { objectException }
            };
            
            exceptionContext.Result = new JsonResult(json);

            exceptionContext.HttpContext.Response.StatusCode = (int)Status;

            exceptionContext.ExceptionHandled = true;
        }
    }
}
