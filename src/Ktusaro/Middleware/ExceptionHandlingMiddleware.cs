using Ktusaro.Core.Exceptions;
using Ktusaro.WebApp.Dtos;
using System.Net;
using System.Text.Json;

namespace Ktusaro.WebApp.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            ErrorResponse error;

            switch (exception)
            {
                case EntityNotFoundException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                    error = new ErrorResponse()
                    {
                        Reason = notFoundException.Reason,
                        Message = notFoundException.Message
                    };
                    break;
                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    error = new ErrorResponse()
                    {
                        Reason = validationException.Reason,
                        Message = validationException.Message
                    };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error = new ErrorResponse()
                    {
                        Reason = "InternalServerError",
                        Message = "Internal server error occured."
                    };
                    break;
            }

            return context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
