using Microsoft.AspNetCore.Mvc;

namespace contract_maker.Controllers;

public class ContractCreator : Controller
{
    [HttpGet]
    public JsonResult Index()
    {
        return new JsonResult(new { Hello = "World!" });
    }
}