using Common.Wrappers;
using Microsoft.AspNetCore.Http;

namespace Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = new HttpResponse<string>
                {
                    Succeeded = false,
                    ErrorMessage = ex.Message
                };

                switch (ex)
                {
                    case FluentValidation.ValidationException e:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        response.ValidationErrors = e.Errors.Select(x => x.ErrorMessage).ToList();
                        break;
                    case System.ComponentModel.DataAnnotations.ValidationException:
                    case BadHttpRequestException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case KeyNotFoundException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                response.ErrorCode = context.Response.StatusCode;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}