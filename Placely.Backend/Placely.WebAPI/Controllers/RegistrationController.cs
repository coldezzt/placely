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
public class RegistrationController(
        IRegistrationService registrationService, 
        IMapper mapper,
        IValidator<RegistrationDto> validator
    ) : ControllerBase
{
    [SwaggerOperation("Регистрирует пользователя",
        "Если пользователь с такой же почтой уже существует регистрация не продолжается.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Пользователь зарегистрирован.")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "Пользователь с такой почтой уже зарегистрирован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [AllowAnonymous, HttpPost]
    public async Task<IActionResult> Register( // POST api/registration
        [FromBody] [SwaggerRequestBody("Данные для регистрации.", Required = true)] RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var user = mapper.Map<User>(dto);
        var result = await registrationService.RegisterUserAsync(user);
        return result.Email == dto.Email 
            ? Ok() 
            : Conflict();
    }

    [SwaggerOperation("Дорегистрация пользователя после OAuth", 
        """
        Заканчивает регистрацию пользователя после OAuth. Считывает все данные кроме почты.

        Пользователь должен быть авторизован. Эта конечная точка должна быть вызвана в той же
        сессии, что и регистрация через OAuth.

        Такого рода регистрация не может быть закончена не авторизованным пользователем.

        Метод **можно** вызвать при следующей авторизации через OAuth.
        """)]
    [SwaggerResponse(StatusCodes.Status200OK, "Регистрация закончена успешно.")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [Authorize, HttpPost("[action]")]
    public async Task<IActionResult> Final( // POST api/registration/final
        [FromBody] [SwaggerRequestBody("Данные для регистрации. Игнорирует почту.", Required = true)]
        RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var user = mapper.Map<User>(dto);
        await registrationService.FinalizeUserAsync(user);
        return Ok();
    }
}