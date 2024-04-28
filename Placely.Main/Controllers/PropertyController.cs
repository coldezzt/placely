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
    IValidator<PropertyDto> validator,
    IPropertyService service, 
    IMapper mapper) : ControllerBase
{
    [SwaggerOperation(
        summary: "Получает информацию по имуществу по его идентификатору",
        description: "Доступен всем.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация об имуществе.",
        type: typeof(PropertyDto),
        contentTypes: "application/json")]
    [AllowAnonymous, HttpGet("{propertyId:long}")]
    public async Task<IActionResult> GetById(
        [SwaggerParameter(description: "Идентификатор имущества.", Required = true)] long propertyId)
    {
        var property = await service.GetByIdAsync(propertyId);
        var result = mapper.Map<PropertyDto>(property);
        return Ok(result);
    }
    
    [SwaggerOperation(
        summary: "Публикует имущество",
        description: "Если у пользователя нет контактного адреса, не добавляет имущество.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация о созданном имуществе.",
        type: typeof(PropertyDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(ValidationResult),
        contentTypes: "application/json")]
    [HttpPost]
    public async Task<IActionResult> Publish(
        [FromBody] 
        [SwaggerRequestBody(
            description: "Полная информация об имуществе, необходимая для его публикации.", 
            Required = true)] 
        PropertyDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors);
        
        var property = mapper.Map<Property>(dto);
        var createdProperty = await service.AddAsync(property);
        var result = mapper.Map<PropertyDto>(createdProperty);
        return Ok(result);
    }
    
    [SwaggerOperation(
        summary: "Обновляет имущество пользователя",
        description: "Нельзя обновить чужое имущество.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Обновлённая информация по имуществу.",
        type: typeof(PropertyDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка обновить чужое имущество.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(ValidationResult),
        contentTypes: "application/json")]
    [HttpPatch("my/{propertyId:long}")]
    public async Task<IActionResult> Update(
        [SwaggerParameter(description: "Идентификатор имущества.", Required = true)] 
        long propertyId, 
        [FromBody] 
        [SwaggerRequestBody(
            description: "Данные для обновления имущества.",
            Required = true)]
        PropertyDto dto)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);

        var dbProperty = await service.GetByIdAsync(propertyId);
        if (dbProperty.OwnerId != currentUserId)
            return Forbid();
        
        dto.Id = propertyId;
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors);
        
        var property = mapper.Map<Property>(dto);
        var updatedProperty = await service.UpdateAsync(property);
        var result = mapper.Map<PropertyDto>(updatedProperty);
        return Ok(result);
    }

    [SwaggerOperation(
        summary: "Удаляет имущество пользователя",
        description: "Нельзя удалить чужое имущество.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные удалённого имущества.", 
        type: typeof(PropertyDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка удалить чужое имущество.")]
    [HttpDelete("my/{propertyId:long}")]
    public async Task<IActionResult> Delete(
        [SwaggerParameter(description: "Идентификатор имущества.", Required = true)]
        long propertyId)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);

        var dbProperty = await service.GetByIdAsync(propertyId);
        if (dbProperty.OwnerId != currentUserId)
            return Forbid();
        
        var property = await service.DeleteAsync(propertyId);
        var response = mapper.Map<PropertyDto>(property);
        return Ok(response);
    }
    
    [SwaggerOperation]
    [AllowAnonymous, HttpGet("{propertyId:long}/reviews/{page:int}")]
    public async Task<IActionResult> GetListByPropertyId(long propertyId, int page)
    {
        var result = await service.GetListByPropertyIdAsync(propertyId, page);
        var responseDtoList = result.Select(mapper.Map<ReviewDto>);
        return Ok(responseDtoList);
    }
}