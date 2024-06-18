using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

[ApiController]
[Authorize(Roles = UserRoleType.Admin)]
[Route("api/admin/review/{reviewId:long}")]
public class ReviewAdminController(
    IReviewService service,
    IMapper mapper, 
    IValidator<ReviewDto> validator) : ControllerBase
{
    [SwaggerOperation("Принудительно обновляет отзыв пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Обновлённая информация по отзыву.", typeof(ReviewDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch]
    public async Task<IActionResult> Patch( // PATCH api/admin/review/{reviewId}
        [FromRoute] [SwaggerParameter("Идентификатор отзыва.", Required = true)] long reviewId,
        [FromBody] [SwaggerRequestBody("Данные для обновления отзыва.", Required = true)] ReviewDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        dto.Id = reviewId;
        var review = mapper.Map<Review>(dto);
        var updatedProperty = await service.UpdateAsync(review);
        var result = mapper.Map<ReviewDto>(updatedProperty);
        return Ok(result);
    }

    [SwaggerOperation("Принудительно удаляет отзыв пользователя")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные удалённого отзыва.", typeof(ReviewDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpDelete]
    public async Task<IActionResult> Delete( // DELETE api/admin/review/{reviewId}
        [FromRoute] [SwaggerParameter("Идентификатор отзыва.", Required = true)] long reviewId)
    {
        var result = await service.DeleteAsync(reviewId);
        var response = mapper.Map<ReviewDto>(result);
        return Ok(response);
    }
}