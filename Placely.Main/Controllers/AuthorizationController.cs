using System.Globalization;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;
using IAuthorizationService = Placely.Data.Abstractions.Services.IAuthorizationService;

namespace Placely.Main.Controllers;

[Route("api/tenant")]
public class AuthorizationController(
    IAuthorizationService service,
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
        
        var tokenModel = await service.AuthorizeAsync(tenant);
        
        return Ok(tokenModel);
    }
    
    /*
     [HttpGet("jwt")]
    public async Task<IActionResult> GenerateJwtToken()
    {
        var cookie = Request.Cookies["refreshToken"];
        var claimId = User.Claims.FirstOrDefault(c => c.Type == CustomClaimTypes.UserId)?.Value;

        // TODO: при первой отправке пользователь ещё не авторизован -> нет куки -> нет токена :(
        // TODO: просто записывать refresh token в куки только для http и во время авторизации возвращать ещё и jwt токен
        if (cookie is null || claimId is null 
            || !long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var tenantId))
            return Unauthorized();

        var refreshToken = new RefreshToken { Token = cookie };
        if (!await service.IsRefreshTokenValid(tenantId, refreshToken))
            return Unauthorized();

        var jwtToken = await service.GenerateJwtTokenAsync(tenant, refreshToken);
        return Ok(jwtToken);
    }
    */
}