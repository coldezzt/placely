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

[ApiController]
[Authorize(Roles = UserRoleType.Admin)]
[Route("api/admin/property")]
public class PropertyAdminController(
        IPropertyService service, 
        IMapper mapper, 
        IValidator<PropertyDto> validator
    ) : ControllerBase
{
    [SwaggerOperation("Принудительно обновляет имущество пользователя.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновлённая информация по имуществу.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", 
        typeof(ValidationResult), "application/json")]
    [HttpPatch("{propertyId:long}")] 
    public async Task<IActionResult> Patch( // PATCH api/admin/property/{propertyId}
        [FromRoute] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId,
        [FromBody] [SwaggerRequestBody("Данные для обновления имущества.", Required = true)] PropertyDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var property = mapper.Map<Property>(dto);
        property.Id = propertyId;
        
        var updatedProperty = await service.UpdateAsync(property);
        var result = mapper.Map<PropertyDto>(updatedProperty);
        return Ok(result);
    }
    
    [SwaggerOperation("Принудительно удаляет имущество пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные удалённого имущества.", typeof(PropertyDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpDelete("{propertyId:long}")]
    public async Task<IActionResult> Delete( // DELETE api/admin/property/{propertyId}
        [FromRoute] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId)
    {
        var property = await service.DeleteAsync(propertyId);
        var response = mapper.Map<PropertyDto>(property);
        return Ok(response);
    }
}