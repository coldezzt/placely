using System.ComponentModel;
using System.Globalization;
using System.Net.Mime;
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
        var contract = await service.GetByIdAsNoTrackingAsync(contractId);
        if (contract.LandlordId != currentUserId && contract.TenantId != currentUserId) return Forbid();
        var response = mapper.Map<ContractDto>(contract);
        return Ok(response);
    }

    [SwaggerOperation("Получает все названия файлов для контракта",
        "Нельзя получить названия чужих контрактов.")]
    [SwaggerResponse(200, "Список названия контрактов.", typeof(List<string>),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка получить список чужих контрактов.")]
    [HttpGet("list/{contractId:long}")]
    public async Task<IActionResult> GetAssociatedFiles(
        [DefaultValue(3)] [FromRoute] [SwaggerParameter("Идентификатор контракта.", Required = true)] 
        long contractId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbContract = await service.GetByIdAsNoTrackingAsync(contractId);
        if (currentUserId != dbContract.TenantId && currentUserId != dbContract.LandlordId) return Forbid();
        var names = await service.GetFileNamesListByLandlordIdAsync(dbContract.LandlordId);
        return Ok(names);
    }
    
    [SwaggerOperation("Скачивает файл из чата", "Нельзя скачать файл из чужого чата.")]
    [SwaggerResponse(200, "Файл.", typeof(FileContentResult),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка загрузить файл из чужого чата.")]
    [SwaggerResponse(404, "Файл для скачивания не был найден.")]
    [HttpGet("{contractId:long}/file")]
    public async Task<IActionResult> DownloadFile(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long contractId,
        [DefaultValue("new.txt")] [FromQuery] [SwaggerParameter("Название файла для скачивания.", Required = true)]
        string fileName)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbContract = await service.GetByIdAsNoTrackingAsync(contractId);
        if (dbContract.TenantId != currentUserId && dbContract.LandlordId != currentUserId) return Forbid();
        var file = await service.GetFileBytesByIdAsync(dbContract.Id, fileName);
        return file.Length == 0 ? NotFound() : File(file, MediaTypeNames.Application.Octet, fileName);
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
    public async Task<IActionResult> Create(
        [FromBody] [SwaggerRequestBody("Данные необходимые для завершения создания контракта.", Required = true)]
        ContractCreationDto dto)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var reservation = await service.GetReservationByIdAsync(dto.ReservationId);
        if (reservation.LandlordId != currentUserId && reservation.TenantId != currentUserId) return Forbid();
        var contract = await service.GenerateAsync(dto);
        return Ok(contract);
    }
}