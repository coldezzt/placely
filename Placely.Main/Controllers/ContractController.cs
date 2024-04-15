using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos.Requests;

namespace Placely.Main.Controllers;

[Route("api/[controller]")]
public class ContractController(
    IContractService contractService,
    IMapper mapper) : ControllerBase
{
    [HttpPost("[action]")]
    public IActionResult Generate([FromBody] ContractCreateRequestDto dto)
    {
        var result = contractService.GenerateContractAsync(dto);
        return Ok(result.Id);
    }
}