using System.ComponentModel.DataAnnotations;

namespace HRMS.MVC
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Call the next middleware in the pipeline
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            string message = "An unexpected error occurred.";

            switch (exception)
            {
                case ValidationException ve:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    message = ve.Message;
                    break;
                case KeyNotFoundException knf:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    message = knf.Message;
                    break;
                case UnauthorizedAccessException ue:
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    message = ue.Message;
                    break;
                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            return response.WriteAsync(new { error = message }.ToString());
        }
    }
}
