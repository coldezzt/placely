using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Placely.Data.Exceptions;
using Placely.Main.Exceptions;
using Serilog;

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
                AutoMapperMappingException      => 400,
                RefreshTokenBadRequestException => 400,
                EntityNotFoundException         => 404,
                AddressException                => 422,
                ContractServiceException        => 422,
                DbUpdateException               => 503,
                _ => 500
            };

            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            
            var response = new
            {
                Message = e.Message,
                Exception = SerializeException(e)
            };

            logger.Log(LogLevel.Information, "Responded with: {@response}", response);
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