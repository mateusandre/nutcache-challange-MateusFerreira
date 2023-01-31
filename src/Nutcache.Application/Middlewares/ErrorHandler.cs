using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Nutcache.Application.Middlewares.Responses;
using System.Net;
using System.Net.Mime;

namespace Nutcache.Application.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(httpContext, ex);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new ErrorResponse();
            errorResponse.Message = exception.Message;

            switch (exception)
            {
                case KeyNotFoundException:
                    errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    break; 
                case ArgumentNullException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
