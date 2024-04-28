using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Dtos.Requests;
using Placely.Data.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.Main.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ContractController(
    IContractService service,
    IMapper mapper) : ControllerBase
{
    [SwaggerOperation(
        summary: "Получает контракт по его идентификатору",
        description: "Если авторизованный пользователь не фигурирует в контракте запрещает доступ.")]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация по контракту.",
        type: typeof(ContractDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка получить контракт, в котором нет текущего авторизованного пользователя.")]
    [HttpGet("{contractId:long}")]
    public async Task<IActionResult> Get(
        [SwaggerParameter(description: "Идентификатор контракта.", Required = true)] long contractId)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);

        var contract = await service.GetContractByIdAsync(contractId);
        if (contract.LandlordId != currentUserId && contract.TenantId != currentUserId)
            return Forbid();

        var response = mapper.Map<ContractDto>(contract);
        return Ok(response);
    }
    
    [SwaggerOperation(
        summary: "Генерирует контракт на основе заявки",
        description: """
                     Создаёт контракт в папке с чатом между пользователями (если нет создаёт её).
                     
                     Большинство данных берёт из заявки. Некоторые договорные данные необходимо передать в теле.
                     """)]
    [SwaggerResponse(
        statusCode: 200,
        description: "Информация по контракту.",
        type: typeof(ContractDto),
        contentTypes: "application/json")]
    [SwaggerResponse(
        statusCode: 401,
        description: "Пользователь не авторизован.")]
    [SwaggerResponse(
        statusCode: 403,
        description: "Попытка запросить создание контракта пользователем, не фигурирующем в контракте.")]
    [HttpPost]
    public async Task<IActionResult> Generate(
        [FromBody] 
        [SwaggerRequestBody(
            description: "Данные необходимые для завершения создания контракта.",
            Required = true)] 
        ContractCreateRequestDto dto)
    {
        var currentUserId = long.Parse(
            User.FindFirstValue(CustomClaimTypes.UserId)!, 
            NumberStyles.Any, 
            CultureInfo.InvariantCulture);

        var reservation = await service.GetReservationByIdAsync(dto.ReservationId);
        if (reservation.LandlordId != currentUserId && reservation.TenantId != currentUserId)
            return Forbid();
        
        var contract = await service.GenerateContractAsync(dto);
        return Ok(contract);
    }
}