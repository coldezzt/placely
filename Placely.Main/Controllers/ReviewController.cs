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
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ReviewController(
    IReviewService service,
    IMapper mapper,
    IValidator<ReviewDto> validator) : ControllerBase
{
    [SwaggerOperation(
        summary: "Получает отзыв пользователя по идентификатору",
        description: "Доступен всем.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные по отзыву.", 
        type: typeof(ReviewDto),
        contentTypes: "application/json")]
    [AllowAnonymous, HttpGet("{reviewId:long}")]
    public async Task<IActionResult> GetById(
        [SwaggerParameter(
            description: "Идентификатор отзыва.",
            Required = true)]
        long reviewId)
    {
        var result = await service.GetById(reviewId);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }
    
    [SwaggerOperation(
        summary: "Добавляет отзыв пользователя",
        description: "Идентификатор автора берётся из авторизационных данных пользователя.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные созданного отзыва.",
        type: typeof(ReviewDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(List<ValidationError>),
        contentTypes: "application/json")]
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] 
        [SwaggerRequestBody(
            description: "Данные для добавления отзыва.",
            Required = true)]
        ReviewDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));

        dto.AuthorId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!,
            NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var review = mapper.Map<Review>(dto);
        var result = await service.AddAsync(review);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }

    [SwaggerOperation(
        summary: "Удаляет отзыв пользователя",
        description: "Нельзя удалить чужой отзыв.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные удалённого отзыва.",
        type: typeof(ReviewDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка удалить чужой отзыв.")]
    [HttpDelete("{reviewId:long}")]
    public async Task<IActionResult> Delete(
        [SwaggerParameter(
            description: "Идентификатор отзыва.", 
            Required = true)] 
        long reviewId)
    {
        var id = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!,
            NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbReview = await service.GetById(reviewId);
        if (dbReview.AuthorId != id)
            return Forbid();

        var result = await service.DeleteAsync(reviewId);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }
}