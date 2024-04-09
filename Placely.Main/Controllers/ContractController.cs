using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class ContractController(
    IContractService contractService,
    IMapper mapper) : ControllerBase
{
    [HttpPost("[action]/{reservationId:long}")]
    public IActionResult Generate(long reservationId)
    {
        var result = contractService.GenerateContractAsync(reservationId);
        return Ok();
    }
}