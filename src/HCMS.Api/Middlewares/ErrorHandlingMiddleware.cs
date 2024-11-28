
using HCMS.Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HCMS.Api.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException notFound)
            {
                context.Response.StatusCode = 404;

                await context.Response.WriteAsync(notFound.Message);
            }
            catch(UserAlreadyExistsException exists) {

                context.Response.StatusCode = 409;
                await context.Response.WriteAsync(exists.Message);

            }

            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong...");
            }
        }
    }
}
