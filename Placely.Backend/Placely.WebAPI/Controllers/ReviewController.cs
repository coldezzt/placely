using System.Globalization;
using System.Security.Claims;
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

[Authorize]
[Route("api/[controller]")]
public class ReviewController(
        IReviewService service, 
        IMapper mapper, 
        IValidator<ReviewDto> validator
    ) : ControllerBase
{
    [SwaggerOperation("Получает отзыв пользователя по идентификатору", "Доступен всем.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные по отзыву.", typeof(ReviewDto), "application/json")]
    [AllowAnonymous, HttpGet("{reviewId:long}")]
    public async Task<IActionResult> GetById( // GET api/review/{reviewId}
        [FromRoute] [SwaggerParameter("Идентификатор отзыва.", Required = true)] long reviewId)
    {
        var result = await service.GetByIdAsNoTrackingAsync(reviewId);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }

    [SwaggerOperation("Добавляет отзыв пользователя",
        "Идентификатор автора берётся из авторизационных данных пользователя.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные созданного отзыва.", typeof(ReviewDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Add( // POST api/review
        [FromBody] [SwaggerRequestBody("Данные для добавления отзыва.", Required = true)] ReviewDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        dto.AuthorId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var review = mapper.Map<Review>(dto);
        var result = await service.AddAsync(review);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }
    
    [SwaggerOperation("Обновляет отзыв пользователя", "Нельзя обновить чужой отзыв.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновлённая информация по отзыву.", typeof(ReviewDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка обновить чужой отзыв.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("my/{reviewId:long}")]
    public async Task<IActionResult> Patch( // PATCH api/review/my/{reviewId}
        [FromRoute] [SwaggerParameter("Идентификатор отзыва.", Required = true)] long reviewId,
        [FromBody] [SwaggerRequestBody("Данные для обновления отзыва.", Required = true)] ReviewDto dto)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbReview = await service.GetByIdAsNoTrackingAsync(reviewId);
        if (dbReview.AuthorId != currentUserId) 
            return Forbid();
        
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        dto.Id = reviewId;
        var review = mapper.Map<Review>(dto);
        var updatedProperty = await service.UpdateAsync(review);
        var result = mapper.Map<ReviewDto>(updatedProperty);
        return Ok(result);
    }

    [SwaggerOperation("Удаляет отзыв пользователя", "Нельзя удалить чужой отзыв.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные удалённого отзыва.", typeof(ReviewDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка удалить чужой отзыв.")]
    [HttpDelete("{reviewId:long}")]
    public async Task<IActionResult> Delete( // DELETE api/review/{reviewId}
        [FromRoute] [SwaggerParameter("Идентификатор отзыва.", Required = true)] long reviewId)
    {
        var id = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbReview = await service.GetByIdAsNoTrackingAsync(reviewId);
        if (dbReview.AuthorId != id) 
            return Forbid();
        
        var result = await service.DeleteAsync(reviewId);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }
    
    [SwaggerOperation("Достаёт отзывы по имуществу", "Доступно всем.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Список отзывов.", typeof(List<ReviewDto>), "application/json")]
    [AllowAnonymous, HttpGet("list")]
    public async Task<IActionResult> GetListByPropertyId( // GET api/review/list?propertyId={propertyId}&page={page}
        [FromQuery] [SwaggerParameter("Идентификатор имущества.", Required = true)] long propertyId,
        [FromQuery] [SwaggerParameter("Страница, для пагинации.")] int page = 0)
    {
        var result = await service.GetReviewsListByIdAsync(propertyId, page);
        var responseDtoList = result.Select(mapper.Map<ReviewDto>);
        return Ok(responseDtoList);
    }
}