using System.ComponentModel;
using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
public class PropertyController(
        IPropertyService service, 
        IMapper mapper, 
        IValidator<PropertyDto> validator
    ) : ControllerBase
{
    [SwaggerOperation("Получает информацию по имуществу по его идентификатору", "Доступен всем.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация об имуществе.", typeof(PropertyDto), "application/json")]
    [AllowAnonymous, HttpGet("{propertyId:long}")]
    public async Task<IActionResult> GetById( // GET api/property/{propertyId}
        [FromRoute] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var property = await service.GetByIdAsNoTrackingAsync(propertyId);
        var result = mapper.Map<PropertyDto>(property);
        return Ok(result);
    }

    [SwaggerOperation("Предлагает продолжение адреса", 
        """
        Доступен всем.

        Получает на вход строку с адресом и предполагает какой адрес будет дальше.
        """)]
    [SwaggerResponse(StatusCodes.Status200OK, "Список предполагаемых адресов.", typeof(List<string>), "application/json")]
    [AllowAnonymous, HttpGet("suggestion")]
    public async Task<IActionResult> GetAddressSuggestion( // GET api/property/suggestion?address={address}
        [FromQuery] [SwaggerParameter("Адрес для предположения", Required = true)] string address)
    {
        var result = await service.GetAddressSuggestionAsync(address);
        return Ok(result);
    }

    [SwaggerOperation("Получает список имуществ по фильтрам", "Доступен всем.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Список предполагаемых адресов.", typeof(List<string>), "application/json")]
    [AllowAnonymous, HttpGet("catalog/page/{pageNumber:int}/take/{amount:int}")]
    public async Task<IActionResult> GetCatalog( // GET api/property/catalog/page/{pageNumber}/take/{amount}?param1={param1}&...
        [FromQuery] [SwaggerParameter("Фильтры.")] Dictionary<SearchParameterType, string> searchParameters,
        [FromRoute] [SwaggerParameter("Количество элементов на странице.")] int amount,
        [FromRoute] [SwaggerParameter("Текущая страница каталога.")] int pageNumber)
    {
        var result = await service.GetChunkByFilterAsync(searchParameters, pageNumber, amount);
        var response = mapper.Map<List<PropertyDto>>(result);
        return Ok(response);
    }

    [SwaggerOperation("Публикует имущество", "Если у пользователя нет контактного адреса, не добавляет имущество.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация о созданном имуществе.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(ValidationResult),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Create( // POST api/property
        [FromBody]
        [SwaggerRequestBody("Полная информация об имуществе, необходимая для его публикации.", Required = true)]
        PropertyDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid) 
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var property = mapper.Map<Property>(dto);
        property.OwnerId = currentUserId;
        property.PublicationDate = DateTime.UtcNow;
        
        var createdProperty = await service.AddAsync(property);
        var result = mapper.Map<PropertyDto>(createdProperty);
        return Ok(result);
    }

    [SwaggerOperation("Обновляет имущество пользователя", "Нельзя обновить чужое имущество.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновлённая информация по имуществу.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка обновить чужое имущество.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("my/{propertyId:long}")]
    public async Task<IActionResult> Patch( // PATCH api/property/my/{propertyId}
        [FromRoute] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId,
        [FromBody] [SwaggerRequestBody("Данные для обновления имущества.", Required = true)] PropertyDto dto)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbProperty = await service.GetByIdAsNoTrackingAsync(propertyId);
        if (dbProperty.OwnerId != currentUserId) 
            return Forbid();
        
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var property = mapper.Map<Property>(dto);
        property.Id = propertyId;
        
        var updatedProperty = await service.UpdateAsync(property);
        var result = mapper.Map<PropertyDto>(updatedProperty);
        return Ok(result);
    }

    [SwaggerOperation("Удаляет имущество пользователя", "Нельзя удалить чужое имущество.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные удалённого имущества.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка удалить чужое имущество.")]
    [HttpDelete("my/{propertyId:long}")]
    public async Task<IActionResult> Delete( // DELETE api/property/my/{propertyId}
        [FromRoute] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbProperty = await service.GetByIdAsNoTrackingAsync(propertyId);
        if (dbProperty.OwnerId != currentUserId) 
            return Forbid();
        
        var property = await service.DeleteAsync(propertyId);
        var response = mapper.Map<PropertyDto>(property);
        return Ok(response);
    }
}