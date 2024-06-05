using System.ComponentModel;
using System.Globalization;
using System.Net.Mime;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Placely.Application.Common.Models;
using Placely.Domain.Common.Enums;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace Placely.WebAPI.Controllers;

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
        
        var dbContract = await service.GetByIdAsNoTrackingAsync(contractId);
        if (dbContract.Reservation.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var response = mapper.Map<ContractDto>(dbContract.Reservation);
        return Ok(response);
    }

    [SwaggerOperation("Получает все названия файлов для контракта",
        "Нельзя получить названия чужих контрактов.")]
    [SwaggerResponse(200, "Список названия контрактов.", typeof(List<string>),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка получить список чужих контрактов.")]
    [HttpGet("file/list/{contractId:long}")]
    public async Task<IActionResult> GetAssociatedFiles(
        [DefaultValue(3)] [FromRoute] [SwaggerParameter("Идентификатор контракта.", Required = true)] 
        long contractId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        
        var dbContract = await service.GetByIdAsNoTrackingAsync(contractId);
        if (dbContract.Reservation.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var names = await service.GetFileNamesByUserIdsAsync(dbContract.Reservation.Participants
                .Select(p => p.Id).ToList());
        return Ok(names);
    }
    
    [SwaggerOperation("Скачивает файл из чата", "Нельзя скачать файл из чужого чата.")]
    [SwaggerResponse(200, "Файл.", typeof(FileContentResult),
        "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка загрузить файл из чужого чата.")]
    [SwaggerResponse(404, "Файл для скачивания не был найден.")]
    [HttpGet("file/{contractId:long}")]
    public async Task<IActionResult> DownloadFile(
        [DefaultValue(1)] [FromRoute] [SwaggerParameter("Идентификатор чата.", Required = true)]
        long contractId,
        [DefaultValue("contract_data_id.docx")] [FromQuery] 
        [SwaggerParameter("Название файла для скачивания.", Required = true)] string fileName)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbContract = await service.GetByIdAsNoTrackingAsync(contractId);
        
        if (dbContract.Reservation.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        var file = await service.GetFileBytesByIdAsync(dbContract.Id, fileName);
        return file.Length == 0 
            ? NotFound() 
            : File(file, MediaTypeNames.Application.Octet, fileName);
    }

    [SwaggerOperation("Генерирует контракт на основе заявки", 
        "Создаёт контракт в папке (если нет создаёт её) с контрактами владельца имущества между пользователями.")]
    [SwaggerResponse(200, "Информация по контракту.", typeof(ContractDto), "application/json")]
    [SwaggerResponse(401, "Пользователь не авторизован.")]
    [SwaggerResponse(403, "Попытка запросить создание контракта пользователем, не фигурирующем в контракте.")]
    [SwaggerResponse(409, "Попытка создать контракт на основе отклонённой заявки.")]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] [SwaggerRequestBody("Данные необходимые для завершения создания контракта.", Required = true)]
        long reservationId)
    {
        var currentUserId = long.Parse(User.FindFirstValue(CustomClaimTypes.UserId)!, NumberStyles.Any,
            CultureInfo.InvariantCulture);
        var dbReservation = await service.GetReservationByIdAsync(reservationId);
        
        if (dbReservation.Participants.Any(p => p.Id == currentUserId)) 
            return Forbid();
        
        if (dbReservation.Status is ReservationStatus.Declined) 
            return Conflict();
        
        var contract = await service.GenerateAsync(reservationId);
        var response = mapper.Map<ContractDto>(contract);
        return Ok(response);
    }
}