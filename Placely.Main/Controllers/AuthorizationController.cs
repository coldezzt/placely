using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Main.Controllers;

[Route("api/tenant")]
public class AuthorizationController(
    IAuthorizationService authService,
    IMapper mapper,
    IValidator<LoginDto> validator) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Authorize([FromBody] LoginDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var tenant = mapper.Map<Tenant>(dto);
        var token = await authService.AuthorizeAsync(tenant);
        return Ok(token);
    }
}