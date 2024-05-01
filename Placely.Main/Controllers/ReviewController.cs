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
public class ReviewController(IReviewService service, IMapper mapper, IValidator<ReviewDto> validator) : ControllerBase
{
    [SwaggerOperation("Получает отзыв пользователя по идентификатору", "Доступен всем.")]
    [SwaggerResponse(200, "Данные по отзыву.", typeof(ReviewDto), "application/json")]
    [AllowAnonymous, HttpGet("{reviewId:long}")]
    public async Task<IActionResult> GetById([SwaggerParameter("Идентификатор отзыва.", Required = true)] long reviewId)
    {
        var result = await service.GetById(reviewId);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Добавляет отзыв пользователя",
        "Идентификатор автора берётся из авторизационных данных пользователя.")]
    [SwaggerResponse(200, "Данные созданного отзыва.", typeof(ReviewDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationError>),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] [SwaggerRequestBody("Данные для добавления отзыва.", Required = true)] ReviewDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));
        dto.AuthorId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var review = mapper.Map<Review>(dto);
        var result = await service.AddAsync(review);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Удаляет отзыв пользователя", "Нельзя удалить чужой отзыв.")]
    [SwaggerResponse(200, "Данные удалённого отзыва.", typeof(ReviewDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка удалить чужой отзыв.")]
    [HttpDelete("{reviewId:long}")]
    public async Task<IActionResult> Delete([SwaggerParameter("Идентификатор отзыва.", Required = true)] long reviewId)
    {
        var id = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbReview = await service.GetById(reviewId);
        if (dbReview.AuthorId != id) return Forbid();
        var result = await service.DeleteAsync(reviewId);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }
}