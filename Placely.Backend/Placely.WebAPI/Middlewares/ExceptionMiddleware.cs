﻿using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Placely.Application.Common.Exceptions;
using Placely.Application.Common.Options;

namespace Placely.WebAPI.Middlewares;

public class ExceptionMiddleware(
    ILogger<ExceptionMiddleware> logger,
    IOptions<CommonOptions> options) 
    : IMiddleware
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
            
            logger.Log(LogLevel.Warning, "Found exception. Type: {type}, Full: {@exception}", e.GetType().Name, e);
            
            var statusCode = e switch
            {
                AutoMapperMappingException      => StatusCodes.Status400BadRequest,
                RefreshTokenBadRequestException => StatusCodes.Status400BadRequest,
                EntityNotFoundException         => StatusCodes.Status404NotFound,
                ConflictException               => StatusCodes.Status409Conflict,
                ReservationServiceException     => StatusCodes.Status409Conflict,
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

            if (statusCode is StatusCodes.Status500InternalServerError)
                logger.Log(LogLevel.Error, "Unhandled error. {type}. Full: {@exception}", e.GetType().Name, e);
            
            logger.Log(LogLevel.Debug, "Responded with: {@response}", response);
            
            var body = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(body);
        }
    }
    
    private string? SerializeException(Exception e)
    {
        // мы не включаем информацию об exception в продакшн из-за возможной утечки чувствительных данных
        return options.Value.IsProduction ? null : e.ToString();
    }
}