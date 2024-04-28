using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class TenantController(
    ITenantService service,
    IMapper mapper,
    IValidator<TenantDto> validator) : ControllerBase
{
    [SwaggerOperation(
        summary: "Получает публичные данные пользователя",
        description: "Доступен всем.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные о пользователе.",
        type: typeof(TenantDto),
        contentTypes: "application/json")]
    [AllowAnonymous, HttpGet("{tenantId}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter(
            description: "Идентификатор пользователя.",
            Required = true)] 
        long tenantId)
    {
        var resultTenant = await service.GetByIdAsync(tenantId);
        var response = mapper.Map<TenantDto>(resultTenant);
        return Ok(response);
    }

    [SwaggerOperation(
        summary: "Получает все имущества, добавленные пользователем в избранное")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Список имуществ.",
        type: typeof(List<PropertyDto>),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [HttpGet("my/favourite")]
    public async Task<IActionResult> GetFavouriteProperties()
    {
        var tenantId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!,
            NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetFavouritePropertiesAsync(tenantId);
        var response = result.Select(mapper.Map<PropertyDto>);
        return Ok(response);
    }
    
    [SwaggerOperation(
        summary: "Получает настройки пользователя")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные о настройках.",
        type: typeof(SensitiveTenantDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [HttpGet("my/settings")]
    public async Task<IActionResult> GetSettings()
    {
        var tenantId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!,
            NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetByIdAsync(tenantId);
        var response = mapper.Map<SensitiveTenantDto>(result);
        return Ok(response);
    }

    [SwaggerOperation(
        summary: "Обновляет настройки пользователя")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные об обновлённых настройках.",
        type: typeof(SensitiveTenantDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(List<ValidationFailure>),
        contentTypes: "application/json")]
    [HttpPatch("my/settings")]
    public async Task<IActionResult> UpdateSettings(
        [FromBody]
        [SwaggerRequestBody(
            description: "Данные для обновления.",
            Required = true)]
        TenantDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors);

        var tenantId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!,
            NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var tenant = mapper.Map<Tenant>(dto);
        tenant.Id = tenantId;
        var result = await service.ChangeSettingsAsync(tenant);
        var response = mapper.Map<TenantDto>(result);
        return Ok(response);
    }

    [SwaggerOperation(
        summary: "Удаляет аккаунт пользователя")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные об удалённом аккаунте.",
        type: typeof(TenantDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [HttpDelete("my")]
    public async Task<IActionResult> Delete()
    {
        var tenantId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!,
            NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var result = await service.DeleteAsync(tenantId);
        var response = mapper.Map<TenantDto>(result);
        return Ok(response);
    }
}