using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class RegistrationController(
    IRegistrationService registrationService,
    IMapper mapper,
    IValidator<RegistrationDto> validator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Registration([FromBody] RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var tenant = mapper.Map<Tenant>(dto);
        var result = await registrationService.RegisterUserAsync(tenant);
        return result.Email == dto.Email ? Ok() : Conflict();
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> Finalize([FromBody] RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var tenant = mapper.Map<Tenant>(dto);
        await registrationService.FinalizeUserAsync(tenant);
        return Ok();
    }
}