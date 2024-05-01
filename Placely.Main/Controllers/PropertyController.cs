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
public class PropertyController(
    IPropertyService service, IMapper mapper, IValidator<PropertyDto> validator) : ControllerBase
{
    [SwaggerOperation("Получает информацию по имуществу по его идентификатору", "Доступен всем.")]
    [SwaggerResponse(200, "Информация об имуществе.", typeof(PropertyDto), "application/json")]
    [AllowAnonymous, HttpGet("{propertyId:long}")]
    public async Task<IActionResult> GetById(
        [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId = 1)
    {
        var property = await service.GetByIdAsync(propertyId);
        var result = mapper.Map<PropertyDto>(property);
        return Ok(result);
    }

    [SwaggerOperation("Предлагает продолжение адреса", 
        """
        Доступен всем.

        Получает на вход строку с адресом и пытается предположить какой адрес будет дальше.
        """)]
    [SwaggerResponse(200, "Список предполагаемых адресов.", typeof(List<string>), "application/json")]
    [AllowAnonymous, HttpGet("suggestion")]
    public async Task<IActionResult> GetAddressSuggestion(
        [FromQuery] [SwaggerParameter("Адрес для предположения", Required = true)] string address)
    {
        var result = await service.GetAddressSuggestionAsync(address);
        return Ok(result);
    }

    [SwaggerOperation("Получает список имуществ по фильтрам")]
    [SwaggerResponse(200, "Список предполагаемых адресов.", typeof(List<string>), "application/json")]
    [AllowAnonymous, HttpGet("catalog/page/{pageNumber:int}/take/{amount:int}")]
    public async Task<IActionResult> GetCatalog(
        [FromQuery] [SwaggerParameter("Фильтры.")] Dictionary<SearchParameter, string> searchParameters,
        [FromRoute] [SwaggerParameter("Количество элементов на странице.")] int amount,
        [FromRoute] [SwaggerParameter("Текущая страница каталога.")] int pageNumber)
    {
        var result = await service.GetChunkByFilterAsync(searchParameters, pageNumber, amount);
        var response = mapper.Map<List<PropertyDto>>(result);
        return Ok(response);
    }

    [SwaggerOperation("Публикует имущество", "Если у пользователя нет контактного адреса, не добавляет имущество.")]
    [SwaggerResponse(200, "Информация о созданном имуществе.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(ValidationResult),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody]
        [SwaggerRequestBody("Полная информация об имуществе, необходимая для его публикации.", Required = true)]
        PropertyDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid) return UnprocessableEntity(validationResult.Errors);
        var property = mapper.Map<Property>(dto);
        var createdProperty = await service.AddAsync(property);
        var result = mapper.Map<PropertyDto>(createdProperty);
        return Ok(result);
    }

    [SwaggerOperation("Обновляет имущество пользователя", "Нельзя обновить чужое имущество.")]
    [SwaggerResponse(200, "Обновлённая информация по имуществу.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка обновить чужое имущество.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(ValidationResult),
        "application/json")]
    [HttpPatch("my/{propertyId:long}")]
    public async Task<IActionResult> Patch(
        [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId,
        [FromBody] [SwaggerRequestBody("Данные для обновления имущества.", Required = true)] PropertyDto dto)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbProperty = await service.GetByIdAsync(propertyId);
        if (dbProperty.OwnerId != currentUserId) return Forbid();
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));
        dto.Id = propertyId;
        var property = mapper.Map<Property>(dto);
        var updatedProperty = await service.UpdateAsync(property);
        var result = mapper.Map<PropertyDto>(updatedProperty);
        return Ok(result);
    }

    [SwaggerOperation("Удаляет имущество пользователя", "Нельзя удалить чужое имущество.")]
    [SwaggerResponse(200, "Данные удалённого имущества.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка удалить чужое имущество.")]
    [HttpDelete("my/{propertyId:long}")]
    public async Task<IActionResult> Delete(
        [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbProperty = await service.GetByIdAsync(propertyId);
        if (dbProperty.OwnerId != currentUserId) return Forbid();
        var property = await service.DeleteAsync(propertyId);
        var response = mapper.Map<PropertyDto>(property);
        return Ok(response);
    }

    [SwaggerOperation]
    [AllowAnonymous, HttpGet("{propertyId:long}/reviews/{page:int}")]
    public async Task<IActionResult> GetListByPropertyId(long propertyId, int page)
    {
        var result = await service.GetReviewsListByIdAsync(propertyId, page);
        var responseDtoList = result.Select(mapper.Map<ReviewDto>);
        return Ok(responseDtoList);
    }
}