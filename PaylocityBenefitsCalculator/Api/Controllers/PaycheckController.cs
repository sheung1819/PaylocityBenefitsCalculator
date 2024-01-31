using Api.Dtos.Dependent;
using Api.Dtos.Paycheck;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PaycheckController : ControllerBase
{
    private readonly IPaycheckService _service;
    public PaycheckController(IPaycheckService service)
    {
        _service = service;
    }


    [SwaggerOperation(Summary = "Get Paycheck")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetPaycheckDto>>> Get(int id)
    {
        var paycheckResult = _service.CalculateMonthlyPaycheck(id);

        if (paycheckResult == null)
        {
            return NotFound();
        }

        return new ApiResponse<GetPaycheckDto>
        {
            Data = paycheckResult,
            Success = true,
        };
    }
}
