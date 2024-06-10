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

[ApiController]
[Authorize(Roles = UserRoleType.Admin)]
[Route("api/admin/reservation")]
public class ReservationAdminController(
    IReservationService service,
    IMapper mapper,
    IValidator<ReservationDto> validator) : ControllerBase
{
    [SwaggerOperation("Принудительно добавляет новое резервирование")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по созданному резервированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPost]
    public async Task<IActionResult> Create( // POST api/admin/reservation
        [FromBody] [SwaggerRequestBody("Данные для резервирования.", Required = true)] ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
        
        var reservation = mapper.Map<Reservation>(dto);
        var dbReservation = await service.CreateAsync(reservation);
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Принудительно обновляет существующее резервирование")]
    [SwaggerResponse(StatusCodes.Status200OK, "Информация по обновлённому резервированию.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Данные не прошли валидацию. Возвращает список ошибок.", typeof(List<ValidationErrorModel>),
        "application/json")]
    [HttpPatch("{reservationId:long}")]
    public async Task<IActionResult> Update( // PATCH api/admin/reservation/{reservationId}
        [FromRoute] [SwaggerParameter("Идентификатор резервирования для обновления", Required = true)] long reservationId,
        [FromBody] [SwaggerRequestBody("Обновлённые данные для резервирования.", Required = true)] ReservationDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));

        dto.Id = reservationId;
        var reservation = mapper.Map<Reservation>(dto);
        var dbReservation = await service.UpdateAsync(reservation);
        var response = mapper.Map<ReservationDto>(dbReservation);
        return Ok(response);
    }

    [SwaggerOperation("Принудительно удаляет резервирование по его идентификатору")]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные об удалённом резервировании.", typeof(ReservationDto), "application/json")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Пользователь не авторизован.")]
    [HttpDelete("{reservationId:long}")]
    public async Task<IActionResult> Delete( // DELETE api/admin/reservation/{reservationId}
        [FromRoute] [SwaggerParameter("Идентификатор резервирования.", Required = true)] long reservationId)
    {
        var deletedReservation = await service.DeleteAsync(reservationId);
        var response = mapper.Map<ReservationDto>(deletedReservation);
        return Ok(response);
    }
}