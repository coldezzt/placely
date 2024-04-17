using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class PropertyController(
    IValidator<PropertyDto> validator,
    IPropertyService propertyService, 
    IMapper mapper) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var property = await propertyService.GetByIdAsync(id);
        var result = mapper.Map<PropertyDto>(property);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Publish([FromBody] PropertyDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var property = mapper.Map<Property>(dto);
        var dbProperty = await propertyService.AddAsync(property);
        var result = mapper.Map<PropertyDto>(dbProperty);
        return Ok(result);
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] PropertyDto dto)
    {
        dto.Id = id;
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var property = mapper.Map<Property>(dto);
        var dbProperty = await propertyService.UpdateAsync(property);
        var result = mapper.Map<PropertyDto>(dbProperty);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        await propertyService.DeleteAsync(id);
        return Ok();
    }
}