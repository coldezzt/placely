using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Placely.Data.Exceptions;
using Placely.Main.Exceptions;

namespace Placely.Main.Middlewares;

public class ExceptionMiddleware(
    ILogger<ExceptionMiddleware> logger,
    IWebHostEnvironment webHostEnvironment) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            if (context.Response.HasStarted)
                throw;
            logger.Log(LogLevel.Trace, "Found exception. Type: {type}, Full: {@exception}", e.GetType().Name, e);
            
            var statusCode = e switch
            {
                AutoMapperMappingException      => StatusCodes.Status400BadRequest,
                RefreshTokenBadRequestException => StatusCodes.Status400BadRequest,
                EntityNotFoundException         => StatusCodes.Status404NotFound,
                ConflictException               => StatusCodes.Status409Conflict,
                AddressException                => StatusCodes.Status422UnprocessableEntity,
                ContractServiceException        => StatusCodes.Status422UnprocessableEntity,
                DbUpdateException               => StatusCodes.Status503ServiceUnavailable,
                _                               => StatusCodes.Status500InternalServerError,
            };

            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            
            var response = new
            {
                Message = e.Message,
                Exception = SerializeException(e)
            };

            logger.Log(LogLevel.Debug, "Responded with: {@response}", response);
            var body = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(body);
        }
    }
    
    private string? SerializeException(Exception e)
    {
        // мы не включаем информацию об exception в продакшн из-за возможной утечки чувствительных данных
        return webHostEnvironment.IsProduction() ? null : e.ToString();
    }
}