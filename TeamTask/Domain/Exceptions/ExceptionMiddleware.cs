using Microsoft.AspNetCore.Diagnostics;

namespace ShopApi.Exceptions
{
    public class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(IApplicationBuilder app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    context.Response.ContentType = "application/json";

                    if (exception is NotFoundException)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsync($"{{\"error\": \"{exception.Message}\"}}");
                    }
                    else if (exception is ConflictException)
                    {
                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                        await context.Response.WriteAsync($"{{\"error\": \"{exception.Message}\"}}");
                    }
                    else if (exception is ArgumentNullException)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync($"{{\"error\": \"{exception.Message}\"}}");
                    }
                    else if (exception is UnauthorizedException)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync($"{{\"error\": \"{exception.Message}\"}}");
                    }
                    else if (exception is BadRequestException)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync($"{{\"error\": \"{exception.Message}\"}}");
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync("{\"error\": \"Ocurrió un error inesperado\"}");
                    }
                });
            });
        }
    }
}
