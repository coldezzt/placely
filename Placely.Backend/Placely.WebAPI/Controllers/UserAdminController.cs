using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/admin/user/{userId:long}")]
public class UserAdminController(
    IUserService service, 
    IMapper mapper,
    IValidator<UserDto> validator) : ControllerBase
{ 
    [SwaggerOperation("Получает публичные настройки любого пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные о настройках.", typeof(UserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpGet("settings")]
    public async Task<IActionResult> GetSettings( // GET api/admin/user/{userId}/settings
        [FromRoute] [SwaggerParameter("Идентификатор пользователя.", Required = true)] long userId) 
    {
        var result = await service.GetByIdAsNoTrackingAsync(userId);
        var response = mapper.Map<UserDto>(result);
        return Ok(response);
    }
    
    [SwaggerOperation("Принудительно обновляет публичные настройки пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об обновлённых настройках.", typeof(SensitiveUserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("settings")]
    public async Task<IActionResult> UpdateSettings( // PATCH api/admin/user/{userId}/settings 
        [FromRoute] [SwaggerParameter("Идентификатор пользователя.", Required = true)] long userId,
        [FromBody] [SwaggerRequestBody("Данные для обновления.", Required = true)] UserDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var user = mapper.Map<User>(dto);
        user.Id = userId;
        var result = await service.PatchSettingsAsync(user);
        var response = mapper.Map<UserDto>(result);
        return Ok(response);
    }
    
    [SwaggerOperation("Принудительно удаляет любого пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об удалённом аккаунте.", typeof(UserDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpDelete]
    public async Task<IActionResult> Delete( // DELETE api/admin/user/{userId}
        [FromRoute] [SwaggerParameter("Идентификатор пользователя.", Required = true)] long userId)
    {
        var result = await service.DeleteAsync(userId);
        var response = mapper.Map<UserDto>(result);
        return Ok(response);
    }
}