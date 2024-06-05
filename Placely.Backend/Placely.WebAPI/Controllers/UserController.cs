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
public class UserController(
        IUserService service, 
        IMapper mapper, 
        IValidator<UserDto> validator,
        IValidator<SensitiveUserDto> sensitiveDtoValidator
    ) : ControllerBase
{
    [SwaggerOperation("Получает публичные данные пользователя", "Доступен всем.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные о пользователе.", typeof(UserDto), "application/json")]
    [AllowAnonymous, HttpGet("{userId}")]
    public async Task<IActionResult> Get( // GET api/user/{userId}
        [FromRoute] [SwaggerParameter("Идентификатор пользователя.", Required = true)] long userId)
    {
        var dbUser = await service.GetByIdAsNoTrackingAsync(userId);
        var response = mapper.Map<UserDto>(dbUser);
        return Ok(response);
    }

    [SwaggerOperation("Получает все имущества, добавленные пользователем в избранное")]
    [SwaggerResponse(StatusCodes.Status200OK, "Список имуществ.", typeof(List<PropertyDto>), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpGet("my/favourite")]
    public async Task<IActionResult> GetFavouriteProperties() // GET api/user/my/favourite
    {
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetFavouritePropertiesAsync(userId);
        var response = result.Select(mapper.Map<PropertyDto>);
        return Ok(response);
    }

    [SwaggerOperation("Получает настройки пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные о настройках.", typeof(UserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpGet("my/settings")]
    public async Task<IActionResult> GetSettings() // GET api/user/my/settings
    {
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetByIdAsNoTrackingAsync(userId);
        var response = mapper.Map<UserDto>(result);
        return Ok(response);
    }
    
    [SwaggerOperation("Получает конфиденциальные настройки пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные о конфиденциальных настройках.", typeof(SensitiveUserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpGet("my/sensitive/settings")]
    public async Task<IActionResult> GetSensitiveSettings() // GET api/user/my/sensitive/settings
    {
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var result = await service.GetByIdAsNoTrackingAsync(userId);
        var response = mapper.Map<SensitiveUserDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Добавляет имущество в избранное текущему пользователю")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные о добавленном в избранное имуществе.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpPost("my/favourite")]
    public async Task<IActionResult> AddPropertyToFavourite( // POST api/user/my/favourite?propertyId={propertyId}
        [FromQuery] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var property = await service.AddPropertyToFavouritesAsync(userId, propertyId);
        var response = mapper.Map<PropertyDto>(property);
        return Ok(response);
    }

    [SwaggerOperation("Обновляет настройки пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об обновлённых настройках.", typeof(SensitiveUserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("my/settings")]
    public async Task<IActionResult> UpdateSettings( // PATCH api/user/my/settings 
        [FromBody] [SwaggerRequestBody("Данные для обновления.", Required = true)] UserDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var user = mapper.Map<User>(dto);
        user.Id = userId;
        var result = await service.PatchSettingsAsync(user);
        var response = mapper.Map<UserDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Обновляет чувствительные настройки пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об обновлённых настройках.", typeof(SensitiveUserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("my/sensitive/settings")]
    public async Task<IActionResult> UpdateSensitiveSettings( // PATCH api/user/my/sensitive/settings
        [FromBody] [SwaggerRequestBody("Данные для обновления.", Required = true)] SensitiveUserDto dto)
    {
        var validationResult = await sensitiveDtoValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var dbUser = await service.GetByIdAsNoTrackingAsync(userId);
        var oldPassHash = PasswordHasher.Hash(dto.OldPassword);
        if (!PasswordHasher.IsValid(oldPassHash, dto.OldPassword)) 
            return Forbid();
        
        if (dbUser.PreviousPasswords?.Select(pp => pp.Password == dto.NewPassword).Any() ?? false)
            return BadRequest();
        
        var user = mapper.Map<User>(dto);
        user.Id = userId;
        var result = await service.PatchSensitiveSettingsAsync(user);
        var response = mapper.Map<SensitiveUserDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Удаляет аккаунт пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об удалённом аккаунте.", typeof(UserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpDelete("my")]
    public async Task<IActionResult> Delete() // DELETE api/user/my
    {
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var result = await service.DeleteAsync(userId);
        var response = mapper.Map<UserDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Удаляет имущество из избранного текущего пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об удалённом из избранного имуществе.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpDelete("my/favourite")]
    public async Task<IActionResult> DeletePropertyFromFavourite( // DELETE api/user/my/favourite?propertyId={propertyId}
        [FromQuery] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var userId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbProperty = await service.DeletePropertyFromFavouritesAsync(userId, propertyId);
        var response = mapper.Map<PropertyDto>(dbProperty);
        return Ok(response);
    }
}