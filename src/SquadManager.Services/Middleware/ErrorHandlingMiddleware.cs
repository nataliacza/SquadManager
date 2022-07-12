using Microsoft.AspNetCore.Http;
using SquadManager.Services.Exceptions;


namespace SquadManager.Services.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = 404;
        }
        catch (ConflictException ex)
        {
            context.Response.StatusCode = 409;
        }
    }
}
