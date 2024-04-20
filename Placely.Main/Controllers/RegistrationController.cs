using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Main.Controllers;

[Route("api/tenant")]
public class RegistrationController(
    IRegistrationService registrationService,
    IMapper mapper,
    IValidator<RegistrationDto> validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var tenant = mapper.Map<Tenant>(dto);
        var result = await registrationService.RegisterUserAsync(tenant);
        return result.Email == dto.Email ? Conflict() : Ok();
    }
}