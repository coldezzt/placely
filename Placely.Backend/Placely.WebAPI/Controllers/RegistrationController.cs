using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[Route("api/[controller]")]
public class RegistrationController(IRegistrationService registrationService, IMapper mapper,
    IValidator<RegistrationDto> validator) : ControllerBase
{
    [SwaggerOperation("Регистрирует пользователя",
        "Если пользователь с такой же почтой уже существует регистрация не продолжается.")]
    [SwaggerResponse(200, "Пользователь зарегистрирован.")]
    [SwaggerResponse(409, "Пользователь с такой почтой уже зарегистрирован.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] [SwaggerRequestBody("Данные для регистрации.", Required = true)] RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        var tenant = mapper.Map<User>(dto);
        var result = await registrationService.RegisterUserAsync(tenant);
        return result.Email == dto.Email ? Ok() : Conflict();
    }

    [SwaggerOperation("Дорегистрация пользователя после OAuth", 
        """
        Заканчивает регистрацию пользователя после OAuth. Считывает все данные кроме почты.

        Пользователь должен быть авторизован. Эта конечная точка должна быть вызвана в той же
        сессии, что и регистрация через OAuth.

        Такого рода регистрация не может быть закончена не авторизованным пользователем.

        Метод **можно** вызвать при следующей авторизации через OAuth.
        """)]
    [SwaggerResponse(200, "Регистрация закончена успешно.")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [Authorize, HttpPost("[action]")]
    public async Task<IActionResult> Final(
        [FromBody] [SwaggerRequestBody("Данные для регистрации. Игнорирует почту.", Required = true)]
        RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        var tenant = mapper.Map<User>(dto);
        await registrationService.FinalizeUserAsync(tenant);
        return Ok();
    }
}