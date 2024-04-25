using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class PropertyController(
    IValidator<PropertyDto> validator,
    IPropertyService propertyService, 
    IMapper mapper) : ControllerBase
{
    [HttpGet("{propertyId}")]
    public async Task<IActionResult> GetById(long propertyId)
    {
        var property = await propertyService.GetByIdAsync(propertyId);
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
        var createdProperty = await propertyService.AddAsync(property);
        var result = mapper.Map<PropertyDto>(createdProperty);
        return Ok(result);
    }

    [Authorize]
    [HttpPatch("my/{propertyId}")]
    public async Task<IActionResult> Update(long propertyId, [FromBody] PropertyDto dto)
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
            return BadRequest();

        var dbProperty = await propertyService.GetByIdAsync(propertyId);
        if (dbProperty.OwnerId != id)
            return Forbid();
        
        dto.Id = propertyId;
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var property = mapper.Map<Property>(dto);
        var updatedProperty = await propertyService.UpdateAsync(property);
        var result = mapper.Map<PropertyDto>(updatedProperty);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete("my/{propertyId}")]
    public async Task<IActionResult> Delete(long propertyId)
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
            return BadRequest();

        var dbProperty = await propertyService.GetByIdAsync(propertyId);
        if (dbProperty.OwnerId != id)
            return Forbid();
        
        await propertyService.DeleteAsync(propertyId);
        return Ok();
    }
}