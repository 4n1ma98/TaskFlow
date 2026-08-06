using Models.Common;
using Models.Responses;
using System.Net;

namespace Api_TaskFlow.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
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
                // Registras el log si lo deseas
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = GenericResult.ErrorResult(ResultCode.InternalError, "Ocurrió un error inesperado en el servidor.");
                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
