using System.Globalization;
using System.Security.Claims;
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

[Authorize]
[Route("api/[controller]")]
public class ReservationController(
    IReservationService service, IMapper mapper, IValidator<ReservationDto> validator) : ControllerBase
{
    [SwaggerOperation("Получает бронирование по идентификатору",
        "Нельзя получить бронирование, участником которого ты не являешься (не арендатор или арендодатель)")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по бронированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка получить бронирование, участником которого пользователь не является.")]
    [HttpGet("my/{reservationId:long}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter("Идентификатор бронирования.", Required = true)]
        long reservationId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbReservation = await service.GetByIdAsNoTrackingAsync(reservationId);
        if (dbReservation.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Добавляет новое бронирование",
        "Нельзя добавить бронирование, участником которого ты не являешься (не арендатор).")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по созданному бронированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка создать бронирование, участником которого пользователь не является.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPost("my")]
    public async Task<IActionResult> Create(
        [FromBody] [SwaggerRequestBody("Данные для бронирования.", Required = true)]
        ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        dto.TenantId = currentUserId;
        var reservation = mapper.Map<Reservation>(dto);
        var dbReservation = await service.CreateAsync(reservation);
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Обновляет уже существующее бронирование",
        "Нельзя обновить бронирование, участником которого ты не являешься (не арендатор).")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по созданному бронированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка обновить бронирование, создателем которого пользователь не является.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("my/{reservationId:long}")]
    public async Task<IActionResult> Update(
        [FromRoute] [SwaggerParameter("Идентификатор резервирования для обновления", Required = true)] long reservationId,
        [FromBody] [SwaggerRequestBody("Обновлённые данные для бронирования.", Required = true)] ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);

        dto.Id = reservationId;
        dto.TenantId = currentUserId;
        var reservation = mapper.Map<Reservation>(dto);
        var dbReservation = await service.UpdateAsync(reservation);
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Удаляет бронирование по его идентификатору", 
        """
        Нельзя удалить чужое бронирование.

        Нельзя удалить бронирование с состоянием "В обработке" (арендодатель его просматривает).
        """)]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об удалённом бронировании.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка удалить бронирование, участником которого пользователь не является.")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "Попытка удалить бронирование, находящееся в обработке.")]
    [HttpDelete("my/{reservationId:long}")]
    public async Task<IActionResult> Delete([SwaggerParameter("Идентификатор бронирования.")] long reservationId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbReservation = await service.GetByIdAsNoTrackingAsync(reservationId);
        if (dbReservation.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        if (dbReservation.Status == ReservationStatus.InProgress) 
            return Conflict();
        
        var deletedReservation = await service.DeleteAsync(reservationId);
        var response = mapper.Map<ReservationDto>(deletedReservation);
        return Ok(response);
    }
}