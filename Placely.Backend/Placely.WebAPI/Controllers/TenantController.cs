using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Application.Services.Utils;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
public class TenantController(ITenantService service, IMapper mapper, IValidator<TenantDto> validator,
    IValidator<SensitiveTenantDto> sensitiveDtoValidator) : ControllerBase
{
    [SwaggerOperation("Получает публичные данные пользователя", "Доступен всем.")]
    [SwaggerResponse(200, "Данные о пользователе.", typeof(TenantDto), "application/json")]
    [AllowAnonymous, HttpGet("{tenantId}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter("Идентификатор пользователя.", Required = true)] long tenantId)
    {
        var resultTenant = await service.GetByIdAsNoTrackingAsync(tenantId);
        var response = mapper.Map<TenantDto>(resultTenant);
        return Ok(response);
    }

    [SwaggerOperation("Получает все имущества, добавленные пользователем в избранное")]
    [SwaggerResponse(200, "Список имуществ.", typeof(List<PropertyDto>), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [HttpGet("my/favourite")]
    public async Task<IActionResult> GetFavouriteProperties()
    {
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetFavouritePropertiesAsync(tenantId);
        var response = result.Select(mapper.Map<PropertyDto>);
        return Ok(response);
    }

    [SwaggerOperation("Получает настройки пользователя")]
    [SwaggerResponse(200, "Данные о настройках.", typeof(TenantDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [HttpGet("my/settings")]
    public async Task<IActionResult> GetSettings()
    {
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetByIdAsNoTrackingAsync(tenantId);
        var response = mapper.Map<TenantDto>(result);
        return Ok(response);
    }
    
    [SwaggerOperation("Получает конфиденциальные настройки пользователя")]
    [SwaggerResponse(200, "Данные о конфиденциальных настройках.", typeof(SensitiveTenantDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [HttpGet("my/sensitive/settings")]
    public async Task<IActionResult> GetSensitiveSettings()
    {
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetByIdAsNoTrackingAsync(tenantId);
        var response = mapper.Map<SensitiveTenantDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Добавляет имущество в избранное текущему пользователю")]
    [SwaggerResponse(200, "Данные о добавленном в избранное имуществе.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [HttpPost("my/favourite")]
    public async Task<IActionResult> AddPropertyToFavourite(
        [FromQuery] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var property = await service.AddPropertyToFavouritesAsync(tenantId, propertyId);
        var response = mapper.Map<PropertyDto>(property);
        return Ok(response);
    }

    [SwaggerOperation("Обновляет настройки пользователя")]
    [SwaggerResponse(200, "Данные об обновлённых настройках.", typeof(SensitiveTenantDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("my/settings")]
    public async Task<IActionResult> UpdateSettings(
        [FromBody] [SwaggerRequestBody("Данные для обновления.", Required = true)] TenantDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var tenant = mapper.Map<User>(dto);
        tenant.Id = tenantId;
        var result = await service.PatchSettingsAsync(tenant);
        var response = mapper.Map<TenantDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Обновляет чувствительные настройки пользователя")]
    [SwaggerResponse(200, "Данные об обновлённых настройках.", typeof(SensitiveTenantDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("my/sensitive/settings")]
    public async Task<IActionResult> UpdateSensitiveSettings([FromBody] SensitiveTenantDto dto)
    {
        var validationResult = await sensitiveDtoValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var dbTenant = await service.GetByIdAsNoTrackingAsync(tenantId);
        var oldPassHash = PasswordHasher.Hash(dto.OldPassword);
        if (!PasswordHasher.IsValid(oldPassHash, dto.OldPassword)) 
            return Forbid();
        if (dbTenant.PreviousPasswords?.Select(pp => pp.Password == dto.NewPassword).Any() ?? false)
            return BadRequest();
        
        var tenant = mapper.Map<User>(dto);
        tenant.Id = tenantId;
        var result = await service.PatchSensitiveSettingsAsync(tenant);
        var response = mapper.Map<SensitiveTenantDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Удаляет аккаунт пользователя")]
    [SwaggerResponse(200, "Данные об удалённом аккаунте.", typeof(TenantDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [HttpDelete("my")]
    public async Task<IActionResult> Delete()
    {
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var result = await service.DeleteAsync(tenantId);
        var response = mapper.Map<TenantDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Удаляет имущество из избранного текущего пользователя")]
    [SwaggerResponse(200, "Данные об удалённом из избранного имуществе.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [HttpDelete("my/favourite")]
    public async Task<IActionResult> DeletePropertyFromFavourite(
        [FromQuery] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var tenantId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbProperty = await service.DeletePropertyFromFavouritesAsync(tenantId, propertyId);
        var response = mapper.Map<PropertyDto>(dbProperty);
        return Ok(response);
    }
}