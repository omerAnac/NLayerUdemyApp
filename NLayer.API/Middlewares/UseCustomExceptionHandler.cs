using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {

        public static void UseCustomException (this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exeptionFeture = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exeptionFeture.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException=>404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContectDto>.Fail(statusCode,exeptionFeture.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
       
    }
}
