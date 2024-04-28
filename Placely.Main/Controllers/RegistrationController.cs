using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class RegistrationController(
    IRegistrationService registrationService,
    IMapper mapper,
    IValidator<RegistrationDto> validator) : ControllerBase
{
    [SwaggerOperation(
        summary: "Регистрирует пользователя",
        description: "Если пользователь с такой же почтой уже существует регистрация не продолжается.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Пользователь зарегистрирован.")]
    [SwaggerResponse(
        statusCode: 409,
        description: "Пользователь с такой почтой уже зарегистрирован.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(List<ValidationFailure>),
        contentTypes: "application/json")]
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody]
        [SwaggerRequestBody(
            description: "Данные для регистрации.",
            Required = true)]
        RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors);
        
        var tenant = mapper.Map<Tenant>(dto);
        var result = await registrationService.RegisterUserAsync(tenant);
        return result.Email == dto.Email ? Ok() : Conflict();
    }

    [SwaggerOperation(
        summary: "Дорегистрация пользователя после OAuth",
        description: """
                     Заканчивает регистрацию пользователя после OAuth. Считывает все данные кроме почты.
                     
                     Пользователь должен быть авторизован. Эта конечная точка должна быть вызвана в той же 
                     сессии, что и регистрация через OAuth. 
                     
                     Такого рода регистрация не может быть закончена не авторизованным пользователем.
                     
                     Метод **можно** вызвать при следующей авторизации через OAuth.
                     """)]
    [SwaggerResponse(
        statusCode: 200,
        description: "Регистрация закончена успешно.")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(List<ValidationFailure>),
        contentTypes: "application/json")]
    [Authorize, HttpPost("[action]")]
    public async Task<IActionResult> Final(
        [FromBody]
        [SwaggerRequestBody(
            description: "Данные для регистрации. Игнорирует почту.",
            Required = true)]
        RegistrationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors);

        var tenant = mapper.Map<Tenant>(dto);
        await registrationService.FinalizeUserAsync(tenant);
        return Ok();
    }
}