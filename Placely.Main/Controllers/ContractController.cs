using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ContractController(IContractService service, IMapper mapper) : ControllerBase
{
    [SwaggerOperation("Получает контракт по его идентификатору",
        "Если авторизованный пользователь не фигурирует в контракте запрещает доступ.")]
    [SwaggerResponse(200, "Информация по контракту.", typeof(ContractDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка получить контракт, в котором нет текущего авторизованного пользователя.")]
    [HttpGet("{contractId:long}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter("Идентификатор контракта.", Required = true)] long contractId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var contract = await service.GetContractByIdAsync(contractId);
        if (contract.LandlordId != currentUserId && contract.TenantId != currentUserId) return Forbid();
        var response = mapper.Map<ContractDto>(contract);
        return Ok(response);
    }

    [SwaggerOperation("Генерирует контракт на основе заявки", 
        """
        Создаёт контракт в папке с чатом между пользователями (если нет создаёт её).

        Большинство данных берёт из заявки. Некоторые договорные данные необходимо передать в теле.
        """)]
    [SwaggerResponse(200, "Информация по контракту.", typeof(ContractDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка запросить создание контракта пользователем, не фигурирующем в контракте.")]
    [HttpPost]
    public async Task<IActionResult> Generate(
        [FromBody] [SwaggerRequestBody("Данные необходимые для завершения создания контракта.", Required = true)]
        ContractCreationDto dto)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var reservation = await service.GetReservationByIdAsync(dto.ReservationId);
        if (reservation.LandlordId != currentUserId && reservation.TenantId != currentUserId) return Forbid();
        var contract = await service.GenerateContractAsync(dto);
        return Ok(contract);
    }
}