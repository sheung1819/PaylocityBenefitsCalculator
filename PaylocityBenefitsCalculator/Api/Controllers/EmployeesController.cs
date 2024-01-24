using Api.Dtos.Employee;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeesController(IEmployeeService employeeService) 
    {
        _employeeService = employeeService;
    }
    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        var result = _employeeService.GetEmployeeByID(id);
        if(result == null) 
        {
            return NotFound();
        }
        return new ApiResponse<GetEmployeeDto>
        {
            Data = result,
            Success = true
        };
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {
        var result = _employeeService.GetEmployees();
        return new ApiResponse<List<GetEmployeeDto>>
        {
            Data = result.ToList(),
            Success = true
        };
    }
}
