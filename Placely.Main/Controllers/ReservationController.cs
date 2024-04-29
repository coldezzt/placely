using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
    IReservationService service,
    IMapper mapper,
    IValidator<ReservationDto> validator) : ControllerBase
{
    [SwaggerOperation(
        summary: "Получает бронирование по идентификатору",
        description: "Нельзя получить бронирование, участником которого ты " +
                     "не являешься (не арендатор или арендодатель)")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация по бронированию.",
        type: typeof(ReservationDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка получить бронирование, участником которого пользователь не является.")]
    [HttpGet("{reservationId:long}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter(description: "Идентификатор бронирования.", Required = true)] long reservationId)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId) ?? "",
            NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var dbReservation = await service.GetByIdAsync(reservationId);
        if (dbReservation.LandlordId != currentUserId
            || dbReservation.TenantId != currentUserId)
            return Forbid();

        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation(
        summary: "Добавляет новое бронирование",
        description: "Нельзя добавить бронирование, участником которого ты " +
                     "не являешься (не арендатор).")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация по созданному бронированию.",
        type: typeof(ReservationDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка создать бронирование, участником которого пользователь не является.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(List<ValidationError>),
        contentTypes: "application/json")]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] [SwaggerParameter(description: "Данные для бронирования.", Required = true)] ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));
        
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId) ?? "",
            NumberStyles.Any,
            CultureInfo.InvariantCulture);

        if (dto.TenantId != currentUserId)
            return Forbid();

        var reservation = mapper.Map<Reservation>(dto);
        var dbReservation = await service.CreateAsync(reservation);
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }
    
    [SwaggerOperation(
        summary: "Обновляет уже существующее бронирование",
        description: "Нельзя добавить бронирование, участником которого ты " +
                     "не являешься (не арендатор).")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация по созданному бронированию.",
        type: typeof(ReservationDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка обновить бронирование, создателем которого пользователь не является.")]
    [SwaggerResponse(
        statusCode: 422,
        description: "Данные не прошли валидацию. Возвращает список ошибок.",
        type: typeof(List<ValidationError>),
        contentTypes: "application/json")]
    [HttpPatch]
    public async Task<IActionResult> Update(
        [FromBody] [SwaggerParameter(description: "Обновлённые данные для бронирования.", Required = true)] 
        ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationError>));
        
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId) ?? "",
            NumberStyles.Any,
            CultureInfo.InvariantCulture);

        if (dto.TenantId != currentUserId)
            return Forbid();

        var reservation = mapper.Map<Reservation>(dto);
        var dbReservation = await service.UpdateAsync(reservation);
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation(
        summary: "Удаляет бронирование по его идентификатору",
        description: """
                     Нельзя удалить чужое бронирование. 
                     
                     Нельзя удалить бронирование с состоянием "В обработке" (арендодатель его просматривает).
                     """)]
    [SwaggerResponse(
        statusCode: 200,
        description: "Данные об удалённом бронировании.",
        type: typeof(ReservationDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка удалить бронирование, участником которого пользователь не является.")]
    [SwaggerResponse(
        statusCode: 409,
        description: "Попытка удалить бронирование, находящееся в обработке.")]
    [HttpDelete("{reservationId:long}")]
    public async Task<IActionResult> Delete(
        [SwaggerParameter(description: "Идентификатор бронирования.")] long reservationId)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId) ?? "",
            NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var dbReservation = await service.GetByIdAsync(reservationId);
        if (dbReservation.LandlordId != currentUserId
            || dbReservation.TenantId != currentUserId)
            return Forbid();

        if (dbReservation.ReservationStatus == ReservationStatus.InProgress)
            return Conflict();

        var deletedReservation = await service.DeleteAsync(reservationId);
        var response = mapper.Map<ReservationDto>(deletedReservation);
        return Ok(response);
    }
}