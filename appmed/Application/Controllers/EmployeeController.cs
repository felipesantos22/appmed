using appmed.Domain.Entities;
using appmed.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appmed.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController: ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<Employee>> Create([FromBody] Employee employee)
    {
        Employee newPatiente = await _employeeRepository.Create(employee);
        return Ok(newPatiente);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> listarClientes()
    {
        var employees = await _employeeRepository.Index();
        return Ok(employees);
    }
}