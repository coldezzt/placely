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
public class ReservationController(
    IReservationService service, IMapper mapper, IValidator<ReservationDto> validator) : ControllerBase
{
    [SwaggerOperation("Получает бронирование по идентификатору",
        "Нельзя получить бронирование, участником которого ты не являешься (не арендатор или арендодатель)")]
    [SwaggerResponse(200, "Информация по бронированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка получить бронирование, участником которого пользователь не является.")]
    [HttpGet("{reservationId:long}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter("Идентификатор бронирования.", Required = true)] long reservationId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbReservation = await service.GetByIdAsync(reservationId);
        if (dbReservation.LandlordId != currentUserId || dbReservation.TenantId != currentUserId) return Forbid();
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Добавляет новое бронирование",
        "Нельзя добавить бронирование, участником которого ты не являешься (не арендатор).")]
    [SwaggerResponse(200, "Информация по созданному бронированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка создать бронирование, участником которого пользователь не является.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationError>),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] [SwaggerParameter("Данные для бронирования.", Required = true)] ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        if (dto.TenantId != currentUserId) return Forbid();
        var reservation = mapper.Map<Reservation>(dto);
        var dbReservation = await service.CreateAsync(reservation);
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Обновляет уже существующее бронирование",
        "Нельзя обновить бронирование, участником которого ты не являешься (не арендатор).")]
    [SwaggerResponse(200, "Информация по созданному бронированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка обновить бронирование, создателем которого пользователь не является.")]
    [SwaggerResponse(422, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationError>),
        "application/json")]
    [HttpPatch]
    public async Task<IActionResult> Update(
        [FromBody] [SwaggerParameter("Обновлённые данные для бронирования.", Required = true)] ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        if (dto.TenantId != currentUserId) return Forbid();
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
    [SwaggerResponse(200, "Данные об удалённом бронировании.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка удалить бронирование, участником которого пользователь не является.")]
    [SwaggerResponse(409, "Попытка удалить бронирование, находящееся в обработке.")]
    [HttpDelete("{reservationId:long}")]
    public async Task<IActionResult> Delete([SwaggerParameter("Идентификатор бронирования.")] long reservationId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbReservation = await service.GetByIdAsync(reservationId);
        if (dbReservation.LandlordId != currentUserId || dbReservation.TenantId != currentUserId) return Forbid();
        if (dbReservation.ReservationStatus == ReservationStatus.InProgress) return Conflict();
        var deletedReservation = await service.DeleteAsync(reservationId);
        var response = mapper.Map<ReservationDto>(deletedReservation);
        return Ok(response);
    }
}