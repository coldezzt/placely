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
[Route("api/[controller]/my")]
public class ReservationController(
        IReservationService service, 
        IMapper mapper, 
        IValidator<ReservationDto> validator
    ) : ControllerBase
{
    [SwaggerOperation("Получает резервирование по идентификатору",
        "Нельзя получить резервирование, участником которого ты не являешься (не арендатор или арендодатель)")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по резервированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка получить резервирование, участником которого пользователь не является.")]
    [HttpGet("{reservationId:long}")]
    public async Task<IActionResult> Get( // GET api/reservation/my/{reservationId}
        [FromRoute] [SwaggerParameter("Идентификатор резервирования.", Required = true)] long reservationId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbReservation = await service.GetByIdAsNoTrackingAsync(reservationId);
        if (dbReservation.Participants.All(p => p.Id != currentUserId)) 
            return Forbid();

        await service.UpdateReservationStatus(reservationId, currentUserId);
        
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Добавляет новое резервирование",
        "Нельзя добавить резервирование, участником которого ты не являешься (не арендатор).")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по созданному резервированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка создать резервирование, участником которого пользователь не является.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Create( // POST api/reservation/my
        [FromBody] [SwaggerRequestBody("Данные для резервирования.", Required = true)] ReservationDto dto)
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

    [SwaggerOperation("Обновляет уже существующее резервирование",
        "Нельзя обновить резервирование, участником которого ты не являешься (не арендатор).")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по созданному резервированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка обновить резервирование, создателем которого пользователь не является.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("{reservationId:long}")]
    public async Task<IActionResult> Update( // PATCH api/reservation/my/{reservationId}
        [FromRoute] [SwaggerParameter("Идентификатор резервирования для обновления", Required = true)] long reservationId,
        [FromBody] [SwaggerRequestBody("Обновлённые данные для резервирования.", Required = true)] ReservationDto dto)
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

    [SwaggerOperation("Удаляет резервирование по его идентификатору", 
        """
        Нельзя удалить чужое резервирование.

        Нельзя удалить резервирование с состоянием "В обработке" (арендодатель его просматривает).
        """)]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об удалённом резервировании.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Попытка удалить резервирование, участником которого пользователь не является.")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "Попытка удалить резервирование, находящееся в обработке.")]
    [HttpDelete("{reservationId:long}")]
    public async Task<IActionResult> Delete( // DELETE api/reservation/my/{reservationId}
        [FromRoute] [SwaggerParameter("Идентификатор резервирования.", Required = true)] long reservationId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId) ?? "", NumberStyles.Any,
            CultureInfo.InvariantCulture);

        var dbReservation = await service.GetByIdAsNoTrackingAsync(reservationId);
        if (dbReservation.Participants.All(p => p.Id != currentUserId)) 
            return Forbid();
        
        if (dbReservation.StatusType == ReservationStatusType.InProgress) 
            return Conflict();
        
        var deletedReservation = await service.DeleteAsync(reservationId);
        var response = mapper.Map<ReservationDto>(deletedReservation);
        return Ok(response);
    }
}