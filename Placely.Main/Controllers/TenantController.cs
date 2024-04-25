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

[Authorize]
[Route("api/[controller]")]
public class TenantController(
    ITenantService service,
    IMapper mapper,
    IValidator<TenantDto> validator) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("{tenantId}")]
    public async Task<IActionResult> Get(long tenantId)
    {
        var resultTenant = await service.GetByIdAsync(tenantId);
        var response = mapper.Map<TenantDto>(resultTenant);
        return Ok(response);
    }

    [HttpGet("my/favourite")]
    public async Task<IActionResult> GetFavouriteProperties()
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();

        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var tenantId))
            return BadRequest();

        var result = await service.GetFavouritePropertiesAsync(tenantId);
        var response = result.Select(mapper.Map<PropertyDto>);
        return Ok(response);
    }
    
    [HttpGet("my/settings")]
    public async Task<IActionResult> GetSettings()
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();
        
        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var tenantId))
            return BadRequest();

        var result = await service.GetByIdAsync(tenantId);
        var response = mapper.Map<SensitiveTenantDto>(result);
        return Ok(response);
    }

    [HttpPatch("my/settings")]
    public async Task<IActionResult> UpdateSettings([FromBody] TenantDto dto)
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();
        
        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var tenantId))
            return BadRequest();
        
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var tenant = mapper.Map<Tenant>(dto);
        tenant.Id = tenantId;
        var result = await service.ChangeSettingsAsync(tenant);
        var response = mapper.Map<TenantDto>(result);
        return Ok(response);
    }

    [HttpDelete("my")]
    public async Task<IActionResult> Delete()
    {
        var claimId = User.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null)
            return Unauthorized();
        
        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var tenantId))
            return BadRequest();
        
        var result = await service.DeleteAsync(tenantId);
        var response = mapper.Map<TenantDto>(result);
        return Ok(response);
    }
}